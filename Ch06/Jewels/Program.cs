using System;

namespace Jewels
{
    class Program
    {
        static void Main(string[] args)
        {
            SafeOwner owner = new SafeOwner();
            Safe safe = new Safe();
            JewelThief jewelthief = new JewelThief();
            jewelthief.OpenSafe(safe, owner);
            Console.ReadKey(true);
        }
    }
}
