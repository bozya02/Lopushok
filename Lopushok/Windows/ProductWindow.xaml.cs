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
using Lopushok.DB;
using Microsoft.Win32;

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

        public ProductWindow()
        {
            InitializeComponent();
            Product = new Product();

            ProductTypes = DataAccess.GetProductTypes();
            Workshops = DataAccess.GetWorkshops();
            Materials = DataAccess.GetMaterials();

            DataContext = this;
        }
        public ProductWindow(Product product)
        {
            InitializeComponent();
            Product = product;

            ProductTypes = DataAccess.GetProductTypes();
            Workshops = DataAccess.GetWorkshops();
            Materials = DataAccess.GetMaterials();

            DataContext = this;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.SaveProduct(Product);
            this.Close();
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
            var materials = ProductMaterialsList.Items.Cast<Material>().ToList();
            var material = MaterialsComboBox.SelectedItem as Material;

            if (materials.Where(c => c.Name == material.Name).Count() != 0)
                return;
            materials.Add(material);

            ProductMaterialsList.ItemsSource = materials;
        }

        private void ProductMaterialsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var materials = ProductMaterialsList.Items.Cast<Material>().ToList();
            var material = ProductMaterialsList.SelectedItem as Material;
            materials.Remove(material);

            ProductMaterialsList.ItemsSource = materials;
        }
    }
}
