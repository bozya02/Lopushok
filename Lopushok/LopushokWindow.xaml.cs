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

            ProductsList.ItemsSource = Products.Skip((PageNumber - 1) * 20).Take(20);

            ProductsList.Items.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
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
            if (cbSort.SelectedItem.ToString() == "Номер цеха по возрастанию")
                ProductsList.Items.SortDescriptions[0] = new SortDescription("WorkshopId", ListSortDirection.Ascending);
            else if (cbSort.SelectedItem.ToString() == "Номер цеха по убыванию")
                ProductsList.Items.SortDescriptions[0] = new SortDescription("WorkshopId", ListSortDirection.Descending);
            else if (cbSort.SelectedItem.ToString() == "Минимальная стоимость по возрастанию")
                ProductsList.Items.SortDescriptions[0] = new SortDescription("MinPrice", ListSortDirection.Ascending);
            else if (cbSort.SelectedItem.ToString() == "Минимальная стоимость по убыванию")
                ProductsList.Items.SortDescriptions[0] = new SortDescription("MinPrice", ListSortDirection.Descending);
            else if (cbSort.SelectedItem.ToString() == "Наименование по возрастанию")
                ProductsList.Items.SortDescriptions[0] = new SortDescription("Name", ListSortDirection.Ascending);
            else
                ProductsList.Items.SortDescriptions[0] = new SortDescription("Name", ListSortDirection.Descending);
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
            var window = new Windows.ProductWindow(ProductsList.SelectedItem as Product);
            window.ShowDialog();
        }
    }
}
