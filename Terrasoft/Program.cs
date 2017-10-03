using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terrasoft
{
    class Program
    {
        static string[] arr = { "ааа bbb с", "а, b", "ааа bb с", "а", "а, b, с", "а b с" };
        static void Main(string[] args)
        {
            foreach(var str in arr)
            {
                //Console.WriteLine("First");
                //var en = Classes.TerrasoftTest.First(str);
                //PrintEnumerable(en);
                //Console.WriteLine("Second");
                var en = Classes.TerrasoftTest.Second(str);
                PrintEnumerable(en);
            }
            Console.ReadLine();
        }
        static void PrintEnumerable<T>(IEnumerable<T> src)
        {
            foreach (var t in src)
                Console.Write(t);
            Console.WriteLine();
        }
    }
}
