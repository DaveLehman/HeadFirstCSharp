using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace UnicodeExplore
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"F:\terable2\Documents\HeadFirst\C#(4th)1\Ch10\UnicodeExplore\";

            // 1. Write a normal string out to a file and read it back
            File.WriteAllText(path + "eureka.txt", "Eureka!");
            byte[] eurekaBytes = File.ReadAllBytes(path + "eureka.txt");
            Console.WriteLine("eureka.txt as UT-8 chars");
            foreach (byte b in eurekaBytes)
                Console.Write("{0} ", b);
            // converts a byte array with UT8-encoded characters into a string
            Console.WriteLine(Encoding.UTF8.GetString(eurekaBytes));
            Console.WriteLine("---------------------------------------------------");

            // 2. Add code to write the bytes as hex numbers
            Console.WriteLine("eureka.txt as hex numbers");
            foreach (byte b in eurekaBytes)
                Console.Write("{0:x2} ", b);
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------");

            // 3. Write hebrew characters to a file and read it back
            File.WriteAllText(path + "hebrew.txt", "שלום", Encoding.Unicode);
            eurekaBytes = File.ReadAllBytes(path + "hebrew.txt");
            Console.WriteLine("hebrew.txt as hex numbers");
            foreach (byte b in eurekaBytes)
                Console.Write("{0:x2} ", b);
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------");

            // 4. Serialize hebrew character
            Console.WriteLine(JsonSerializer.Serialize("ש"));
            // what gives? returned "\u05E9" -- that's the UTF-8 and the UTF-16 encoding of the character
            // the elephant emoji was 0x1F418 in UTF-8 but 0xD83D in UTF-8 and 0xD8ED 0xDC18 in UT-16
            // Turns out once you reach UTF-8 values that require 3 or more bytes, they will differ
            // 5. Write Elephant emoji
            // with UTF-16 escape sequence
            File.WriteAllText(path + "elephant1.txt", "\uD83D\uDC18");
            // with UTF-32 escape sequence
            File.WriteAllText(path + "elephant2.txt", "\U0001F418");
        }
    }
}
