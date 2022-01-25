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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Week7.WPF.Esercitazione1.Models;

namespace Week7.WPF.Esercitazione1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IProductRepository productRepository = new ProductRepositoryMock(); 
        public MainWindow()
        {
            InitializeComponent();
            lstProducts.ItemsSource = productRepository.GetAll().Select(p => p.Name);
        }

        private void ViewProduct(object sender, RoutedEventArgs e)
        {
            
            var selectedName = lstProducts.SelectedItem;
            if(selectedName != null)
            {
                Product product = productRepository.GetAll().FirstOrDefault(
                    p => p.Name.Equals(selectedName));
                txtDetails.Text = product.ToString();
            }
        }
    }
}
