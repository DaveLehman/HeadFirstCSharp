using System;
using System.Collections.Generic;
using System.Text;

namespace Birds2
{
    class Ostrich : Bird
    {
        public override Egg[] LayEggs(int numberOfEggs)
        {
            Egg[] ostrichEggs = new Egg[numberOfEggs];

            for (int i = 0; i < numberOfEggs; i++)
            {
                ostrichEggs[i] = new Egg((double)(12 + Randomizer.NextDouble()), "speckled");
            }
            return ostrichEggs;
        }
    }
}
