using Avanade.Allocation.WPF.Messaging.Misc;
using Avanade.Allocation.WPF.ViewModels;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Avanade.Allocation.WPF.Views
{
    /// <summary>
    /// Interaction logic for SignInView.xaml
    /// </summary>
    public partial class SignInView : Window
    {
        public SignInView()
        {
            InitializeComponent();

            //Mi metto in ascolto del messaggio di apertura della Home
            Messenger.Default.Register<ShowHomeViewMessage>(this, OnShowHomeViewMessageReceived);
        }

        private void OnShowHomeViewMessageReceived(ShowHomeViewMessage message)
        {
            //Inizializzo la view Home
            HomeView home = new HomeView();
            //Inizializzo il view model corrispondente
            HomeViewModel vm = new HomeViewModel();

            //Collego la view al suo view model
            home.DataContext = vm;

            //Visualizzazione della view home
            home.Show();
            //Chiusura della finestra di login
            this.Close();
        }
    }
}
