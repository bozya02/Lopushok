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
        public Dictionary<string, Func<Product, object>> Sortings { get; set; }


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
            

            ProductTypes = DataAccess.GetProductTypes();

            ProductsList.ItemsSource = Products.Skip((PageNumber - 1) * 20).Take(20);
            ProductTypes.Insert(0, new ProductType { Name = "Все типы" });

            PageNumberText = string.Join<string>(" ", Enumerable.Range(1, (int)(Products.Count / 20)).Select(x => x.ToString()));
            for (int i = 0; i < Products.Count / 20; i++)
            {
                var hyperlink = new Hyperlink() { Foreground = new SolidColorBrush(Colors.Black),
                    FontSize = 25,
                    TextDecorations = null};
                hyperlink.Inlines.Add($"{i + 1}");
                hyperlink.Click += NavigateToPage;

                var textBlock = new TextBlock();
                textBlock.Inlines.Add(hyperlink);

                PageNumbersPanel.Children.Add(textBlock);
            }

            DataContext = this;
        }
        private void ApplyFilters()
        {
            var filter = FilterComboBox.SelectedItem as ProductType;
            var sorting = Sortings[SortingComboBox.SelectedItem as string];
            var text = SearchBox.Text;
            //page
        }
        private void NavigateToPage(object sender, RoutedEventArgs e)
        {
            PageNumber = int.Parse(((sender as Hyperlink).Inlines.FirstOrDefault() as Run).Text);
            ProductsList.ItemsSource = Products.Skip((PageNumber - 1) * 20).Take(20);
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ProductsList.ItemsSource = Products.Where(product => product.Name.ToLower().Contains(SearchBox.Text.ToLower()));
        }

        private void SortingComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try 
            {
                var products = ProductsList.ItemsSource.Cast<Product>();
                var sort = SortingComboBox.SelectedItem.ToString();
                products = products.OrderBy(Sortings[sort]).ToList();
                if (sort.Contains("убыванию"))
                    products = products.Reverse();

                ProductsList.ItemsSource = products;
            }
            catch { }
        }

        private void FilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var productType = FilterComboBox.SelectedItem as ProductType;
            if (productType.Name != "Все типы")
                ProductsList.ItemsSource = ProductsList.ItemsSource.Cast<Product>().Where(product => product.ProductType == productType);

        }

        private void PreviousPageButton_Click(object sender, RoutedEventArgs e)
        {
            if (PageNumber > 1)
            {
                PageNumber--;
                ProductsList.ItemsSource = Products.Skip((PageNumber - 1) * 20).Take(20);
                //PageNumberTextBlock.Text = PageNumber.ToString();
            }

        }

        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {
            if (PageNumber < Products.Count / 20)
            {
                PageNumber++;
                ProductsList.ItemsSource = Products.Skip((PageNumber - 1) * 20).Take(20);
                //PageNumberTextBlock.Text = PageNumber.ToString();
            }
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new Windows.ProductWindow();
            window.ShowDialog();
        }

        private void ProductsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductsList.SelectedItem is Product product)
                new Windows.ProductWindow(product).ShowDialog();
        }
    }
}
