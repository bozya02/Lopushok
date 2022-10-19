using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Lopushok.DB
{
    public partial class Product
    {
        public string Materials => string.Join(", ", ProductMaterials.Select(x => x.Material.Name));

        public SolidColorBrush Color => (ProductSales.Any(x => x.Sale.Date.Value.Month == DateTime.Today.Month) ?
                    new SolidColorBrush(Colors.Transparent) : new SolidColorBrush(Colors.LightCoral));
    }
}
