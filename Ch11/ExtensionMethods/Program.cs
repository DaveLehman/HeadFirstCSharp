using System;

namespace ExtensionMethods
{
    // Sometimes you need to extend a class you can't inherit from, like a .NET sealed class. An extension method adds a method that appears on an existing class
    sealed class OrdinaryHuman
    {
        private int age;
        int weight;

        public OrdinaryHuman(int weight)
        {
            this.weight = weight;
        }

        public void GoToWork() { /* code to go to work */ }
        public void PayBills() { /* code to pay bills */ }
    }

    // The AmazeballsSerum method adds an extension method to OrdinaryHuman
    // Extension methods are always static, and they have to live in static classes
    static class AmazeballsSerum
    {
        public static string BreakWalls(this OrdinaryHuman h, double wallDensity)
        {
            return ($"I broke through a wall of {wallDensity} density.");
        }
        class Program
    {




        static void Main(string[] args)
        {
                OrdinaryHuman steve = new OrdinaryHuman(185);
                Console.WriteLine(steve.BreakWalls(89.2));
        }
    }


    }
}
