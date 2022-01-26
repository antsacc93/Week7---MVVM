using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Week7.WPF.Esercitazione2.Models;
using Week7.WPF.Esercitazione2.ViewModels;
using Week7.WPF.Esercitazione2.Views;

namespace Week7.WPF.Esercitazione2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow = new MainWindow();
            IProductRepository repositoryProduct = new ProductRepositoryMock();
            MainWindow.DataContext = new MainWindowViewModel(repositoryProduct);
            MainWindow.Show();
        }
    }
}
