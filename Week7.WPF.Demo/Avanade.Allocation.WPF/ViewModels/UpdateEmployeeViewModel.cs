using Avanade.Allocation.Core.BusinessLayer;
using Avanade.Allocation.Core.Entities;
using Avanade.Allocation.Core.Mock.Repositories;
using Avanade.Allocation.WPF.Messaging.Employee;
using Avanade.Allocation.WPF.Messaging.Misc;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Avanade.Allocation.WPF.ViewModels
{
    public class UpdateEmployeeViewModel : ViewModelBase
    {
        private Employee _Entity;

        private int _Id;
        public int Id
        {
            get { return _Id; }
            set { _Id = value; RaisePropertyChanged(); }
        }

        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; RaisePropertyChanged(); }
        }

        private string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; RaisePropertyChanged(); }
        }

        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; RaisePropertyChanged(); }
        }

        private double _Salary;
        public double Salary
        {
            get { return _Salary; }
            set { _Salary = value; RaisePropertyChanged(); }
        }

        private bool _IsEnabled;
        public bool IsEnabled
        {
            get { return _IsEnabled; }
            set { _IsEnabled = value; RaisePropertyChanged(); }
        }

        private DateTime _DateOfBirth;
        public DateTime DateOfBirth
        {
            get { return _DateOfBirth; }
            set { _DateOfBirth = value; RaisePropertyChanged(); }
        }

        public ICommand UpdateCommand { get; set; }

        public ICommand CancelCommand { get; set; }

        public UpdateEmployeeViewModel()
        {
            //() => ExecuteUpdate(), 
            UpdateCommand = new RelayCommand(() => ExecuteUpdate());
            CancelCommand = new RelayCommand(() => ExecuteCancel());
            if (!IsInDesignMode)
            {
                PropertyChanged += (s, e) =>
                {
                    (UpdateCommand as RelayCommand).RaiseCanExecuteChanged();
                };

            }
        }

        public UpdateEmployeeViewModel(Employee entity) : this()
        {
            //Validazione argomento
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            //Inizializzazione delle props
            _Entity = entity;
            Id = entity.Id;
            FirstName = entity.FirstName;
            LastName = entity.LastName;
            Salary = entity.Salary;
            Email = entity.Email;
            IsEnabled = entity.IsEnabled;
        }

        private void ExecuteCancel()
        {
            //Lancia un evento di chiusura della finestra di update
            Messenger.Default.Send(new CloseUpdateEmployeeMessage());
        }

        private bool CanExecuteUpdate()
        {


            //Confermo se ho nome, cognome e selezione
            return
                !string.IsNullOrEmpty(FirstName) &&
                !string.IsNullOrEmpty(LastName) && string.IsNullOrEmpty(Email);
        }

        private void ExecuteUpdate()
        {

            //Recupero i dati dalle props del vm corrente e 
            //creo nuova nuova entity
            var entity = new Employee
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Salary = Salary,
                DateOfBirth = DateOfBirth,
                IsEnabled = true
            };

            //Inizializzo il BL
            
            var layer = new MainBusinessLayer(new EmployeeRepositoryMock());

            //Passo la entity al BL per il salvataggio
            var result = layer.UpdateEmployee(entity);

            //Se ho anche solo un errore di validazione
            if (!result.Success)
            {
                //Mostro un messaggio di warning
                Messenger.Default.Send(new DialogMessage
                {
                    Title = "Attenzione! Alcuni dati non sono validi!",
                    Content = result.Message,
                    Icon = MessageBoxImage.Warning
                });
                return;
            }

            //Mostro un messaggio per segnalare che il salvataggio è andato bene
            Messenger.Default.Send(new DialogMessage
            {
                Title = "Conferma",
                Content = $"L'impiegato {FirstName} {LastName} è stato aggiornato!",
                Icon = MessageBoxImage.Information
            });

            //Chiudo la finestra corrente
            CancelCommand.Execute(null);
        }
    }
}
