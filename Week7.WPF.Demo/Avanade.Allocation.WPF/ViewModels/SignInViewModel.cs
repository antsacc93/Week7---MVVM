using Avanade.Allocation.Core.BusinessLayer;
using Avanade.Allocation.Core.Mock.Repositories;
using Avanade.Allocation.Core.Repositories;
using Avanade.Allocation.Core.Utils;
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
    public class SignInViewModel : ViewModelBase
    {

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set{ _userName = value; RaisePropertyChanged("UserName"); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; RaisePropertyChanged("Password"); }
        }

        public ICommand SignInCommand { get; set; }

        public SignInViewModel()
        {
            SignInCommand = new RelayCommand(
                () => ExecuteSignIn(),
                () => CanExecuteSignIn());
            if (IsInDesignMode)
            {
                UserName = "giuseppe.verdi";
                Password = "abcdeghi";
            }
            else
            {
                UserName = "mario.rossi";
                Password = "123456";
            }

        }

        private bool CanExecuteSignIn()
        {
            return !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password);
        }

        private async Task ExecuteSignIn()
        {
            //Inizializzazione business layer
            IUserRepository repo = new UserRepositoryMock();
            AuthenticationBusinessLayer layer = new AuthenticationBusinessLayer(repo);

            //Eseguo l'autenticazione mediante il business layer appena creato
            Response response = await layer.SignInAsync(UserName, Password);
            if (response.Success)
            {
                //APRI FINESTRA DI DIALOGO CON CONTENUTO
                //Messenger.Default.Send(new DialogMessage
                //{
                //    Title = "Log-in Effettuato",
                //    Content = response.Message
                //});
                //Invio del messaggio che apre la finestra home
                Messenger.Default.Send(new ShowHomeViewMessage());
            }
            else
            {
                //Finestra di dialogo con il messaggio
                Messenger.Default.Send(new DialogMessage
                {
                    Title = "Error",
                    Content = response.Message
                });
            }
        }
    }
}
