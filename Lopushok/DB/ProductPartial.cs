using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lopushok.DB
{
    public partial class Product
    {
        public string Materials
        {
            get
            {
                return string.Join(", ",ProductMaterials.Select(x => x.Material.Name));
            }
            set {}
        }
    }
}
