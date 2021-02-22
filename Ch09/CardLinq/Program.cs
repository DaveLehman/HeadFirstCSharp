using System;

using System.Linq;

namespace CardLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            var deck = new Deck()
                .Shuffle()
                .Take(16);

            var grouped =
                from card in deck
                group card by card.Suit into suitGroup  //a group ... by clause separates a sequence into groups
                orderby suitGroup.Key descending
                select suitGroup;
                                                           // grouped will have a sequence with a key of Spades and 
                                                           // a sequence with a key of Clubs ...
            foreach (var group in grouped)
            {
                Console.WriteLine($@"Group: {group.Key}
Count: {group.Count()}
Minimum: {group.Min()}
Maximum: {group.Max()}");
            }
        }
    }
}
