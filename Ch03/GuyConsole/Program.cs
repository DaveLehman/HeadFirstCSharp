using System;

namespace GuyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new Guy object in a variable called joe
            // Set its Name field to "Joe"
            // Set its Cash field to 50
            Guy joe = new Guy() { Name = "Joe", Cash = 50 };

            // Create a new Guy object in a variable called bob
            // Set its Name field to "Bob"
            // Set its Cash field to 100
            Guy bob = new Guy() { Name = "Bob", Cash = 100 };

            while(true)
            {
                // Call the WriteMyInfo method for each Guy object
                joe.WriteMyInfo();
                bob.WriteMyInfo();

                Console.Write("Enter an amount: ");
                string howMuch = Console.ReadLine();
                if (howMuch == "") return;

                // Use int.TryParse to try to convert the howMuch string to an int
                // if it was successful
                if (int.TryParse(howMuch, out int transfer))
                {
                    Console.Write("Who should give the cash: ");
                    string whichGuy = Console.ReadLine();
                    if (whichGuy == "Joe")
                    {
                        // Call the joe object's GiveCash method and save the results
                        // Call the bob object's ReceiveCash method with the save results
                        bob.ReceiveCash(joe.GiveCash(transfer));
                    }
                    else if (whichGuy == "Bob")
                    {
                        // Call the bob object's GiveCash method and save the results
                        // Call the joe object's ReceiveCash method with the save results
                        joe.ReceiveCash(bob.GiveCash(transfer));
                    }
                    else
                    {
                        Console.WriteLine("Please enter 'Joe' or 'Bob'");
                    }
                }
                else
                {
                    //TryParse failed
                    Console.WriteLine("Please enter an amount (or a blank line to exit).");
                }
            }
        }
    }
}
