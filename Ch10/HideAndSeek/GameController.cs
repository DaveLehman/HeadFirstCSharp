using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HideAndSeek
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
                if (CurrentLocation is LocationWithHidingPlace)
                {
                    statusString += Environment.NewLine;
                    statusString += $"Someone could hide {(CurrentLocation as LocationWithHidingPlace).HidingPlace}";
                }
                statusString += Environment.NewLine;
                if (foundOpponents.Count > 0)
                {
                    statusString += $"You have found {foundOpponents.Count()} of {Opponents.Count()} opponents: {foundOpponents[0].Name}";
                    for(int i = 1; i < foundOpponents.Count(); i++)
                        statusString +=  ", " + foundOpponents[i];
                }
                else
                {
                    statusString += "You have not found any opponents";
                }
                 
                return statusString;
            }

        }

        /// <summary>
        /// The number of moves the player has made
        /// </summary>
        public int MoveNumber { get; private set; } = 1;

        /// <summary>
        /// Private list of opponents the player needs to find
        /// </summary>
        public readonly IEnumerable<Opponent> Opponents = new List<Opponent>()
        {
            new Opponent("Joe"),
            new Opponent("Bob"),
            new Opponent("Ana"),
            new Opponent("Owen"),
            new Opponent("Jimmy"),
        };

        /// <summary>
        /// Private list of opponents the player has found so far
        /// </summary>
        private readonly List<Opponent> foundOpponents = new List<Opponent>();

        /// <summary>
        /// Returns true if the game is over
        /// </summary>
        public bool GameOver => Opponents.Count() == foundOpponents.Count();

        /// <summary>
        /// A prompt to display to the player
        /// </summary>
        public string Prompt => $"{MoveNumber}: Which direction do you want to go (or type 'Check'): ";


        public GameController()
        {
            // clear the hiding places and tell each opponent to hide
            House.ClearHidingPlaces();
            foreach (Opponent opponent in Opponents)
                opponent.Hide();
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
            // valid input must be a direction or 'Check'
            if(input.ToUpper().ToString()=="CHECK")
            {
                // typing check counts as a Move
                MoveNumber++;
                if (CurrentLocation is LocationWithHidingPlace)
                {
                    LocationWithHidingPlace loc = CurrentLocation as LocationWithHidingPlace;
                    List<Opponent> checkList = (List<Opponent>)loc.CheckHidingPlace();
                    int opponentsFound = checkList.Count;
                    if ( opponentsFound > 0 )
                    {
                        foreach (Opponent o in checkList)
                        {
                            foundOpponents.Add(o);
                        }
                        string plural = "opponent";
                        if (opponentsFound > 1)
                            plural = "opponents";
                        return $"You found {opponentsFound} " + plural + $" hiding {loc.HidingPlace}";
                    }
                    else
                    {
                        return $"Nobody was hiding {loc.HidingPlace}";
                    }
                }
                else
                {
                    return $"There is no hiding place in the {CurrentLocation.Name}";
                }
            }
            if (Enum.TryParse(typeof(Direction), input, out var value))
            {
                // and we have to be capable of moving in that direction
                if (CurrentLocation.GetExit((Direction)value) != CurrentLocation)
                {
                    // valid move increment count
                    MoveNumber++;
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
