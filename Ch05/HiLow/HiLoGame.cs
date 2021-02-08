using System;
using System.Collections.Generic;
using System.Text;

namespace HiLow
{
    static class HiLoGame
    {
        public const int MAXIMUM = 10;
        private static readonly Random random = new Random();
        private static int currentNumber = random.Next(1, MAXIMUM + 1);
        private static int pot = 10;

        internal static void Hint()
        {
            int half = MAXIMUM / 2;
            if(currentNumber >= half)
            {
                Console.WriteLine($"The number is at least {half} ");
            }
            else
            {
                Console.WriteLine($"The number is at most {half} ");
            }
            pot--;
        }

        internal static int GetPot()
        {
            return pot;
        }



        static public void Guess(bool higher)
        {
            int nextNumber = random.Next(1, MAXIMUM + 1);
            if (((nextNumber >= currentNumber) && (higher == true)) ||
                ((nextNumber <= currentNumber) && (higher == false)))
            {
                Console.WriteLine("You guessed right!");
                pot++;
            }
            else
            {
                Console.WriteLine("Bad luck, you guessed wrong.");
                pot--;
            }
            currentNumber = nextNumber;
        }
    }
}
