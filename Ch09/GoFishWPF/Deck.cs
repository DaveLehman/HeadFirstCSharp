using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;

namespace GoFishWPF
{
    public class Deck:ObservableCollection<Card>
    {
        private static Random random = Player.Random;
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
    }
}
