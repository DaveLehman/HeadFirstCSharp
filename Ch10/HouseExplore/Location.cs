﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Linq;

namespace HouseExplore
{
    public class Location
    {

        /// <summary>
        /// The name of this location
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The exits out of this location
        /// </summary>
        public IDictionary<Direction, Location> Exits { get; private set; } = new Dictionary<Direction, Location>();

        /// <summary>
        /// The constructor sets the location name
        /// </summary>
        /// <param name="name">Name of the location</param>
        //public Location(string name) => throw new NotImplementedException();
        public Location(string name)
        {
            Name = name;
        }

        public override string ToString() => Name;

        /// <summary>
        /// Returns a sequence of description of the exits, sorted by direction
        /// </summary>
        //public IEnumerable<string> ExitList => throw new NotImplementedException();
        // this is mine -- they're sorting in a different order
        /*public IEnumerable<string> ExitList
        {
            
            get
            {
                // sort the Dictionary by direction -- A SortedDictionary automatically sorts by key
                SortedDictionary<Direction, Location> tempDict = new SortedDictionary<Direction, Location>(Exits);
        // this doesn't work becaused of the double sort 0,-1,1,-2,2,-3,3,-4,4,-5,5,-6,6
        North, South, East, West, Northeast, Southwest, Southeast, Northwest, Up, Down, In, Out 
                foreach (KeyValuePair<Direction,Location> kvp in tempDict)
                {
                    string s = $" - the {kvp.Value.Name} is {DescribeDirection(kvp.Key)}";
                    yield return s;
                }
            }
               
        }*/
        /// <summary>
        /// Returns a sequence of descriptions of the exits, sorted by direction
        /// </summary>
        public IEnumerable<string> ExitList =>
            Exits
            .OrderBy(keyValuePair => (int)keyValuePair.Key)
            .OrderBy(keyValuePair => Math.Abs((int)keyValuePair.Key))
            .Select(keyValuePair => $"the {keyValuePair.Value} is {DescribeDirection(keyValuePair.Key)}");


        /// <summary>
        /// Adds an exit to this location
        /// </summary>
        /// <param name="direction">Direction of the connecting location</param>
        /// <param name="connectingLocation">Connecting location to add</param>
        public void AddExit(Direction direction, Location connectingLocation)
        {
            Exits.Add(direction, connectingLocation);
            connectingLocation.AddReturnExit(direction, this);
        }

        private void AddReturnExit(Direction direction, Location connectingLocation)
        {
            Exits.Add((Direction)(-(int)direction), connectingLocation);
        }


        /// <summary>
        /// Gets the exit location in a direction
        /// </summary>
        /// <param name="direction">Direction of the exit location</param>
        /// <returns>The exit location, or this if there is no exit in that direction</returns>
        public Location GetExit(Direction direction)
        {
            if (Exits.ContainsKey(direction))
            {
                return Exits[direction];
            }
            else
            {
                return this;
            }
        }
        private string DescribeDirection(Direction d) => d switch
        {
            Direction.Up => "Up",
            Direction.Down => "Down",
            Direction.In => "In",
            Direction.Out => "Out",
            _ => $"to the {d}",
        };


    }
}