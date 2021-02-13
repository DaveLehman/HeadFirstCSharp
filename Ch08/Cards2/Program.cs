using System;
using System.Collections.Generic;

namespace Cards2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Card> cardList = new List<Card>();
            while(true)
            {
                Console.Write("Enter number of cards <q to quit>: ");
                string input = Console.ReadLine();
                if((int.TryParse(input, out int converted) && converted > 0))
                {
                    // valid number of cards to generate
                    cardList.Clear();
                    for (int i = 1; i <= converted; i++)
                    {
                        cardList.Add(RandomCard());
                    }
                    // Print the list
                    PrintCards(cardList);
                    Console.WriteLine("\n... sorting the cards ...\n");
                    CardComparerBySuitThenValue sorter = new CardComparerBySuitThenValue();
                    cardList.Sort(sorter);
                    PrintCards(cardList);

                }
                else
                {
                    if (input[0] == 'q') return;
                    Console.WriteLine("Invalid input ... please enter a number");
                }

            }
        }

        static Card RandomCard()
        {
            // Return a rerference to a card with a random suit and value
            Random random = new Random();
            Suits suit = (Suits)random.Next(4);
            Values value = (Values)random.Next(1, 14);
            return new Card(value, suit);
        }

        static void PrintCards(List<Card> cards)
        {
            // Prints a list of cards
            int count = 1;
            foreach(Card card in cards)
            {
                Console.WriteLine($"Card {count++} is {card.Name}");
            }
        }
    }
}
