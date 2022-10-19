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
        public ProductPage(Product product)
        {
            InitializeComponent();

            Product = product;
            Workshops = DataAccess.GetWorkshops();
            ProductTypes = DataAccess.GetProductTypes();
            Materials = DataAccess.GetMaterials();

            Title = Product.Name;
            this.DataContext = this;
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
            var material = lvMaterials.SelectedItem as ProductMaterial;

            Product.ProductMaterials.Remove(material);

            lvMaterials.ItemsSource = Product.ProductMaterials;
            lvMaterials.Items.Refresh();
        }
    }
}
