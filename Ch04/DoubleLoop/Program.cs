using System;

namespace DoubleLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            for (double d = 10; double.IsFinite(d); d *= d)
                Console.WriteLine(d);
        }
    }
}
