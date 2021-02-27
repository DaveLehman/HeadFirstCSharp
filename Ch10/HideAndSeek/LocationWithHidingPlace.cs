using System;
using System.Collections.Generic;
using System.Text;

namespace HideAndSeek
{
    public class LocationWithHidingPlace : Location
    {
        /// <summary>
        /// The name of the hiding place in this location
        /// </summary>
        public readonly string HidingPlace;

        /// <summary>
        /// The Opponents hiding in this location's HidingPlace
        /// </summary>
        private List<Opponent> hiddenOpponents = new List<Opponent>();

        /// <summary>
        /// Counstructor sets the lcoation name and hiding place name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="hidingPlace"></param>
        public LocationWithHidingPlace(string name, string hidingPlace) : base(name)
        {
            HidingPlace = hidingPlace;
        }

        public void Hide(Opponent opponent)
        {
            hiddenOpponents.Add(opponent);
        }

        /// <summary>
        /// Checks the hiding place to see if any opponents are there. If any are found, clear them out
        /// </summary>
        /// <returns>any opponents that were found</returns>
        public IEnumerable<Opponent> CheckHidingPlace()
        {
            List<Opponent> foundList = new List<Opponent>(hiddenOpponents);
            hiddenOpponents.Clear();
            return foundList;
        }
    }
}
