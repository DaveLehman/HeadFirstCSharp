using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SaveableHideAndSeekTests
{
    using SaveableHideAndSeek;
    [TestClass]
    class HouseTests
    {
        [TestMethod]
        public void TestGetLocationByName()
        {
            Assert.AreEqual("Entry", House.GetLocationByName("Entry").Name);
            Assert.AreEqual("Attic", House.GetLocationByName("Attic").Name);
            Assert.AreEqual("Garage", House.GetLocationByName("Garage").Name);
            Assert.AreEqual("Master Bedroom", House.GetLocationByName("Master Bedroom").Name);
            Assert.AreEqual("Entry", House.GetLocationByName("Secret Library").Name);
        }

        [TestMethod]
        public void TestRandomExit()
        {
            var landing = House.GetLocationByName("Landing");
            /* so we're in the landing. The sorted list of exits would point to 
             * -1 North, 1 South, -2 East, 2 West, -3 Northeast, 3 Southwest, -4 Southeast, 4 Northwest, -5 Up, 5 Down
             * 
             * 
             * 
             * 
             */
            House.Random = new MockRandom() { ValueToReturn = 0 };
            Assert.AreEqual("Attic", House.RandomExit(landing).Name);
            House.Random = new MockRandom() { ValueToReturn = 1 };
            Assert.AreEqual("Hallway", House.RandomExit(landing).Name);
            House.Random = new MockRandom() { ValueToReturn = 2 };
            Assert.AreEqual("Kids Room", House.RandomExit(landing).Name);
            House.Random = new MockRandom() { ValueToReturn = 3 };
            Assert.AreEqual("Master Bedroom", House.RandomExit(landing).Name);
            House.Random = new MockRandom() { ValueToReturn = 4 };
            Assert.AreEqual("Nursery", House.RandomExit(landing).Name);
            House.Random = new MockRandom() { ValueToReturn = 5 };
            Assert.AreEqual("Pantry", House.RandomExit(landing).Name);
            House.Random = new MockRandom() { ValueToReturn = 6 };
            Assert.AreEqual("Second Bathroom", House.RandomExit(landing).Name);
            var kitchen = House.GetLocationByName("Kitchen");
            House.Random = new MockRandom() { ValueToReturn = 0 };
            Assert.AreEqual("Hallway", House.RandomExit(kitchen).Name);
        }

        [TestMethod]
        public void TestHidingPlaces()
        {
            Assert.IsInstanceOfType(House.GetLocationByName("Garage"), typeof(LocationWithHidingPlace));
            Assert.IsInstanceOfType(House.GetLocationByName("Kitchen"), typeof(LocationWithHidingPlace));
            Assert.IsInstanceOfType(House.GetLocationByName("Living Room"), typeof(LocationWithHidingPlace));
            Assert.IsInstanceOfType(House.GetLocationByName("Bathroom"), typeof(LocationWithHidingPlace));
            Assert.IsInstanceOfType(House.GetLocationByName("Master Bedroom"), typeof(LocationWithHidingPlace));
            Assert.IsInstanceOfType(House.GetLocationByName("Master Bath"), typeof(LocationWithHidingPlace));
            Assert.IsInstanceOfType(House.GetLocationByName("Second Bathroom"), typeof(LocationWithHidingPlace));
            Assert.IsInstanceOfType(House.GetLocationByName("Kids Room"), typeof(LocationWithHidingPlace));
            Assert.IsInstanceOfType(House.GetLocationByName("Nursery"), typeof(LocationWithHidingPlace));
            Assert.IsInstanceOfType(House.GetLocationByName("Pantry"), typeof(LocationWithHidingPlace));
            Assert.IsInstanceOfType(House.GetLocationByName("Attic"), typeof(LocationWithHidingPlace));
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
        public override int Next(int minValue, int maxValue) => ValueToReturn;
    }
}

