using System;
using System.IO;

namespace BinaryWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            // A BinaryWriter automatically encodes your data and writes it to a file
            int intValue = 48769414;
            string stringValue = "Hello!";
            byte[] byteArray = { 47, 129, 0, 116 };
            float floatValue = 491.695F;
            char charValue = 'E';

            using (var output = File.Create(@"F:\terable2\Documents\HeadFirst\C#(4th)1\Ch10\BinaryWriterbinarydata.dat"))
            using (var writer = new System.IO.BinaryWriter(output))
            {
                writer.Write(intValue);
                writer.Write(stringValue);
                writer.Write(byteArray);
                writer.Write(floatValue);
                writer.Write(charValue);
            }

            // hex dump of what was written
            byte[] dataWritten = File.ReadAllBytes(@"F:\terable2\Documents\HeadFirst\C#(4th)1\Ch10\BinaryWriter\binarydata.dat");
            foreach(byte b in dataWritten)
            {
                Console.Write("{0:x2} ", b);
                
            }
            Console.WriteLine(" - {0} bytes", dataWritten.Length);

            // A BinaryReader can recapture the variables as variables
            using (var input = File.OpenRead(@"F:\terable2\Documents\HeadFirst\C#(4th)1\Ch10\BinaryWriter\binarydata.dat"))
            using (var reader = new BinaryReader(input))
            {
                int intRead = reader.ReadInt32();
                string stringRead = reader.ReadString();
                byte[] byteArrayRead = reader.ReadBytes(4);
                float floatRead = reader.ReadSingle();
                char charRead = reader.ReadChar();

                Console.Write("int: {0} string: {1} bytes: ", intRead, stringRead);
                foreach (byte b in byteArrayRead)
                    Console.Write("{0} ", b);
                Console.Write(" float: {0} char: {1} ", floatRead, charRead);
            }

            


        }
    }
}
