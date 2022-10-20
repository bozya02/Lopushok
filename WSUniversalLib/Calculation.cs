using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace WSUniversalLib
{
    public class Calculation
    {
        private Dictionary<int, double> ProductTypeCoef = new Dictionary<int, double>
        {
            { 1, 1.1 },
            { 2, 2.5 },
            { 3, 8.43 }
        };

        private Dictionary<int, double> RejectPercent = new Dictionary<int, double>
        {
            { 1, 0.003 },
            { 2, 0.0012 }
        };

        public int GetQuantityForProduct(int productType, int materialType, int count, float width, float length)
        {
            if (!ProductTypeCoef.Keys.Contains(productType) || !RejectPercent.Keys.Contains(materialType))
                return -1;
            return (int)Math.Ceiling(width * length * count * ProductTypeCoef[productType] * (1 + RejectPercent[materialType]));
        }
    }
}
