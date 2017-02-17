using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extentions
{
    public static class ExtensionMethods
    {
        public static string ToPhilippineCurrency(this decimal value)
        {
            return String.Format("P{0:n}", value);
        }
    }
}
