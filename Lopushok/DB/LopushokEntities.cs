using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lopushok.DB
{
    public partial class LopushokEntities
    {
        private static LopushokEntities _entities;

        public static LopushokEntities GetContext()
        {
            if (_entities == null)
                _entities = new LopushokEntities();
            return _entities;
        }
    }
}
