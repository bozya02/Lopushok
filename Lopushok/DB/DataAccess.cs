using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lopushok.DB
{
    public static class DataAccess
    {
        public static IEnumerable<Product> GetProducts() => LopushokEntities.GetContext().Products;
        public static IEnumerable<ProductType> GetProductTypes() => LopushokEntities.GetContext().ProductTypes;
        public static IEnumerable<Material> GetMaterials() => LopushokEntities.GetContext().Materials;
        public static IEnumerable<MaterialType> GetMaterialTypes() => LopushokEntities.GetContext().MaterialTypes;
        public static IEnumerable<Workshop> GetWorkshops() => LopushokEntities.GetContext().Workshops;

        public static void SaveProduct(Product product)
        {
            if (!GetProducts().Contains(product))
                GetProducts().Append(product);

            LopushokEntities.GetContext().SaveChanges();
        }
    }
}
