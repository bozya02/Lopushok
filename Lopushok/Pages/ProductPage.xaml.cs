﻿using Lopushok.DB;
using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lopushok.Pages
{
    /// <summary>
    /// Interaction logic for ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public Product Product { get; set; }

        public List<Workshop> Workshops { get; set; }
        public List<ProductType> ProductTypes { get; set; }
        public List<Material> Materials{ get; set; }
        public ProductPage(Product product, bool isNewProduct = false)
        {
            InitializeComponent();

            Product = product;
            Workshops = DataAccess.GetWorkshops();
            ProductTypes = DataAccess.GetProductTypes();
            Materials = DataAccess.GetMaterials();

            Title = Product.Name;

            if (isNewProduct)
            {
                Title = "Новый продукт";
                btnDelete.Visibility = Visibility.Hidden;
            }

            this.DataContext = this;

            if (product.ProductSales != null)
                btnDelete.Visibility = Visibility.Hidden;
        }

        private void cbMaterial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var material = cbMaterial.SelectedItem as Material;
            if (material == null || Product.ProductMaterials.Any(x => x.Material == material))
                return;

            Product.ProductMaterials.Add(new ProductMaterial() { Product = Product, Material = material });

            lvMaterials.ItemsSource = Product.ProductMaterials;
            lvMaterials.Items.Refresh();
        }

        private void lvMaterials_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var material = lvMaterials.SelectedItem as ProductMaterial;
                if (material == null)
                    return;
                var result = MessageBox.Show("Вы точно хотите удалить материал?", "Предупреждение", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                if (result != MessageBoxResult.Yes)
                    return;
                Product.ProductMaterials.Remove(material);
                DataAccess.DeleteProductMaterial(material);

                lvMaterials.ItemsSource = Product.ProductMaterials;
                lvMaterials.Items.Refresh();
            }
            catch { }
            
        }

        private void btnAddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg"
            };

            if (fileDialog.ShowDialog().Value)
            {
                var image = File.ReadAllBytes(fileDialog.FileName);
                Product.Image = image;

                imgProduct.Source = new BitmapImage(new Uri(fileDialog.FileName));
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (IsArticleUnique())
            {
                MessageBox.Show("Артикул не уникален", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                DataAccess.SaveProduct(Product);
            }
            catch
            {
                MessageBox.Show("Введены некорректные значения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DataAccess.SaveProduct(Product);
            NavigationService.GoBack();
        }

        public bool IsArticleUnique()
        {
            return DataAccess.GetProducts().Any(product => product == Product && product.Article != Product.Article);
        }

        private void cbMaterial_TextChanged(object sender, TextChangedEventArgs e)
        {
            cbMaterial.ItemsSource = Materials.FindAll(material => material.Name.ToLower().Contains(cbMaterial.Text.ToLower()));
            cbMaterial.IsDropDownOpen = true;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы точно хотите удалить данный продукт?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
                return;
            DataAccess.DeleteProduct(Product);
            NavigationService.GoBack();
        }
    }
}
