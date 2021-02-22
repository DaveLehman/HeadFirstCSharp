﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CardLinq
{
    class Card:IComparable<Card>
    {
        // We're going to use LINQ to sort groups of cars, so we have to make Cards sortable...
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

        //implemting the interface is easy cuz we already have CardComparerByValue to use
        public int CompareTo([AllowNull] Card other)
        {
            return new CardComparerByValue().Compare(this, other);
        }
    }

    enum Suits
    {
        Diamonds,
        Clubs,
        Hearts,
        Spades,
    }

    enum Values
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
