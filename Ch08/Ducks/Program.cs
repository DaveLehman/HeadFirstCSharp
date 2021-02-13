using System;
using System.Collections.Generic;

namespace Ducks
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Duck> ducks = new List<Duck>()
            {
                new Duck() { Kind = KindOfDuck.Mallard, Size = 17 },
                new Duck() { Kind = KindOfDuck.Muscovy, Size = 18 },
                new Duck() { Kind = KindOfDuck.Loon, Size = 14 },
                new Duck() { Kind = KindOfDuck.Muscovy, Size = 11 },
                new Duck() { Kind = KindOfDuck.Mallard, Size = 14 },
                new Duck() { Kind = KindOfDuck.Loon, Size = 13 },
            };
            Console.WriteLine("Sorting ducks by CompareTo");
            ducks.Sort();   // uses Ducks.CompareTo
            PrintDucks(ducks);
            IComparer<Duck> KindComparer = new DuckComparerByKind();
            Console.WriteLine("Sorting ducks using a DuckComparerByKind");
            ducks.Sort(KindComparer);
            PrintDucks(ducks);
            IComparer<Duck> SizeComparer = new DuckComparerBySize();
            Console.WriteLine("Sorting ducks using a DuckComparerBySize");
            ducks.Sort(SizeComparer);
            PrintDucks(ducks);
            DuckComparer comparer = new DuckComparer();
            comparer.SortBy = SortCriteria.KindThenSize;
            Console.WriteLine("\nSorting by kind then size\n");
            ducks.Sort(comparer);
            PrintDucks(ducks);
            comparer.SortBy = SortCriteria.SizeThenKind;
            Console.WriteLine("\nSorting by size then kind\n");
            ducks.Sort(comparer);
            PrintDucks(ducks);

        }

        public static void PrintDucks(List<Duck> ducks)
        {
            foreach (Duck duck in ducks)
            {
                Console.WriteLine($"{duck.Size} inch {duck.Kind}");
            }
        }
    }
}
