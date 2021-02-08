using System;
using System.Collections.Generic;
using System.Text;

namespace Jewels
{
    class Locksmith
    {
        // If a safe owner hires a professional locksmith to open their safe, they expect that
        // locksmith to return the cotnents safe and sound. That's exactly what the
        // Locksmith OpenSafe method does.
        public void OpenSafe(Safe safe, SafeOwner owner)
        {
            safe.PickLock(this);
            string safeContents = safe.Open(Combination);
            ReturnContents(safeContents, owner);
        }

        public string Combination { private get; set; }

        protected virtual void ReturnContents(string safeContents, SafeOwner owner)
        {
            owner.ReceiveContents(safeContents);
        }
    }
}
