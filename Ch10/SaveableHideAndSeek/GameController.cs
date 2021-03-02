using System;
using System.Collections.Generic;
using System.Text;

namespace SaveableHideAndSeek
{
    using System.Linq;
    using System.IO;
    using System.Text.Json;
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
                    for (int i = 1; i < foundOpponents.Count(); i++)
                        statusString += ", " + foundOpponents[i];
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
        /// A Dictionary to keep track of the opponent locations
        /// </summary>
        private Dictionary<string, string> opponentLocations = new Dictionary<string, string>();

        /// <summary>
        /// Returns true if the game is over
        /// </summary>
        public bool GameOver => Opponents.Count() == foundOpponents.Count();

        /// <summary>
        /// A prompt to display to the player
        /// </summary>
        public string Prompt => $"{MoveNumber}: Which direction do you want to go (or type 'Check/Load/Save'): ";


        public GameController()
        {
            // clear the hiding places and tell each opponent to hide
            House.ClearHidingPlaces();
            foreach (Opponent opponent in Opponents)
            {
                opponentLocations.Add(opponent.Name, opponent.Hide().Name);
            }

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
            // now support Load and Save
            if (input.ToUpper().ToString() == "SAVE")
            {
                GameSaveDialog();
                // don't process the rest of ParseInput -- just return to the main loop
                return "";
            }
                
            if (input.ToUpper().ToString() == "LOAD")
            {
                GameLoadDialog();
                // don't process the rest of ParseInput -- just return to the main loop
                return "";
            }

            // valid input is Check or a direction
            if (input.ToUpper().ToString() == "CHECK")
            {
                // typing check counts as a Move
                MoveNumber++;
                if (CurrentLocation is LocationWithHidingPlace)
                {
                    LocationWithHidingPlace loc = CurrentLocation as LocationWithHidingPlace;
                    List<Opponent> checkList = (List<Opponent>)loc.CheckHidingPlace();
                    int opponentsFound = checkList.Count;
                    if (opponentsFound > 0)
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

        private void GameSaveDialog()
        {
            bool debugSave = true;
            string path = Directory.GetCurrentDirectory();
            string defaultFileName = "SavedHideAndSeek01.sav";
            string fileName = defaultFileName;
            // ask the user for a filename to save
            while(true)
            {
                Console.WriteLine("Writing to Directory: " + path);
                Console.WriteLine("Writing to Filename: " + fileName);
                Console.Write("Type a different filename or Save again to confirm:");
                string input = Console.ReadLine();
                if(input.ToUpper().ToString() == "SAVE")
                {
                    // continue the save
                    break;
                }
                else
                {
                    // new filename or perhaps garbage
                    if (ValidFileName(input))
                    {
                        if (String.IsNullOrEmpty(input))
                        {
                            fileName = defaultFileName;
                            break;
                        }
                        else
                        {
                            fileName = input;
                            break;
                        }

                    }
                    else
                    {
                        Console.WriteLine("A valid filename cannot contain any spaces or slashes. Please try again.");
                        continue;
                    }
                }
            }
            if(debugSave)
            {
                Console.WriteLine("Leaving input loop");
            }
            // Create a new SavedGame object and populate it from the Game Controller
            SavedGame savedGame = new SavedGame();
            // grab the MoveNumber and player current location
            savedGame.PlayerLocation = CurrentLocation.ToString();
            savedGame.MoveNumber = MoveNumber;
            // get the names of the foundOpponents
            savedGame.FoundOpponents = new List<string>();
            foreach (Opponent foundOpponent in foundOpponents)
            {
                savedGame.FoundOpponents.Add(foundOpponent.Name);
            }
            // anybody still hiding needs to be put in this dictionary along with their hiding place
            savedGame.OpponentDictionary = opponentLocations;

            // Serialize the SavedGame object and write a new SavedGame JSON file
            var jsonString = JsonSerializer.Serialize(savedGame);
            System.IO.File.WriteAllText(path + "\\" + fileName,jsonString);
            Console.WriteLine("File written");
        }

        private bool ValidFileName(string input)
        {
            if( (input.Contains(' ')) || (input.Contains('\\')) ||( input.Contains('/')) )
            {
                return false;
            }
            return true;
        }

        private void GameLoadDialog()
        {
            // ask the user for a filename to save
            bool debugLoad = true;
            string path = Directory.GetCurrentDirectory();
            string defaultFileName = "SavedHideAndSeek01.sav";
            // ask the user for a filename to save
            while (true)
            {
                
                Console.WriteLine("Directory: " + path);
                string anotherFileName;
                string[] fileNames = Directory.GetFiles(path);
                for (int i = 0; i < fileNames.Length; ++i)
                {
                    anotherFileName = fileNames[i];
                    Console.WriteLine(System.IO.Path.GetFileName(anotherFileName));
                }
                Console.WriteLine("About to load "+ defaultFileName);
                Console.Write("Type a different filename or Load again to confirm:");
                string input = Console.ReadLine();
                if (input.ToUpper().ToString() == "LOAD")
                {
                    // continue the load
                    break;
                }
                else
                {
                    // new filename or perhaps garbage
                    if (ValidFileName(input) && !(String.IsNullOrEmpty(input)))
                    {
                        defaultFileName = input;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("A valid filename cannot contain any spaces or slashes. Please try again.");
                        continue;
                    }
                }
            }
            if (debugLoad)
            {
                Console.WriteLine("Leaving input loop");
            }
            // open a savedGame JSON file
            string fileToOpen = path + "\\" + defaultFileName;
            var json = System.IO.File.ReadAllText(fileToOpen);
            // create a new SavedGame object as deserialize the file
             SavedGame savedGame = JsonSerializer.Deserialize<SavedGame>(json);
            House.ClearHidingPlaces();
            CurrentLocation = House.GetLocationByName(savedGame.PlayerLocation);
            foreach (var opponentName in savedGame.OpponentDictionary.Keys)
            {
                var opponent = new Opponent(opponentName);
                var locationName = savedGame.OpponentDictionary[opponentName];
                if (House.GetLocationByName(locationName) is LocationWithHidingPlace location)
                    location.Hide(opponent);
            }
            foundOpponents.Clear();
            foundOpponents.AddRange(savedGame.FoundOpponents.Select(name => new Opponent(name)));
            MoveNumber = savedGame.MoveNumber;
            Console.WriteLine( $"Loaded game from {defaultFileName}");
        }
    }
}
