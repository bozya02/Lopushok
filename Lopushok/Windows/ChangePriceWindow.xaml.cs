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
using Lopushok.DB;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Lopushok.Windows
{
    /// <summary>
    /// Interaction logic for ChangePriceWindow.xaml
    /// </summary>
    public partial class ChangePriceWindow : Window
    {
        public decimal Price { get; set; }
        private List<Product> products;
        public ChangePriceWindow(List<Product> products)
        {
            this.products = products;
            InitializeComponent();
            DataContext = this;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (Price == 0 && MessageBox.Show( "Цена выбранных продуктов не изменится", "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.Cancel)
            {
                return;
            }
            DialogResult = true;

            foreach (var product in products)
            {
                product.MinPrice += Price;
                DataAccess.SaveProduct(product);
            }
        }
    }
}
