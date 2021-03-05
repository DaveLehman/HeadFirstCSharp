using System;
using System.IO;

namespace Null3
{
    class Program
    {
       
        static void Main(string[] args)
        {
            var nextLine="";
            using (var stringReader = new StringReader(""))
            {
                // this line will generate a null reference warning
                //var nextLine = stringReader.ReadLine();
                // ?? checks for null and returns an alternative
                nextLine = stringReader.ReadLine() ?? String.Empty;

                Console.WriteLine("Line length is: {0}", nextLine.Length);
            }

            nextLine = "something"; ;
            //it's really common to check for nulls like this
            if (nextLine == null)
                nextLine = "(the next line was null)";
            // Can do the same thing like this
            nextLine ??= "(the next line was null)";
        }
    }
}
