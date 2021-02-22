using System;

namespace EnumerableSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            var sports = new ManualSportsSequence();
            foreach (var sport in sports)
                Console.WriteLine(sport);
        }
    }
}
