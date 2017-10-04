using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terrasoft.Classes
{
    /// <summary>
    /// если одинаковых символов много, то возвращаю первый попавшийся, без сортировки по алфавиту
    /// так же из условися не понятен критерий частости, то есть для "ааа bbb с" возвращать "aaa" или "ab"
    /// сделал для первого варианта, для второго требуется несложная переделка
    /// так же, например для огромных массивов данных можно применить MapReduce, 
    /// разбить строку на интервалы и подсчитывать символы в нескольких потоках, потом объеденить результат
    /// </summary>
    public class TerrasoftTest
    {
        /// <summary>
        /// с использованием LINQ, так бы и сделал скорее всего в продакшене
        /// </summary>
        /// <param name="str">исходная строка</param>
        /// <param name="whiteSpace">считать ли пробелы</param>
        /// <returns></returns>
        public static IEnumerable<char> First(string str, bool whiteSpace = false)
        {
            if (string.IsNullOrEmpty(str))
                return Enumerable.Empty<char>();
            IEnumerable<char> tmp = str;
            if (!whiteSpace)
                tmp = tmp.Where(x => !char.IsWhiteSpace(x));
            var res = tmp.GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .Take(1)
                .FirstOrDefault();
            if (res == null)
                return Enumerable.Empty<char>();
            return new string(res.Key, res.Count());
        }
        /// <summary>
        /// "Как модифицировать алгоритм, чтобы количество итераций было меньше, чем символов в строке"?
        /// можно за одну итерацию обрабатывать несколько символов, в данном случае ограничился двумя
        /// </summary>
        /// <param name="str">исходная строка</param>
        /// <param name="whiteSpace">считать ли пробелы</param>
        /// <returns></returns>
        public static IEnumerable<char> Second(string str, bool whiteSpace = false)
        {
            if (string.IsNullOrEmpty(str))
                return Enumerable.Empty<char>();
            Dictionary<char, int> dictionary = new Dictionary<char, int>();
            int counter = str.Length - 1;
            while (counter >= 2)
            {
                Increment(dictionary, str[counter]);
                Increment(dictionary, str[counter - 1]);
                counter -= 2;
            }
            if (str.Length % 2 == 1)
            {
                Increment(dictionary, str[counter]);
            }
            IEnumerable<KeyValuePair<char, int>> tmp = dictionary;
            if (!whiteSpace)
                tmp = tmp.Where(x => !char.IsWhiteSpace(x.Key));
            var res = tmp.OrderByDescending(x => x.Value)
                .Take(1);
            if (res.Count() < 1)
                return Enumerable.Empty<char>();
            var kvp = res.First();
            return new string(kvp.Key, kvp.Value);
        }
        private static void Increment(Dictionary<char, int> dictionary, char ch)
        {
            if (dictionary.ContainsKey(ch))
            {
                dictionary[ch]++;
            }
            else
            {
                dictionary[ch] = 1;
            }
        }
        public static int NFib(int n)
        {
            IEnumerable<int> Fib()
            {
                var a = 1;
                var b = 1;
                yield return a;
                yield return b;
                while (true)
                {
                    b = a + (a = b);
                    yield return b;
                }
            }
            return Fib().Skip(n).Take(1).First();
        }
    }
}
