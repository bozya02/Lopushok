using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSUniversalLib
{
    public class Calculation
    {
        private Dictionary<int, double> coefficients =
        new Dictionary<int, double>
        {
            { 1 , 1.1 },
            { 2 , 2.5 },
            { 3 , 8.43 },
        };

        private Dictionary<int, double> percents =
        new Dictionary<int, double>
        {
            { 1 , 0.3 * 0.01 },
            { 2 , 0.12 * 0.01 },
        };

        public int GetQuantityForProduct(int productType, int materialType, int count, float width, float length)
        {
            try 
            {
                return (int)Math.Ceiling((double)((count * coefficients[productType] * width * length) * (1 + percents[materialType]))); 
            }
            catch
            {
                return -1;
            }
        }
    }
}
