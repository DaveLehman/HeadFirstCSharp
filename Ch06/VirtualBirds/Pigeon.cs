using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualBirds
{
    class Pigeon : Bird
    {          
        public override Egg[] LayEggs(int numberOfEggs)
        {
            Egg[] pigeonEggs = new Egg[numberOfEggs];

            for (int i = 0; i < numberOfEggs; i++)
            {
                pigeonEggs[i] = new Egg((double)(1 + Randomizer.NextDouble()*2), "white");
            }
            return pigeonEggs;
        }
    }
}
