using System;
using System.Collections.Generic;
using System.Linq;

namespace LazyEvaluation
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfObjects = new List<PrintWhenGetting>();
            for(int i = 1; i <= 5; i++)
                listOfObjects.Add(new PrintWhenGetting() { InstanceNumber = i } );
            Console.WriteLine("Set up the query");
            var result =
                from o in listOfObjects
                select o.InstanceNumber;
            Console.WriteLine("run the foreach");
            // The LINQ query doesn't get executed until here at the foreach, so you see 'set up the query' printing before the getters
            foreach (var number in result)
                Console.WriteLine($"Writing #{number}");

            Console.WriteLine("----------------------------------------------------");
            // to force immediate execution do something like this
            var listOfObjects2 = new List<PrintWhenGetting>();
            for (int i = 1; i <= 5; i++)
                listOfObjects2.Add(new PrintWhenGetting() { InstanceNumber = i });
            Console.WriteLine("Set up the query");
            var result2 =
                from o in listOfObjects
                select o.InstanceNumber;
            var immediate = result.ToList();    // ToList forces an enumeration before the foreach as would math
                                                // like sum, average, etc
            Console.WriteLine("run the foreach");
            foreach (var number in immediate)
                Console.WriteLine($"Writing #{number}");
        }
    }
}
