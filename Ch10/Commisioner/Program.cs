using System;
using System.IO;

namespace Commisioner
{
    class Program
    {
        static void Main(string[] args)
        {
            var folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            var reader = new StreamReader($"{folder}{Path.DirectorySeparatorChar}secret_plan.txt");
            var writer = new StreamWriter($"{folder}{Path.DirectorySeparatorChar}emailToCaptainA.txt");

            writer.WriteLine("To: Captain Amazing@objectville.net");
            writer.WriteLine("From: Commisioner@objectville.net");
            writer.WriteLine("Subject: Can you save the day... again?");
            writer.WriteLine();
            writer.WriteLine("We've discovered the Swindler's terrible plan:");

            while(!reader.EndOfStream)
            {
                var lineFromThePlan = reader.ReadLine();
                writer.WriteLine($"The plan -> {lineFromThePlan}");
            }
            writer.WriteLine();
            writer.WriteLine("Can you help us?");

            writer.Close();
            reader.Close();
        }
    }
}
