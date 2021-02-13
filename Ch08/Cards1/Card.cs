using System;
using System.Collections.Generic;
using System.Text;

namespace Cards1
{
    class Card
    {
        Values Value { get; set; }
        Suits Suit { get; set; }
        public string Name { get { return $"{Value} of {Suit}"; } }
        // Constructor
        public Card(Values value, Suits suit)
        {
            Value = value;
            Suit = suit;
        }

    }
}
