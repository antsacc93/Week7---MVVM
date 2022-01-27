using Avanade.Allocation.Core.BusinessLayer;
using Avanade.Allocation.Core.Entities;
using Avanade.Allocation.Core.Mock.Repositories;
using Avanade.Allocation.Core.Repositories;
using Avanade.Allocation.WPF.Messaging.Employee;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Avanade.Allocation.WPF.ViewModels
{
    public class EmployeeEditorViewModel : ViewModelBase
    {
        public ICommand CreateEmployee { get; set; }
        

        public ObservableCollection<EmployeeRowViewModel> _EmployeesSource;
        private ICollectionView _Employees;
        public ICollectionView Employees
        {
            get { return _Employees; }
            set { _Employees = value; RaisePropertyChanged(); }
        }

        public ICommand LoadEmployeesCommand { get; set; }

        public EmployeeEditorViewModel()
        {
            CreateEmployee = new RelayCommand(() => ExecuteShowCreateEmployee());
            LoadEmployeesCommand = new RelayCommand(() => ExecuteLoadEmployees());

            //inizializzazione delle liste
            _EmployeesSource = new ObservableCollection<EmployeeRowViewModel>();
            _Employees = new CollectionView(_EmployeesSource);

            LoadEmployeesCommand.Execute(null);
        }

        private void ExecuteLoadEmployees()
        {
            //Inizializzo il business layer
            //Istanziare il repository
            IEmployeeRepository repo = new EmployeeRepositoryMock();
            MainBusinessLayer layer = new MainBusinessLayer(repo);

            //Dipendenti provienienti dal repo
            var employees = layer.FetchAllEmployees();
            
            //Pulizia della lista sorgente
            _EmployeesSource.Clear();

            //Per ciascun dipendente creo una riga di tipo EmployeeRowViewModel
            foreach (Employee item in employees)
            {
                var vmEmpRow = new EmployeeRowViewModel(item);
                _EmployeesSource.Add(vmEmpRow);
            }


        }

        private void ExecuteShowCreateEmployee()
        {
            Messenger.Default.Send(new ShowCreateEmployeeMessage());
        }
    }
}
