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
        public List<Product> ProductsForSearch { get; set; }
        public string Name { get; set; }

        public int PageNumber { get; set; } = 1; 

        public List<string> SortTypes { get; set; }
        public List<ProductType> ProductTypes  { get; set; }
        public Dictionary<string, Func<Product, object>> Sortings { get; set; }


        public LopushokWindow()
        {
            InitializeComponent();
            Products = DataAccess.GetProducts();
            ProductsForSearch = Products.ToList();

            ProductTypes = DataAccess.GetProductTypes();
            ProductTypes.Insert(0, new ProductType { Name = "Все типы" });
            
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

            ProductsList.ItemsSource = Products.Skip((PageNumber - 1) * 20).Take(20);

            DataContext = this;
        }

        private void SetPageNumbers()
        {
            PageNumbersPanel.Children.Clear();
            int pagesCount = ProductsForSearch.Count % 20 == 0 ? ProductsForSearch.Count / 20 : ProductsForSearch.Count / 20 + 1;
            for (int i = 0; i < pagesCount; i++)
            {
                var hyperlink = new Hyperlink()
                {
                    Foreground = new SolidColorBrush(Colors.Black),
                    FontSize = 25,
                    TextDecorations = null
                };
                hyperlink.Inlines.Add($"{i + 1}");
                hyperlink.Click += NavigateToPage;

                var textBlock = new TextBlock() { Margin = new Thickness(5, 0, 5, 0)};
                textBlock.Inlines.Add(hyperlink);

                PageNumbersPanel.Children.Add(textBlock);
            }
        }

        private void ApplyFilters(bool filtersChanged)
        {
            var filter = FilterComboBox.SelectedItem as ProductType;
            var sorting = Sortings[SortingComboBox.SelectedItem as string];
            var text = SearchBox.Text.ToLower();
            if (filtersChanged)
                PageNumber = 1;

            if (filter != null && sorting != null)
            {
                if (filter.Name != "Все типы")
                    ProductsForSearch = Products.Where(x => x.ProductType == filter).ToList();
                else
                    ProductsForSearch = Products;

                ProductsForSearch = ProductsForSearch.OrderBy(sorting).ToList();
                if ((SortingComboBox.SelectedItem as string).Contains("убыванию"))
                    ProductsForSearch.Reverse();

                ProductsForSearch = ProductsForSearch.Where(product => product.Name.ToLower().Contains(text)).ToList();

                ProductsList.ItemsSource = ProductsForSearch.Skip((PageNumber - 1) * 20).Take(20).ToList();
            }
            SetPageNumbers();
        }
        private void NavigateToPage(object sender, RoutedEventArgs e)
        {
            PageNumber = int.Parse(((sender as Hyperlink).Inlines.FirstOrDefault() as Run).Text);
            ApplyFilters(false);
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilters(true);
        }

        private void SortingComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters(true);
        }

        private void FilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters(true);
        }

        private void PreviousPageButton_Click(object sender, RoutedEventArgs e)
        {
            if (PageNumber > 1)
            {
                PageNumber--;
                ApplyFilters(false);
            }
        }

        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {
            if (PageNumber < ProductsForSearch.Count / 20)
            {
                PageNumber++;
                ApplyFilters(false);
            }
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            new Windows.ProductWindow(new Product()).ShowDialog();
        }

        private void ProductsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductsList.SelectedItem is Product product)
                new Windows.ProductWindow(product).ShowDialog();
        }
    }
}
