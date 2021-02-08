using System;

namespace Paintball4
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfBalls = ReadInt(20, "Number of balls");
            int magazineSize = ReadInt(16, "Magazine size");
            Console.Write($"Loaded [false]: ");
            bool.TryParse(Console.ReadLine(), out bool isLoaded);
            PaintballGun gun = new PaintballGun(numberOfBalls, magazineSize, isLoaded);
            while (true)
            {
                Console.WriteLine($"{gun.Balls} balls, {gun.BallsLoaded} loaded");
                if (gun.IsEmpty()) Console.WriteLine("WARNING: You're out of ammo");
                Console.WriteLine("<Space> to shoot, r to reload, + to add ammo, q to quit");
                char key = Console.ReadKey(true).KeyChar;
                if (key == ' ') Console.WriteLine($"Shooting returned {gun.Shoot()}");
                else if (key == 'r') gun.Reload();
                //class works fine as written but look at this syntax:
                // If we still had a field we could do += to increase it by the magazine size...
                else if (key == '+') gun.Balls += gun.MagazineSize;
                else if (key == 'q') return;
            }
        }

        static int ReadInt(int lastUsedValue, string prompt)
        {
            int returnValue;
            // Write the prompt followed by the [default value]:
            // Read the line from the input and use int.TryParse to attempt to parse it
            // If it can be parsed, write "     using value" + value to the console
            // Otherwise, write "       using default value" + lastUsedValue to the console
            Console.Write(prompt + " [" + lastUsedValue + "]:");
            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out int result))
            {
                returnValue = result;
                Console.WriteLine("\t\tusing value " + returnValue);
            }
            else
            {
                returnValue = lastUsedValue;
                Console.WriteLine("\t\tusing default value " + returnValue);
            }

            return returnValue;
        }
    }
}
