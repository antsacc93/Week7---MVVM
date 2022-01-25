using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Week7.WPF.BindingDemo.Models;
using Week7.WPF.BindingDemo.ViewModels;

namespace Week7.WPF.BindingDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //Collegamento tra interfaccia del repository e implentazione repo che gestisce i dati
            IRepositoryPerson repositoryPerson = new RepositoryPersonMock();
            //View Model da utilizzare nell'app
            MainWindowViewModel vm = new MainWindowViewModel(repositoryPerson);
            //Finestra da visualizzare in fase di startup
            MainWindow window = new MainWindow(vm);
            window.Show();

        }
    }
}
