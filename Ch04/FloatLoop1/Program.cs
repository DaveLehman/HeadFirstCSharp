using System;

namespace FloatLoop1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (float f = 10; float.IsFinite(f); f *= f)
                Console.WriteLine(f);
        }
    }
}
