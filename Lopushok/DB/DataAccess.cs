using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lopushok.DB
{
    public static class DataAccess
    {
        public delegate void NewItemAddedDelegate();

        public static event NewItemAddedDelegate NewItemAddedEvent;
        public static List<Product> GetProducts() => LopushokEntities.GetContext().Products.ToList();
        public static List<ProductType> GetProductTypes() => LopushokEntities.GetContext().ProductTypes.ToList();
        public static List<Material> GetMaterials() => LopushokEntities.GetContext().Materials.ToList();
        public static List<MaterialType> GetMaterialTypes() => LopushokEntities.GetContext().MaterialTypes.ToList();
        public static List<Workshop> GetWorkshops() => LopushokEntities.GetContext().Workshops.ToList();

        public static void SaveProduct(Product product)
        {
            if (!GetProducts().Contains(product))
                LopushokEntities.GetContext().Products.Add(product);

            LopushokEntities.GetContext().SaveChanges();
            NewItemAddedEvent.Invoke();
        }
        public static void DeleteProduct(Product product)
        {
            LopushokEntities.GetContext().Products.Remove(product);

            LopushokEntities.GetContext().SaveChanges();
            NewItemAddedEvent.Invoke();
        }

        internal static void RemoveProductMaterial(ProductMaterial material)
        {
            LopushokEntities.GetContext().ProductMaterials.Remove(material);

            LopushokEntities.GetContext().SaveChanges();
        }
    }
}
