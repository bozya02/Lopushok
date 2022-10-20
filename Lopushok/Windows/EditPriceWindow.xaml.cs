using Lopushok.DB;
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

namespace Lopushok.Windows
{
    /// <summary>
    /// Interaction logic for EditPriceWindow.xaml
    /// </summary>
    public partial class EditPriceWindow : Window
    {
        public double Price { get; set; }
        public List<Product> Products { get; set; }
        public EditPriceWindow(List<Product> products)
        {
            InitializeComponent();
            Products = products;
            Price = (double)Products.Sum(x => x.MinPrice) / Products.Count();
            this.DataContext = this;
        }

        private void tbPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            var text = tbPrice.Text;
            
            if (text == "")
            {
                tbPrice.Text = "";
                return;
            }
            double price;
            if (double.TryParse(text, out price))
            {
                Price = price;
                tbPrice.Text = Price.ToString();
            }
            else
                tbPrice.Text = Price.ToString();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            foreach (var product in Products)
            {
                product.MinPrice += (decimal)Price;
                DataAccess.SaveProduct(product);
            }
        }
    }
}
