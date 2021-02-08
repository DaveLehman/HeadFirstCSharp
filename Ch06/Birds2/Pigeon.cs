using System;
using System.Collections.Generic;
using System.Text;

namespace Birds2
{
    class Pigeon : Bird
    {
        public override Egg[] LayEggs(int numberOfEggs)
        {
            Egg[] pigeonEggs = new Egg[numberOfEggs];

            for (int i = 0; i < numberOfEggs; i++)
            {
                if (Randomizer.Next(4) == 0)
                {
                    pigeonEggs[i] = new BrokenEgg( "white");
                }
                else
                {
                    pigeonEggs[i] = new Egg((double)(1 + Randomizer.NextDouble() * 2), "white");
                }
                
            }
            return pigeonEggs;
        }
    }
}
