using System;
using System.Collections.Generic;
using System.Text;

namespace Jewels
{
    class Safe
    {
        // A Safe object keeps valuables in its "contents" field. It doesn't return
        // them unless Open is called with the right combination or if a locksmith
        // picks the lock
        private string contents = "precious jewels";
        private string safeCombination = "12345";

        public string Open(string combination)
        {
            if (combination == safeCombination) return contents;
            else return "";
        }

        // We're going to create a Locksmith class that can pick the combination lock
        // and get the combination by calling the PickLock method and passing in 
        // a reference to itself. The Safe will sue it's writeonly Combination property
        // to give the Locksmith the combination
        public void PickLock(Locksmith lockpicker)
        {
            lockpicker.Combination = safeCombination;
        }
    }
}
