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
using System.Windows.Input;

namespace Avanade.Allocation.WPF.ViewModels
{
    public class EmployeeCreateViewModel : ViewModelBase
    {
        public ICommand CreateCommand { get; set; }

        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                _FirstName = value; RaisePropertyChanged();
            }
        }

        private string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set
            {
                _LastName = value; RaisePropertyChanged();
            }
        }

        private string _Email;
        public string Email
        {
            get { return _Email; }
            set
            {
                _Email = value; RaisePropertyChanged();
            }
        }

        private double _Salary;
        public double Salary
        {
            get { return _Salary; }
            set
            {
                _Salary = value; RaisePropertyChanged();
            }
        }

        private DateTime _DateOfBirth;
        public DateTime DateOfBirth
        {
            get { return _DateOfBirth; }
            set
            {
                _DateOfBirth = value; RaisePropertyChanged();
            }
        }

        public EmployeeCreateViewModel()
        {
            CreateCommand = new RelayCommand(() => ExecuteCreate(), () => CanExecuteCreate());

            if (!IsInDesignMode)
            {
                PropertyChanged += (s, e) =>
                {
                    (CreateCommand as RelayCommand).RaiseCanExecuteChanged();
                };
            }
        }

        private bool CanExecuteCreate()
        {
            //Il pulsante create è abilitato soltanto se tutti i campi sono valorizzati
            return !string.IsNullOrEmpty(FirstName) &&
                !string.IsNullOrEmpty(LastName) &&
                !string.IsNullOrEmpty(Email) &&
                !string.IsNullOrEmpty(Salary.ToString()) &&
                !string.IsNullOrEmpty(DateOfBirth.ToString());
        }

        private void ExecuteCreate()
        {
            //Recupero i dati dalle proprietà del view
            //model e creo una nuova entità
            var entity = new Employee
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                DateOfBirth = DateOfBirth,
                Salary = Salary,
                IsEnabled = true
            };

            //Inizializzo il business layer
            var layer = new MainBusinessLayer(new EmployeeRepositoryMock());
            //Richiamo l'operazione del layer
            var response = layer.CreateEmployee(entity);

            if (!response.Success)
            {
                Messenger.Default.Send(new DialogMessage
                {
                    Title = "Something wrong",
                    Content = response.Message,
                    Icon = System.Windows.MessageBoxImage.Warning
                });
                return;
            }
            else
            {
                Messenger.Default.Send(new DialogMessage
                {
                    Title = "Creazione completata",
                    Content = response.Message,
                    Icon = System.Windows.MessageBoxImage.Information
                });
            }
            Messenger.Default.Send(new CloseCreateEmployeeMessage());
        }
    }
}
