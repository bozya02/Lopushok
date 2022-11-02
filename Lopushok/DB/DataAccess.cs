using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Lopushok.DB
{
    public static class DataAccess
    {
        public delegate void NewItemAddedDeledate();
        public static event NewItemAddedDeledate NewItemAddedEvent;

        public static List<Product> GetProducts() => LopushokEntities.GetContext().Products.ToList();
        public static List<ProductType> GetProductTypes() => LopushokEntities.GetContext().ProductTypes.ToList();
        public static List<Material> GetMaterials() => LopushokEntities.GetContext().Materials.ToList();
        public static List<MaterialType> GetMaterialTypes() => LopushokEntities.GetContext().MaterialTypes.ToList();
        public static List<Workshop> GetWorkshops() => LopushokEntities.GetContext().Workshops.ToList();

        public static void SaveProduct(Product product)
        {
            if (!GetProducts().Any(x => x == product))
                LopushokEntities.GetContext().Products.Add(product);

            LopushokEntities.GetContext().SaveChanges();
            NewItemAddedEvent?.Invoke();
        }

        public static void DeleteProduct(Product product)
        {
            LopushokEntities.GetContext().Products.Remove(product);

            LopushokEntities.GetContext().SaveChanges();
            NewItemAddedEvent?.Invoke();
        }

        public static void DeleteProductMaterial(ProductMaterial productMaterial)
        {
            LopushokEntities.GetContext().ProductMaterials.Remove(productMaterial);
        }
    }
}
