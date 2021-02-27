using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HideAndSeek
{
    public static class House
    {
        // contains a reference to the Entry location, which is the starting location for the player
        public static Location Entry;

        public static Random  Random = new Random();

        // list of locations to make finding easier
        private static IEnumerable<Location> locations;
        /// <summary>
        /// Constructor
        /// </summary>
        static House()
        {
            // sets up the rooms in the House
            Location entry = new Location("Entry");
            Entry = entry;
            Location hallway = new Location("Hallway");
            Location livingRoom = new LocationWithHidingPlace("Living Room", "behind the sofa");
            Location kitchen = new LocationWithHidingPlace("Kitchen", "next to the stove");
            Location bathroom = new LocationWithHidingPlace("Bathroom", "behind the door");
            Location landing = new Location("Landing");
            Location masterBedroom = new LocationWithHidingPlace("Master Bedroom", "in the closet");
            Location masterBath = new LocationWithHidingPlace("Master Bath", "in the bathtub");
            Location secondBathroom = new LocationWithHidingPlace("Second Bathroom", "in the shower");
            Location kidsRoom = new LocationWithHidingPlace("Kids Room", "under the bed");
            Location nursery = new LocationWithHidingPlace("Nursery", "under the crib");
            Location pantry = new LocationWithHidingPlace("Pantry", "inside a cabinet");
            Location attic = new LocationWithHidingPlace("Attic", "in a trunk");
            Location garage = new LocationWithHidingPlace("Garage", "behind the car");

            Entry.AddExit(Direction.East, hallway);
            Entry.AddExit(Direction.Out, garage);
            hallway.AddExit(Direction.Northwest, kitchen);
            hallway.AddExit(Direction.North, bathroom);
            hallway.AddExit(Direction.South, livingRoom);
            hallway.AddExit(Direction.Up, landing);
            landing.AddExit(Direction.Northwest, masterBedroom);
            landing.AddExit(Direction.West, secondBathroom);
            landing.AddExit(Direction.Southwest, nursery);
            landing.AddExit(Direction.South, pantry);
            landing.AddExit(Direction.Southeast, kidsRoom);
            landing.AddExit(Direction.Up, attic);
            masterBedroom.AddExit(Direction.East, masterBath);

            // Add all of the locations to the private locations collection
            locations = new List<Location>() {
                Entry,
                hallway,
                kitchen,
                bathroom,
                livingRoom,
                landing,
                masterBedroom,
                secondBathroom,
                kidsRoom,
                nursery,
                pantry,
                attic,
                garage,
                attic,
                masterBath,
            };

        }

        public static Location GetLocationByName(string name)
        {
            foreach(Location l in locations)
            {
                if (l.Name == name)
                    return l;
            }
            return Entry;
        }

        public static Location RandomExit(Location location)
        {
            // UnitTests indicate we need to sort Exits alphabetically by location Name
            return GetLocationByName(
            location
            .Exits
            .OrderBy(exit => exit.Value.Name)
            .Select(exit => exit.Value.Name)
            .Skip(Random.Next(0, location.ExitList.Count()))
            .First());
        }


        public static void ClearHidingPlaces()
        {
            foreach(var location in locations)
            {
                if (location is LocationWithHidingPlace)
                {
                    LocationWithHidingPlace l = (LocationWithHidingPlace)location;
                    l.CheckHidingPlace();
                }
            }
        }
    }
}
