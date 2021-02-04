using System;

namespace MySecondConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            OperatorExamples();
        }

        private static void OperatorExamples()
        {
            // This statement declares a varaible and sets it to 3
            int width = 3;

            // The ++ oeprator increments a variable (addes one to it)
            width++;

            // Declare two more variables to hold numbers and use
            // the + and - operators to add and multiply values
            int height = 2 + 4;
            int area = width * height;
            Console.WriteLine(area);

            while (area < 50)
            {
                height++;
                area = width * height;
            }

            do
            {
                width--;
                area = width * height;
            } while (area > 25);

            // The enxt two statements declare string variables
            // and use + to concatenate them (join them together)
            string result = "The area";
            result = result + " is " + area;
            Console.WriteLine(result);

            // A Boolean variable is either true or false
            bool truthValue = true;
            Console.WriteLine(truthValue);
        }
    }
}
