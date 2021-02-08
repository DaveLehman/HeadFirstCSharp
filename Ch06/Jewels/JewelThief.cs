using System;
using System.Collections.Generic;
using System.Text;

namespace Jewels
{
    class JewelThief:Locksmith
    {
        // Uh oh. Looks like there's a burglar, and one who's also a highly skilled Locksmith.
        // JewelThief extends Locksmith s inherits the OpenSafe and Combination properties
        // but ReturnContents steals the jewels instead of returning them. Ingenious.
        private string stolenJewels;
        protected override void ReturnContents(string safeContents, SafeOwner owner)
        {
            stolenJewels = safeContents;
            Console.WriteLine($"I'm stealing the jewels! I stole: {stolenJewels}");
        }
    }
}
