using AmazingExtensions;
using System;

namespace ExtensionMethodString
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = "Evil clones are wreaking havoc. Help!";
            if(message.IsDistressCall())
                Console.WriteLine("Distress signal received");
        }
    }
}
