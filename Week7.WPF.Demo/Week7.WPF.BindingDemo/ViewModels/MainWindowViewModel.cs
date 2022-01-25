using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Week7.WPF.BindingDemo.Models;

namespace Week7.WPF.BindingDemo.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private IRepositoryPerson _repoPerson;

        //Lista di persone da collegare in binding con la view
        public IList<Person> People => _repoPerson.GetAll();
        //public IList<Person> People
        //{
        //    get
        //    {
        //        return _repoPerson.GetAll();
        //    }
        //}

        //Proprietà che conterrà la persona selezionata
        private Person _selectedPerson = null;

        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                if(_selectedPerson == value)
                {
                    return;
                }
                _selectedPerson = value;

                //SCATENARE L'EVENTO DI BINDING
                NotifyPropertyChanged();
                //RICHIAMIAMO L'OPERAZIONE DA ESEGUIRE QUANDO LA PROPRIETA' VIENE MODIFICATA
                SalutaCommand.RaiseCanExecuteChanged();
            }
        }

        private string txtSaluto = null;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string TextSaluto
        {
            get { return txtSaluto; }
            set { 
                txtSaluto = value;
                NotifyPropertyChanged();
            }
        }

        public RelayCommand SalutaCommand { get; private set; }

        public MainWindowViewModel(IRepositoryPerson repo)
        {
            _repoPerson = repo;
            SalutaCommand = new RelayCommand(salutaExecute, salutaCanExecute);
        }

        
        private bool salutaCanExecute(object? param)
        {
            return SelectedPerson != null;
        }

        private void salutaExecute(object? param)
        {
            if (SelectedPerson != null)
            {
                TextSaluto = $"Hi, {SelectedPerson}";
            }
        }

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
