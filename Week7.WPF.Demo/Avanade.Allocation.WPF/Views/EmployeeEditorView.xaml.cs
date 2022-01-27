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
    /// Interaction logic for EmployeeEditorView.xaml
    /// </summary>
    public partial class EmployeeEditorView : Window
    {
        public EmployeeEditorView()
        {
            InitializeComponent();
            Messenger.Default.Register<ShowCreateEmployeeMessage>(this, OnShowCreateEmployeeExecuted);
        }

        private void OnShowCreateEmployeeExecuted(ShowCreateEmployeeMessage obj)
        {
            EmployeeCreateView view = new EmployeeCreateView();
            EmployeeCreateViewModel vm = new EmployeeCreateViewModel();
            view.DataContext = vm;
            view.ShowDialog();
        }
    }
}
