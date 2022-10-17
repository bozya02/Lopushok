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

namespace Lopushok.Windows
{
    /// <summary>
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        public Product Product { get; set; }
        public List<ProductType> ProductTypes { get; set; }
        public List<Workshop> Workshops { get; set; }

        public ProductWindow()
        {
            InitializeComponent();
            Product = new Product();

            ProductTypes = DataAccess.GetProductTypes();
            Workshops = DataAccess.GetWorkshops();

            DataContext = this;
        }
        public ProductWindow(Product product)
        {
            InitializeComponent();
            Product = product;

            ProductTypes = DataAccess.GetProductTypes();
            Workshops = DataAccess.GetWorkshops();

            DataContext = this;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.SaveProduct(Product);
            this.Close();
        }
    }
}
