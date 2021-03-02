using System;
using System.Collections.Generic;
using System.Text;

namespace SaveableHideAndSeek
{
    public class SavedGame
    {
        // The Loading and Saving functionality is in GameController
        // This is the object that will be serialized/deserialized 
        /// <summary>
        /// Stores the name of GameController.CurrentLocation
        /// </summary>
        public string PlayerLocation { get; set; }

        /// <summary>
        /// The keys are the names of GameController.Opponents who are still hiding
        /// The values are the names of the Locations they are hiding
        /// </summary>
        public Dictionary<string,string> OpponentDictionary { get; set; }

        /// <summary>
        /// A list of the names of opponents who had been found when we saved GameController.FoundOpponents
        /// </summary>
        public List<string> FoundOpponents { get; set; }

        /// <summary>
        /// GameController.MoveNumber at the time we saved
        /// </summary>
        public int MoveNumber { get; set; }
    }
}
