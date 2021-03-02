using System;
using System.Collections.Generic;
using System.Text;

namespace SaveableHideAndSeek
{
    public class Opponent
    {
        public readonly string Name;
        public Opponent(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }

        public Location Hide()
        {
            // Start at the entry, then move through 10 - 50 locations, calling House.RandomExit at each location
            // to find the next location to go to. If the opponent ends up at a location that doesn't have a hiding place,
            // they'll keep calling RandomExit and going to that location until they get to a location with a hiding
            // place, and hide in that location
            var currentlocation = House.Entry;
            int locationsToMoveThrough = House.Random.Next(10, 50);
            for (int i = 1; i <= locationsToMoveThrough; i++)
            {
                currentlocation = House.RandomExit(currentlocation);
            }

            while (!(currentlocation is LocationWithHidingPlace))
            {
                currentlocation = House.RandomExit(currentlocation);
            }

            (currentlocation as LocationWithHidingPlace).Hide(this);
            // cheating so we know where the opponent is hiding
            System.Diagnostics.Debug.WriteLine($"{Name} is hiding {(currentlocation as LocationWithHidingPlace).HidingPlace} in the {currentlocation.Name}");
            return currentlocation;


        }
    }
}
