using System;

namespace Casino
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            const double odds = 0.75;
            Guy player = new Guy() { Name = "The player", Cash = 100 };

            Console.WriteLine("Welcome to the casino. The odds are " + odds);

            while (player.Cash > 0)
            {
                // Have the Guy object print the amount of cash it has
                player.WriteMyInfo();
                // Ask the user how much money to bet
                Console.Write("How much do you want to bet: ");
                // Read the line into a string variable called howMuch
                string howMuch = Console.ReadLine();
                if (howMuch == "")
                    return;
                // Try to parse it into a variable called amount
                if (int.TryParse(howMuch, out int amount))
                {
                    // If it parses, the player gives the amount to an int variable called pot. It gets multiplied by two, because its a double-or-nothing bet
                    int pot = player.GiveCash(amount) * 2;
                    // The program picks a random number between 0 and 1
                    if( pot > 0)
                    {
                        // If the number is greater than odds, the player receives the pot.
                        if (random.NextDouble() > odds)
                        {
                            player.ReceiveCash(pot);
                            Console.WriteLine("You win " + pot);
                        }
                        else
                        {
                            // If not, the player loses the amount they bet
                            //player.GiveCash(amount);
                            Console.WriteLine("Bad luck, you lose.");
                        }
                    }
                }
                else
                {
                    // failed to Parse
                    Console.WriteLine("Please enter a valid number.");
                }
            } // end while The program keeps running while the player has cash
            Console.WriteLine("The house always wins.");
        } // end main
    }
}
