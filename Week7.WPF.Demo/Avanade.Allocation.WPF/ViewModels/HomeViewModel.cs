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
    public class HomeViewModel : ViewModelBase
    {
        public ICommand ExitCommand { get; set; }
        public ICommand ShowEmployeesCommand { get; set; }

        public HomeViewModel()
        {
            //Inizializzazione dei command
            ShowEmployeesCommand = new RelayCommand(() => ExecuteShowEmployees());
            ExitCommand = new RelayCommand(() => ExecuteExit());
        }

        private void ExecuteExit()
        {
            Messenger.Default.Send(new DialogMessage
            {
                Title = "Confirm exit",
                Content = "Are you sure?",
                Icon = MessageBoxImage.Question,
                Buttons = MessageBoxButton.YesNo,
                Callback = (result) =>
                {
                    //Esco dall'applicazione solo se l'utente preme "YES"
                    if (result == MessageBoxResult.Yes)
                        Messenger.Default.Send(new ShutDownApplicationMessage());
                }
            });
        }

        private void ExecuteShowEmployees()
        {
            Messenger.Default.Send(new ShowEmployeeMessage());
        }
    }
}
