using System;

namespace PickRandomCards
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            int numberOfCards = 0;
            bool inputValid = false;
            string[] cardsPicked;

            do
            {
                Console.Write("Enter the number of cards to pick: ");
                userInput = Console.ReadLine();
                if ( int.TryParse(userInput, out numberOfCards))
                {
                    // this block is executed if userInput could be converted to an int value that's
                    // stored in a new variable called numberOfCards
                    inputValid = true;
                }
                else
                {
                    Console.WriteLine("Your input cannot be converted to a number. Please try again");
                }
            } while(inputValid == false);
            numberOfCards = int.Parse(userInput);
            cardsPicked = CardPicker.PickSomeCards(numberOfCards);
            foreach(string card in cardsPicked)
            {
                Console.WriteLine(card);
            }
        }
    }
}
