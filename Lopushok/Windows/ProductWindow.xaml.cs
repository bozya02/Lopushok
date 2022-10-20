using System;
using System.Collections.Generic;
using System.IO;
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
using System.Text.RegularExpressions;
using Lopushok.DB;
using Microsoft.Win32;
using System.Globalization;
using System.Threading;

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
        public List<Material> Materials { get; set; }
        public List<Material> ProductMaterials { get; set; }

        public ProductWindow(Product product)
        {
            InitializeComponent();
            Product = product;

            ProductTypes = DataAccess.GetProductTypes();
            Workshops = DataAccess.GetWorkshops();
            Materials = DataAccess.GetMaterials();

            ProductMaterials = Product.ProductMaterials.Select(x => x.Material).ToList();

            DataContext = this;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataAccess.SaveProduct(Product);
                Close();
            }
            catch
            {
                MessageBox.Show("Невозможно сохранить изменения", "Данные заолнены некорректно");
            }
        }

        private void SelectImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg"
            };

            if (fileDialog.ShowDialog().Value)
            {
                var photo = File.ReadAllBytes(fileDialog.FileName);
                if (photo.Length > 1024 * 150)  //Размер фотографии не должен превышать 150 Кбайт
                {
                    MessageBox.Show("Размер фотографии не должен превышать 150 КБ", "Ошибка");
                    return;
                }
                Product.Image = photo;
                ProductImage.Source = new BitmapImage(new Uri(fileDialog.FileName));
            }
        }

        private void MaterialsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var material = MaterialsComboBox.SelectedItem as Material;

            if (material == null || Product.ProductMaterials.Where(c => c.Material.Name == material.Name).Count() != 0)
                return;

            var productMaterial = new ProductMaterial { Product = Product, Material = material, MaterialQuantity = 0 };

            if((bool)new MaterialCountWindow(productMaterial).ShowDialog()) 
            {
                Product.ProductMaterials.Add(productMaterial);
                ProductMaterialsList.ItemsSource = Product.ProductMaterials;
                ProductMaterialsList.Items.Refresh();
            }
        }

        private void ProductMaterialsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var material = ProductMaterialsList.SelectedItem as ProductMaterial;
            Product.ProductMaterials.Remove(material);

            ProductMaterialsList.ItemsSource = Product.ProductMaterials;
            ProductMaterialsList.Items.Refresh();
        }

        private void ManForProductionTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void MaterialsComboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            MaterialsComboBox.ItemsSource = Materials.Where(material => material.Name.ToLower().Contains(MaterialsComboBox.Text.ToLower())).ToList();
            MaterialsComboBox.IsDropDownOpen = true;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(MessageBox.Show("Удалить данный продукт?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    DataAccess.DeleteProduct(Product);
                    Close();
                }
            }
            catch
            {
                MessageBox.Show("Невозможно сохранить изменения", "Данные заолнены некорректно");
            }
        }
    }
}
