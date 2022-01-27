using Avanade.Allocation.WPF.Messaging.Employee;
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
    /// Interaction logic for EmployeeCreateView.xaml
    /// </summary>
    public partial class EmployeeCreateView : Window
    {
        public EmployeeCreateView()
        {
            InitializeComponent();
            //Mi registro al messaggio di chiusura in modo da chiudere me stesso
            //ovvero la form di create
            Messenger.Default.Register<CloseCreateEmployeeMessage>(this, _ => Close());

            Closing += (s, e) =>
            {
                //Eseguo la de-registrazione da tutti i messaggi a cui mi sono 
                //registrato all'interno della view
                //e scollego anche il view model
                //questo per evitare conflitti con altre aperture di finestre
                Messenger.Default.Unregister(this);
                Messenger.Default.Unregister(DataContext);
            };
        }

        
    }
}
