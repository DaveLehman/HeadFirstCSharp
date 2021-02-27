using System;
using System.Collections.Generic;
using System.Text;

namespace ReadWriteCards
{
    public class Card
    {
        public Values Value { get; private set; }
        public Suits Suit { get; private set; }
        public string Name { get { return $"{Value} of {Suit}"; } }
        // Constructor
        public Card(Values value, Suits suit)
        {
            Value = value;
            Suit = suit;
        }
        // this allows your cards to write themselves in the IDE
        public override string ToString()
        {
            return Name;
        }
    }

    public enum Suits
    {
        Diamonds,
        Clubs,
        Hearts,
        Spades,
    }

    public enum Values
    {
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
    }
}

