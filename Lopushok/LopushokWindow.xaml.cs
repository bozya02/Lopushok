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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Lopushok
{
    /// <summary>
    /// Interaction logic for LopushokWindow.xaml
    /// </summary>
    public partial class LopushokWindow : Window
    {
        public List<Product> Products { get; set; }
        public string Name { get; set; }

        public List<string> SortTypes { get; set; }
        public List<ProductType> ProductTypes  { get; set; }

        public LopushokWindow()
        {
            InitializeComponent();
            Products = DataAccess.GetProducts();

            SortTypes = new List<string> 
            {
                "Без сортировки",
                "Наименование по убыванию", "Наименование по возрастанию",
                "Номер цеха по убыванию",   "Номер цеха по возрастанию", 
                "Минимальная стоимость по убыванию", "Минимальная стоимость по возрастанию"
            };
            ProductTypes = DataAccess.GetProductTypes();
            ProductTypes.Insert(0, new ProductType { Name = "Все типы" });
            DataContext = this;
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ProductsList.ItemsSource = Products.Where(product => product.Name.ToLower().Contains(SearchBox.Text.ToLower()));
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void cbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
