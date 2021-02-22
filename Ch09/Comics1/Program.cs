using System;
using System.Collections.Generic;
using System.Linq;

namespace Comics1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Use a LINQ query to finish the app
            IEnumerable<Comic> mostExpensive =
                from comic in Comic.Catalog
                where Comic.Prices[comic.Issue] > 500
                orderby -Comic.Prices[comic.Issue]
                select comic;

            foreach(Comic comic in mostExpensive)
            {
                Console.WriteLine($"{comic.Name} is worth {Comic.Prices[comic.Issue]:c}");
            }
            Console.WriteLine("--------------------------------------\n\n");
            // tweaks to do the same thing
            // easy to miss the minus sign in orderby so you can do the same thing with orderby x decending
            // the select clause above selects the comic so the result of the above query is a sequence
            // of comic references. The following does/looks the same but returns a series of strings
            IEnumerable<string> mostExpensive2 =
                from comic in Comic.Catalog
                where Comic.Prices[comic.Issue] > 500
                orderby Comic.Prices[comic.Issue] descending
                select $"{comic.Name} is worth {Comic.Prices[comic.Issue]:c}";
            foreach(string str in mostExpensive2)
            {
                Console.WriteLine(str);
            }

        }
    }
}
