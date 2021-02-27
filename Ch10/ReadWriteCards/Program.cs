using System;
using System.IO;

namespace ReadWriteCards
{
    class Program
    {
        static void Main(string[] args)
        {
            var filename = @"F:\terable2\Documents\HeadFirst\C#(4th)1\Ch10\ReadWriteCards\deckofcards.txt";
            Deck deck = new Deck();
            deck.Shuffle();
            for (int i = deck.Count - 1; i > 10; i--)
                deck.RemoveAt(i);
            deck.WriteCards(filename);

            Deck cardsToRead = new Deck(filename);
            foreach (var card in cardsToRead)
                Console.WriteLine(card.Name);
        }
    }
}
