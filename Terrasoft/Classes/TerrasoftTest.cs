using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terrasoft.Classes
{
    public class TerrasoftTest
    {
        /// <summary>
        /// с использованием LINQ, так бы и сделал скорее всего в продакшене
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static IEnumerable<char> First(string str)
        {
            if (string.IsNullOrEmpty(str))
                return Enumerable.Empty<char>();
        }
    }
}
