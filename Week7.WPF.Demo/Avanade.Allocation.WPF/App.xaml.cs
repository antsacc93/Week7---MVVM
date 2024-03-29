﻿using Avanade.Allocation.Core.Mock.Storage;
using Avanade.Allocation.WPF.Messaging.Misc;
using Avanade.Allocation.WPF.ViewModels;
using Avanade.Allocation.WPF.Views;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Avanade.Allocation.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //Mi metto in ascolto di eventuali messaggi "DialogMessage"
            Messenger.Default.Register<DialogMessage>(this, OnDialogMessageReceived);
            Messenger.Default.Register<ShutDownApplicationMessage>(this, _ => Current.Shutdown());

            //Inizializzazione database fittizio
            AllocationMockStorage.Initialize();

            //Inizializzo la view di login
            SignInView view = new SignInView();

            //Inizializzo il view model associato alla login
            SignInViewModel vm = new SignInViewModel();

            //Collego il vm alla view
            view.DataContext = vm;

            //Mostro la view
            view.Show();

            base.OnStartup(e);
        }


        //metodo che scatta quando arriva un qualsiasi messaggio di tipo 
        //dialog message
        private void OnDialogMessageReceived(DialogMessage message)
        {
            MessageBoxResult result = MessageBox.Show(
                message.Content, 
                message.Title, 
                message.Buttons, message.Icon);

            //Qui ho il risultato della selezione del pulsante
            //cliccato dall'utente => avvio la funzione di Callback
            //SOLAMENTE se è stata specificata (il default è che non 
            //è stata specificata, quindi è nulla!!!)
            if (message.Callback != null)
                message.Callback(result);
        }
    }
}
