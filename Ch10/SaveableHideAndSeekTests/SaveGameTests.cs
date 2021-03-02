using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SaveableHideAndSeekTests
{
    using SaveableHideAndSeek;
    using System.Linq;

    [TestClass]
    public class SaveGameTests
    {
        /* This test
         * 1. Hides 5 Opponents in known locations
         * 2. Calls ParseInput to play the game and find some of them
         * 3. Calls ParseInput to Save the Game to create a temporary file
         * 4. Creates a new GameController to Load the game from a temporary file
         * 5. Call ParseInput some more to go find another opponent we hid in Step 1
        */


        GameController gameController;

        [TestInitialize]
        public void Initialize()
        {
            gameController = new GameController();
        }

        [TestMethod]
        public void SaveTest()
        {
            Assert.IsFalse(gameController.GameOver);
            // Clear the hiding places and hide the opponents in specific rooms
            House.ClearHidingPlaces();
            var joe = gameController.Opponents.ToList()[0];
            (House.GetLocationByName("Garage") as LocationWithHidingPlace).Hide(joe);

            var bob = gameController.Opponents.ToList()[1];
            (House.GetLocationByName("Kitchen") as LocationWithHidingPlace).Hide(bob);

            var ana = gameController.Opponents.ToList()[2];
            (House.GetLocationByName("Attic") as LocationWithHidingPlace).Hide(ana);

            var owen = gameController.Opponents.ToList()[3];
            (House.GetLocationByName("Attic") as LocationWithHidingPlace).Hide(owen);

            var jimmy = gameController.Opponents.ToList()[4];
            (House.GetLocationByName("Kitchen") as LocationWithHidingPlace).Hide(jimmy);

            // Check the Entry -- there are no players hiding there
            Assert.AreEqual(1, gameController.MoveNumber);
            Assert.AreEqual("There is no hiding place in the Entry",
            gameController.ParseInput("Check"));
            Assert.AreEqual(2, gameController.MoveNumber);

            // Move to the Garage
            gameController.ParseInput("Out");
            Assert.AreEqual(3, gameController.MoveNumber);
            // We hid Joe in the Garage, so validate ParseInput's return value and the properties
            Assert.AreEqual("You found 1 opponent hiding behind the car",
            gameController.ParseInput("check"));
            Assert.AreEqual("You are in the Garage. You see the following exits:" +
            Environment.NewLine + " - the Entry is In" +
            Environment.NewLine + "Someone could hide behind the car" +
            Environment.NewLine + "You have found 1 of 5 opponents: Joe",
            gameController.Status);
            Assert.AreEqual("4: Which direction do you want to go (or type 'Check/Load/Save'): ",
            gameController.Prompt);
            Assert.AreEqual(4, gameController.MoveNumber);
            // Move to the bathroom, where nobody is hiding
            gameController.ParseInput("In");
            gameController.ParseInput("East");
            gameController.ParseInput("North");
            // Check the Bathroom to make sure nobody is hiding there
            Assert.AreEqual("Nobody was hiding behind the door", gameController.ParseInput("Check"));
            Assert.AreEqual(8, gameController.MoveNumber);
            // Check the Bathroom to make sure nobody is hiding there
            gameController.ParseInput("South");
            gameController.ParseInput("Northwest");
            //////////////////////////////////////////////////////////////////////////
            /// Save the game here
            /// ///////////////////////////////////////////////////////////////////////
            // check GameOver
            Assert.IsFalse(gameController.GameOver);
            var kitchen = House.GetLocationByName("Kitchen") as LocationWithHidingPlace;
            // jimmy should still be hiding in the kitchen
            CollectionAssert.AreEqual(new[] { bob, jimmy }, kitchen.CheckHidingPlace().ToList());
            var attic = House.GetLocationByName("Attic") as LocationWithHidingPlace;
            // ana, owen should still be hiding in the kitchen
            CollectionAssert.AreEqual(new[] { ana, owen }, attic.CheckHidingPlace().ToList());

            // it's good we have people hiding still, but this test is destructive
            // need to add bob, jimmy, ana, own back so we can continue the game
            bob = gameController.Opponents.ToList()[1];
            (House.GetLocationByName("Kitchen") as LocationWithHidingPlace).Hide(bob);
            ana = gameController.Opponents.ToList()[2];
            (House.GetLocationByName("Attic") as LocationWithHidingPlace).Hide(ana);
            owen = gameController.Opponents.ToList()[3];
            (House.GetLocationByName("Attic") as LocationWithHidingPlace).Hide(owen);
            jimmy = gameController.Opponents.ToList()[4];
            (House.GetLocationByName("Kitchen") as LocationWithHidingPlace).Hide(jimmy);
            // In Kitchen
            Assert.AreEqual("You found 2 opponents hiding next to the stove",
            gameController.ParseInput("check"));
            Assert.AreEqual("You are in the Kitchen. You see the following exits:" +
            Environment.NewLine + " - the Hallway is to the Southeast" +
            Environment.NewLine + "Someone could hide next to the stove" +
            Environment.NewLine + "You have found 3 of 5 opponents: Joe, Bob, Jimmy",
            gameController.Status);
            Assert.AreEqual("11: Which direction do you want to go (or type 'Check/Load/Save'): ",
            gameController.Prompt);
            Assert.AreEqual(11, gameController.MoveNumber);
            Assert.IsFalse(gameController.GameOver);
            // Head up to the Landing, then check the Pantry (nobody's hiding there)
            gameController.ParseInput("Southeast");
            gameController.ParseInput("Up");
            Assert.AreEqual(13, gameController.MoveNumber);
            gameController.ParseInput("South");
            Assert.AreEqual("Nobody was hiding inside a cabinet",
            gameController.ParseInput("check"));
            Assert.AreEqual(15, gameController.MoveNumber);
            // Check the Attic to find the last two opponents, make sure the game is over
            gameController.ParseInput("North");
            gameController.ParseInput("Up");
            Assert.AreEqual(17, gameController.MoveNumber);
            Assert.AreEqual("You found 2 opponents hiding in a trunk",
            gameController.ParseInput("check"));
            Assert.AreEqual("You are in the Attic. You see the following exits:" +
            Environment.NewLine + " - the Landing is Down" +
            Environment.NewLine + "Someone could hide in a trunk" +
            Environment.NewLine +
            "You have found 5 of 5 opponents: Joe, Bob, Jimmy, Ana, Owen",
            gameController.Status);
            Assert.AreEqual("18: Which direction do you want to go (or type 'Check/Load/Save'): ",
            gameController.Prompt);
            Assert.AreEqual(18, gameController.MoveNumber);
            Assert.IsTrue(gameController.GameOver);

        }


        [TestMethod]
        public void CheckFileNames()
        {

        }

    }
}
