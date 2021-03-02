using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SaveableHideAndSeekTests
{
    using SaveableHideAndSeek;
    using System.Linq;
    [TestClass]
    class OpponentsTests
    {
        [TestMethod]
        public void TestOpponentHiding()
        {
            var opponent1 = new Opponent("opponent1");
            Assert.AreEqual("opponent1", opponent1.Name);
            House.Random = new MockRandomWithValueList(new int[] { 0, 1 });
            opponent1.Hide();
            var bathroom = House.GetLocationByName("Bathroom") as LocationWithHidingPlace;
            CollectionAssert.AreEqual(new[] { opponent1 }, bathroom.CheckHidingPlace().ToList());
            var opponent2 = new Opponent("opponent2");
            Assert.AreEqual("opponent2", opponent2.Name);
            House.Random = new MockRandomWithValueList(new int[] { 0, 1, 2, 3, 4 });
            opponent2.Hide();
            var kitchen = House.GetLocationByName("Kitchen") as LocationWithHidingPlace;
            CollectionAssert.AreEqual(new[] { opponent2 }, kitchen.CheckHidingPlace().ToList());
        }
    }

    /// <summary>
    /// Mock Random for testing that uses a list to return values
    /// </summary>
    public class MockRandomWithValueList : System.Random
    {
        private Queue<int> valuesToReturn;
        public MockRandomWithValueList(IEnumerable<int> values) =>
        valuesToReturn = new Queue<int>(values);
        public int NextValue()
        {
            var nextValue = valuesToReturn.Dequeue();
            valuesToReturn.Enqueue(nextValue);
            return nextValue;
        }
        public override int Next() => NextValue();
        public override int Next(int maxValue) => Next(0, maxValue);
        public override int Next(int minValue, int maxValue)
        {
            var next = NextValue();
            return next >= minValue && next < maxValue ? next : minValue;
        }
    }
}

