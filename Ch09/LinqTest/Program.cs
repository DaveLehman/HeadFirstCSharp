using System;

using System.Linq;
using System.Collections.Generic;

namespace LinqTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            for(int i = 1; i <= 99; i++)
            {
                numbers.Add(i);
            }
            // Any sequence you can Enumerate through is a candidate for using Linq
            IEnumerable<int> firstAndLastFive = numbers.Take(5).Concat(numbers.TakeLast(5));
            foreach(int i in firstAndLastFive)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine("\n\n\n");
            // queries can use a syntax similar to to foreach to iterate
            // start with a sequence (array)
            // clause 1 - declare a range variable
            // clause 2 - include only certain values
            // clause 3 - order the elements
            // clause 4 - select the final results
            int[] values = new int[] { 0, 12, 44, 36, 92, 54, 13, 8 };
            IEnumerable<int> result =
                from v in values
                where v < 37
                orderby -v
                select v;
            foreach (int i in result)
                Console.Write($"{i} ");
        }
    }
}
