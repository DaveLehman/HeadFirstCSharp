using System;
using System.IO;

namespace HexDumper
{
    class Program
    {
        static void Main(string[] args)
        {
            var position = 0;
            using (var reader = new StreamReader(@"F:\terable2\Documents\HeadFirst\C#(4th)1\Ch10\HexDumper\samplefile.txt") )
            {
                // there's a problem with this hex dumper -- it only works with text files because StreamReader is built to read
                // text files, and it only reads 7-bit values
                while(!reader.EndOfStream)
                {
                    // Read up to the next 16 bytes into a byte array
                    var buffer = new char[16];
                    var bytesRead = reader.ReadBlock(buffer, 0, 16);

                    // Write the position in hex, followed by a colon and a space
                    Console.Write("{0:x4}: ", position);
                    position += bytesRead;

                    // Write the hex value of each character to the byte array
                    for (var i = 0; i < 16; i++)
                    {
                        if (i < bytesRead)
                            Console.Write("{0:x2} ", (byte)buffer[i]);
                        else
                            Console.Write("    ");
                        if (i == 7) Console.Write("-- ");
                    }

                    // Write the actual characters in the byte array
                    var bufferContents = new string(buffer);
                    Console.WriteLine("    {0}", bufferContents.Substring(0, bytesRead));
                }
            }
        }
    }
}
