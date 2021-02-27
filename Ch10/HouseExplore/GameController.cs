using System;
using System.Collections.Generic;
using System.Text;

namespace HouseExplore
{
    public class GameController
    {
        /// <summary>
        /// The player's current location in the House
        /// </summary>
        public Location CurrentLocation { get; private set; }

        /// <summary>
        /// Returns the current status to show to the player
        /// </summary>
        public string Status
        {
            get
            {
                string statusString = "";
                statusString += $"You are in the {CurrentLocation}. You see the following exits:";
                foreach (string s in CurrentLocation.ExitList)
                {
                   statusString += Environment.NewLine + $" - {s}";
                }
                return statusString;
            }

        }

        /// <summary>
        /// A prompt to display to the player
        /// </summary>
        public string Prompt => "Which direction do you want to go?";
        public GameController()
        {
            CurrentLocation = House.Entry;
        }
        /// <summary>
        /// Move to the location in a direction
        /// </summary>
        /// <param name="direction">The direction to move</param>
        /// <returns>True if the player can move in that direction, false otherwise</returns>
        public bool Move(Direction direction)
        {
            if (CurrentLocation.GetExit(direction) != CurrentLocation)
            {
                // move in that direction is possible
                CurrentLocation = CurrentLocation.GetExit(direction);
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Parses input form the player and updates the status
        /// </summary>
        /// <param name="input">Input to parse</param>
        /// <returns>The results of parsing the input</returns>
        public string ParseInput(string input)
        {
            // valid input must be a direction..
            if (Enum.TryParse(typeof(Direction), input, out var value))
            {
                // and we have to be capable of moving in that direction
                if (CurrentLocation.GetExit((Direction)value) != CurrentLocation)
                {
                    Move((Direction)value);
                    return $"Moving {value}";

                }
                else
                {
                    return "There's no exit in that direction";
                }
                
            }
            else
            {
                return "That's not a valid direction";
            }
        }
    }
}
