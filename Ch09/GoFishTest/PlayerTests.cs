using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using GoFishConsole;

namespace GoFishTest
{
    // This Test Class is given by the exercise. Point is to use it as a clue for how to construct
    // the Player Class
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void TestGetNextHand()
        {
            // GetNextHand returns up to 5 cards from the deck. CollectionAssert can't compare cards, so
            // we use the Select LINQ method to convert cards to a list of card names to compare
            var player = new Player("Owen", new List<Card>());
            player.GetNextHand(new Deck());
            // We saw CollectionAssert in Ch09 -- compares an expected collection with an actual result
            CollectionAssert.AreEqual(
                new Deck().Take(5).Select(card => card.ToString()).ToList(),
                    player.Hand.Select(card => card.ToString()).ToList());
        }

        [TestMethod]
        public void TestDoYouHaveAny()
        {
            IEnumerable<Card> cards = new List<Card>()
            {
                new Card(Values.Jack, Suits.Spades),
                new Card(Values.Three, Suits.Clubs),
                new Card(Values.Three, Suits.Hearts),
                new Card(Values.Four, Suits.Diamonds),
                new Card(Values.Three, Suits.Diamonds),
                new Card(Values.Jack, Suits.Clubs),
            };
            var player = new Player("Owen", cards);

            // The DoYouHaveAny method removes the matching cards from the player's hand and returns them --
            // in this case, the three 3's
            var threes = player.DoYouHaveAny(Values.Three, new Deck())
                .Select(Card => Card.ToString())
                .ToList();

            CollectionAssert.AreEqual(new List<string>()
            {
                "Three of Diamonds",
                "Three of Clubs",
                "Three of Hearts",
            }, threes);
            Assert.AreEqual(3, player.Hand.Count());

            // second call to DoYouHaveAny returns the 2 jacks and removes them from the player's hand
            var jacks = player.DoYouHaveAny(Values.Jack, new Deck())
                .Select(Card => Card.ToString())
                .ToList();
            CollectionAssert.AreEqual(new List<string>()
            {
                "Jack of Clubs",
                "Jack of Spades",
            }, jacks);
            // should only have the four of diamonds left in hand
            var hand = player.Hand.Select(Card => Card.ToString()).ToList();
            CollectionAssert.AreEqual(new List<string>() { "Four of Diamonds" }, hand);
            // check Status
            Assert.AreEqual("Owen has 1 card and 0 books", player.Status);
        }

        [TestMethod]
        public void TestAddCardsAndPullOutBooks()
        {
            IEnumerable<Card> cards = new List<Card>()
            {
                new Card(Values.Jack, Suits.Spades),
                new Card(Values.Three, Suits.Clubs),
                new Card(Values.Jack, Suits.Hearts),
                new Card(Values.Three, Suits.Hearts),
                new Card(Values.Four, Suits.Diamonds),
                new Card(Values.Jack, Suits.Diamonds),
                new Card(Values.Jack, Suits.Clubs),
            };
            var player = new Player("Owen", cards);

            Assert.AreEqual(0, player.Books.Count());
            var cardsToAdd = new List<Card>()
            {
                new Card(Values.Three, Suits.Diamonds),
                new Card(Values.Three, Suits.Spades),
            };
            player.AddCardsAndPullOutBooks(cardsToAdd);

            var books = player.Books.ToList();
            CollectionAssert.AreEqual(new List<Values>() { Values.Three, Values.Jack }, books);

            var hand = player.Hand.Select(Card => Card.ToString()).ToList();
            CollectionAssert.AreEqual(new List<string>() { "Four of Diamonds" }, hand);
            Assert.AreEqual("Owen has 1 card and 2 books", player.Status);
        }

        [TestMethod]
        public void TestDrawCard()
        {
            var player = new Player("Owen", new List<Card>());
            player.DrawCard(new Deck());
            Assert.AreEqual(1, player.Hand.Count());
            Assert.AreEqual("Ace of Diamonds", player.Hand.First().ToString());
        }

        [TestMethod]
        public void TestRandomValueFromHand()
        {
            var player = new Player("Owen", new Deck());
            Player.Random = new MockRandom() { ValueToReturn = 0 };
            Assert.AreEqual("Ace", player.RandomValueFromHand().ToString());
            Player.Random = new MockRandom() { ValueToReturn = 15 };
            Assert.AreEqual("Four", player.RandomValueFromHand().ToString());
            Player.Random = new MockRandom() { ValueToReturn = 51 };
            Assert.AreEqual("King", player.RandomValueFromHand().ToString());
        }


    }

    /// <summary>
    /// Mock Random for testing that always returns a specific value
    /// </summary>
    public class MockRandom : System.Random
    {
        public int ValueToReturn { get; set; } = 0;
        public override int Next() => ValueToReturn;
        public override int Next(int maxValue) => ValueToReturn;
        public override int Next(int minValue, int MaxValue) => ValueToReturn;



    }
}
