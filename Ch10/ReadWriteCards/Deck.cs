using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

using System.IO;

namespace ReadWriteCards
{
    public class Deck:ObservableCollection<Card>
    {
        private static Random random = new Random();
        public Deck()
        {
            Reset();
        }

        public void Reset()
        {
            /* Call Clear() to remove all cards from the Deck, then use two loops to add all combinations
             * of suit and value, calling Add(new Card(...)) to add each Card */
            this.Clear();
            for (int i = (int)Suits.Diamonds; i <= (int)Suits.Spades; i++)
            {
                for (int j = (int)Values.Ace; j <= (int)Values.King; j++)
                {
                    this.Add(new Card((Values)j, (Suits)i));
                }
            }
        }

        public Card Deal(int index)
        {
            // Use base[index] to pull out the specific card and RemoveAt(index) to remove it
            Card cardToReturn = this.Items[index];
            this.RemoveAt(index);
            return cardToReturn;
        }

        public Deck Shuffle()
        {
            /* Use new List<Card>(this) to create a copy of the deck, then pick a random card from copy,
             * call copy.RemoveAt to remove it, then Add(card) to add it */
            List<Card> copy = new List<Card>(this);
            this.Clear();
            while (copy.Count > 0)
            {
                int currentIndex = random.Next(copy.Count);
                Card currentCard = copy[currentIndex];
                copy.RemoveAt(currentIndex);
                this.Add(currentCard);
            }
            return this;
        }

        public void Sort()
        {
            // ObservableCollection doesn't have a Sort method
            List<Card> sortedCards = new List<Card>(this);
            sortedCards.Sort(new CardComparerByValue());
            this.Clear();
            // Use a foreach loop to call Add for each card in sortedCards
            foreach (Card card in sortedCards)
            {
                this.Add(card);
            }
        }
        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="filename"></param>
        public void WriteCards(string filename)
        {
            using (var writer = new StreamWriter(filename))
            {
                for (int i = 0; i < Count; i++)
                {
                    writer.WriteLine(this[i].Name);
                }
            }
        }

        // an overloaded Deck constructor reads a file
        public Deck(string filename)
        {
            using (var reader = new StreamReader(filename))
            {
                while(!reader.EndOfStream)
                {
                    var nextCard = reader.ReadLine();
                    var cardParts = nextCard.Split(new char[] { ' ' });
                    var value = cardParts[0] switch
                    {
                        "Ace" => Values.Ace,
                        "Two" => Values.Two,
                        "Three" => Values.Three,
                        "Four" => Values.Four,
                        "Five" => Values.Five,
                        "Six" => Values.Six,
                        "Seven" => Values.Seven,
                        "Eight" => Values.Eight,
                        "Nine" => Values.Nine,
                        "Ten" => Values.Ten,
                        "Jack" => Values.Jack,
                        "Queen" => Values.Queen,
                        "King" => Values.King,
                        _  => throw new InvalidDataException($"Unrecognized card value: {cardParts[0]}"),
                    };
                    var suit = cardParts[2] switch
                    {
                        "Spades" => Suits.Spades,
                        "Clubs" => Suits.Clubs,
                        "Hearts" => Suits.Hearts,
                        "Diamonds" => Suits.Diamonds,
                        _ => throw new InvalidDataException($"Unrecognized card value: {cardParts[2]}"),
                    };
                    Add(new Card(value, suit));
                }
            }
        }
    }
}
