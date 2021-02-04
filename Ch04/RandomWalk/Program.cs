using System;

namespace RandomWalk
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int randomInt = random.Next();
            Console.WriteLine("A generic random integer: " + randomInt);

            int zeroToNine = random.Next(10);
            Console.WriteLine("An integer between 0 and 9: " + zeroToNine);

            int dieRoll = random.Next(1, 7);
            Console.WriteLine("Simulated die roll 1-6: " + dieRoll);

            double randomDouble = random.NextDouble();
            Console.WriteLine("A generic random double: " + randomDouble);

            // can multiply a random double 
            double percentile = (random.NextDouble() * 100);
            Console.WriteLine("A double from 1 to 100: " + percentile);

            Console.WriteLine("Random double cast to float*100: " + (float)randomDouble * 100F);
            Console.WriteLine("Random double cast to decimal*100: " + (decimal)randomDouble * 100M);

            int zeroOrOne = random.Next(2);
            bool coinFlip = Convert.ToBoolean(zeroOrOne);
            Console.WriteLine("Coin flip simulation: " + coinFlip);
        }
    }
}
