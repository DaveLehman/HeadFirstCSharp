using System;
using System.Linq;

namespace LambaLinqSharpenYourPencil
{
    class Program
    {
        static string Output(Suits suit, int number) => $"Suit is {suit} and number is {number}";
        static void Main(string[] args)
        {
            var deck = new Deck();

            var processedCards = deck
                .Take(3)
                .Concat(deck.TakeLast(3)) // so we have of first 3 and last 3 cards in a new deck
                                                    // 1,2,3 of Diamonds
                                                    // J,Q,K of Spades
                .OrderByDescending(card => card)       // { KSp, QSp, JSp, 3Dm, 2Dm, ADm }
                .Select(card => card.Value switch
               {
                   Values.King => Output(card.Suit, 7),
                   Values.Ace => $"It's an ace! {card.Suit}",
                   Values.Jack => Output((Suits)card.Suit - 1, 9),
                   Values.Two => Output(card.Suit, 18),
                   _ => card.ToString(),
               });
            
            foreach(var output in processedCards)
            {
                Console.WriteLine(output);
            }
            // expected output
            // Suit is Spades and number is 7
            // Queen of Spades
            // Suit is Hearts and number is 9
            // Three of Diamonds
            // Suit is diamonds and number is 18
            // It's an Ace! Diamonds
        }
    }
}
