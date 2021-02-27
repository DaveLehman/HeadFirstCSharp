using System;
using System.Collections.Generic;
using System.Text;

namespace HouseExplore
{
    public static class House
    {
        // contains a reference to the Entry location, which is the starting location for the player
        public static Location Entry;
        static House()
        {
            // sets up the rooms in the House
            Location entry = new Location("Entry");
            Entry = entry;
            // create a separate Location object for each room in the house ...
            // and link them together using Add Exit
            Location garage = new Location("Garage");
            garage.AddExit(Direction.In, entry);
            Location hallway = new Location("Hallway");
            hallway.AddExit(Direction.West, entry);
            Location kitchen = new Location("Kitchen");
            kitchen.AddExit(Direction.Southeast, hallway);
            Location bathroom = new Location("Bathroom");
            bathroom.AddExit(Direction.South, hallway);
            Location livingRoom = new Location("Living Room");
            livingRoom.AddExit(Direction.North, hallway);
            Location landing = new Location("Landing");
            landing.AddExit(Direction.Down, hallway);
            Location masterBedroom = new Location("Master Bedroom");
            masterBedroom.AddExit(Direction.Southeast, landing);
            Location masterBath = new Location("Master Bath");
            masterBath.AddExit(Direction.West, masterBedroom);
            Location secondBathroom = new Location("Second Bathroom");
            secondBathroom.AddExit(Direction.East, landing);
            Location nursery = new Location("Nursery");
            nursery.AddExit(Direction.Northeast, landing);
            Location pantry = new Location("Pantry");
            pantry.AddExit(Direction.North, landing);
            Location kidsRoom = new Location("Kids Room");
            kidsRoom.AddExit(Direction.Northwest, landing);
            Location attic = new Location("Attic");
            attic.AddExit(Direction.Down, landing);
            
        }
    }
}
