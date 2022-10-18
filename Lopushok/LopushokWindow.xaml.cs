using Lopushok.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public int PageNumber { get; set; } = 1; 
        public string PageNumberText { get; set; }

        public List<string> SortTypes { get; set; }
        public List<ProductType> ProductTypes  { get; set; }
        private Dictionary<string, Func<Product, object>> Sortings;


        public LopushokWindow()
        {
            InitializeComponent();
            Products = DataAccess.GetProducts();

            Sortings = new Dictionary<string, Func<Product, object>>
            {
                { "Без сортировки", x => x.Id },
                { "Минимальная стоимость по убыванию", x => x.MinPrice },//reverse
                { "Минимальная стоимость по возрастанию", x => x.MinPrice },
                { "Номер цеха по убыванию", x => x.WorkshopId },//reverse
                { "Номер цеха по возрастанию", x => x.WorkshopId },
                { "Наименование по возрастанию", x => x.Name },
                { "Наименование по убыванию", x => x.Name } //reverse
            };
            cbSort.ItemsSource = Sortings.Keys;

            ProductTypes = DataAccess.GetProductTypes();

            ProductsList.ItemsSource = Products.Skip((PageNumber - 1) * 20).Take(20);
            ProductTypes.Insert(0, new ProductType { Name = "Все типы" });

            PageNumberText = string.Join<string>(" ", Enumerable.Range(1, (int)(Products.Count / 20)).Select(x => x.ToString()));

            var t = new StackPanel { Children = { new Button { Content = "1",  } } };

            DataContext = this;
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ProductsList.ItemsSource = Products.Where(product => product.Name.ToLower().Contains(SearchBox.Text.ToLower()));
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var products = ProductsList.ItemsSource.Cast<Product>();
            var sort = cbSort.SelectedItem.ToString();
            products = products.OrderBy(Sortings[sort]).ToList();
            if (sort.Contains("убыванию"))
                products = products.Reverse();

            ProductsList.ItemsSource = products;

        }

        private void cbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PreviousPageButton_Click(object sender, RoutedEventArgs e)
        {
            if (PageNumber > 1)
            {
                PageNumber--;
                ProductsList.ItemsSource = Products.Skip((PageNumber - 1) * 20).Take(20);
                PageNumberTextBlock.Text = PageNumber.ToString();
            }

        }

        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {
            if (PageNumber < Products.Count / 20)
            {
                PageNumber++;
                ProductsList.ItemsSource = Products.Skip((PageNumber - 1) * 20).Take(20);
                PageNumberTextBlock.Text = PageNumber.ToString();
            }
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new Windows.ProductWindow();
            window.ShowDialog();
        }

        private void ProductsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try 
            {
                var window = new Windows.ProductWindow(ProductsList.SelectedItem as Product);
                window.ShowDialog();
            }
            catch { }
        }
    }
}
