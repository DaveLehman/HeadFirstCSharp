using System;

namespace Cards1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int numberBetween0and3 = random.Next(4);
            int numberBetween1and13 = random.Next(1, 14);
            int anyRandomInteger = random.Next();
            Console.WriteLine($"Random numbers generated 0-3: {numberBetween0and3} 1-13: {numberBetween1and13} generic: {anyRandomInteger}");
            Console.WriteLine("Creating card...");
            Card newCard = new Card((Values)numberBetween1and13, (Suits)numberBetween0and3);
            Console.WriteLine("New card is "+ newCard.Name);
        }
    }
}
