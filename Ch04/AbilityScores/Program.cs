using System;

namespace AbilityScores
{
    class Program
    {
        static void Main(string[] args)
        {
            AbilityScoreCalculator calculator = new AbilityScoreCalculator();
            while(true)
            {
                calculator.RollResult = ReadInt(calculator.RollResult, "starting 4d6 roll");
                calculator.DivideBy = ReadDouble(calculator.DivideBy, "Divide by");
                calculator.AddAmount = ReadInt(calculator.AddAmount, "Add amount");
                calculator.Minimum = ReadInt(calculator.Minimum, "Minimum");
                calculator.CalculateAbilityScore();
                Console.WriteLine("Calculated ability score: " + calculator.Score);
                Console.WriteLine("Press Q to quit, any other key to continue");
                char keyChar = Console.ReadKey(true).KeyChar;
                if ((keyChar == 'Q') || (keyChar == 'q')) return;
            }
        }

        /// <summary>
        /// Writes a prompt and reads an int value from the console.
        /// </summary>
        /// <param name="lastUsedValue">The default value</param>
        /// <param name="prompt">Prompt to print to the console</param>
        /// <returns></returns>
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
            } else
            {
                returnValue = lastUsedValue;
                Console.WriteLine("\t\tusing default value " + returnValue);
            }

            return returnValue;
        }

        /// <summary>
        /// Writes a prompt and reads a double value from the console.
        /// </summary>
        /// <param name="lastUsedValue">The default value</param>
        /// <param name="prompt">Prompt to print to the console</param>
        /// <returns></returns>
        static double ReadDouble(double lastUsedValue, string prompt)
        {
            // same but for double
            double returnValue;
            Console.Write(prompt + " [" + lastUsedValue + "]:");
            string userInput = Console.ReadLine();
            if (double.TryParse(userInput, out double result))
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
