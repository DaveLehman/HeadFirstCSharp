using System;
using System.Collections.Generic;

namespace Lumberjacks
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Queue<Lumberjack> lumberjacks = new Queue<Lumberjack>();

            // Loop the collect Names and numbers of flapjacks
            // continue until user hits space
            Console.Write("First lumberjack's name: ");
            string jackName = Console.ReadLine();
            int numFlapjacks;

            bool validInput = false;
            do
            {
                Console.Write("Number of flapjacks: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out numFlapjacks))
                {
                    // create the lumberjack
                    Lumberjack jack = new Lumberjack(jackName);
                    // give him some flapjacks
                    for(int i = 0; i < numFlapjacks; i++)
                    {
                        jack.TakeFlapjack((Flapjack)random.Next(4));
                    }
                    // and put in the lumberjack queue
                    lumberjacks.Enqueue(jack);
                    validInput = true;
                }
            } while (validInput == false);

            
            while (true)
            {
                
                Console.Write("Next lumberjack's name (blank to end): ");
                jackName = Console.ReadLine();
                if (jackName.Equals(" ") || jackName.Equals(""))
                {
                    Console.WriteLine("User entered space or null");
                    break;
                }
                validInput = false;
                while(validInput == false)
                {
                    Console.Write("Number of flapjacks: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out numFlapjacks))
                    {
                        // create the lumberjack
                        // create the lumberjack
                        Lumberjack jack = new Lumberjack(jackName);
                        // give him some flapjacks
                        for (int i = 0; i < numFlapjacks; i++)
                        {
                            jack.TakeFlapjack((Flapjack)random.Next(4));
                        }
                        // and put in the lumberjack queue
                        lumberjacks.Enqueue(jack);
                        validInput = true;
                    }
                }
            };

            // Now we have a queue of lumberjack objects
            // unload their stacks by eating flapjacks and dequeue the lumberjacks
            Lumberjack currentJack;
            while(lumberjacks.Count > 0)
            {
                currentJack = lumberjacks.Dequeue();
                currentJack.EatFlapjacks();
            }
        }
    }
}
