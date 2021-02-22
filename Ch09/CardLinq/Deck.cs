using System;
using System.Collections.Generic;
using System.Text;

using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;

namespace CardLinq
{
    class Deck:ObservableCollection<Card>
    {        // Deck is a collection that holds Card objects. The Observable Collection class is built for
        // data binding. Lets the program know when items get added, removed or refreshed.
        /* Since Deck extends ObservableCollection, we can use inherited members, including the [indexer],
         * the Count property, and the Add, RemoveAt, and Clear methods
         */
        private static Random random = new Random();
        public Deck()
        {
            Reset();
        }

        public void Reset()
        {
            /* Call Clear() to remove all cards from the Deck, then use two loops to add all combinations
             * of suit and value, calling Add(new Card(...)) to add each Card */
            // throw new NotImplementedException("The Reset method resets the 52-card deck");
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
            // throw new NotImplementedException("The Deal method will deal a card from the deck");
            Card cardToReturn = this.Items[index];
            this.RemoveAt(index);
            return cardToReturn;
        }

        // To do Linq method chaining, we need Shuffle() to return a Deck
        public Deck Shuffle()
        {
            /* Use new List<Card>(this) to create a copy of the deck, then pick a random card from copy,
            * call copy.RemoveAt to remove it, then Add(card) to add it */
            //throw new NotImplementedException("The shuffle method will randomize the cards");
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
            // throw new NotImplementedException("The Sort method sorts the cards.");
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
