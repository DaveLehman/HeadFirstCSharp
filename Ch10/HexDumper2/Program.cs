using System;
using System.IO;
using System.Text;

namespace HexDumper2
{
    class Program
    {
        static void Main(string[] args)
        {
            var position = 0;
            using (Stream input = File.OpenRead(@"F:\terable2\Documents\HeadFirst\C#(4th)1\Ch10\HexDumper2\binarydata.dat"))
            {
                var buffer = new byte[16];
                while (position < input.Length)
                {
                    // Read up to the next 16 bytes into a byte array
                    var bytesRead = input.Read(buffer, 0, buffer.Length);

                    // Write the position in hex, followed by a colon and a space
                    Console.Write("{0:x4}: ", position);
                    position += bytesRead;

                    // Write the hex value of each character to the byte array
                    for (var i = 0; i < 16; i++)
                    {
                        if (i < bytesRead)
                            Console.Write("{0:x2} ", (byte)buffer[i]);
                        else
                            Console.Write("   ");
                        if (i == 7) Console.Write("-- ");
                        if (buffer[i] < 0x20 || buffer[i] > 0x7F)
                            // if non-printable char, replace the value with a dot
                            buffer[i] = (byte)'.';
                    }

                    // Write the actual characters in the byte array
                    var bufferContents = Encoding.UTF8.GetString(buffer);
                    Console.WriteLine("    {0}", bufferContents.Substring(0, bytesRead));
                }
            }
        }
    }
}
