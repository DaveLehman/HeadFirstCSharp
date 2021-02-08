using System;
using System.Collections.Generic;
using System.Text;

namespace Jewels
{
    class SafeOwner
    {
        // The SafeOwner is forgetful and occasionally forgets their extremely secure safe password
        private string valuables = "";
        public void ReceiveContents(string safeContents)
        {
            valuables = safeContents;
            Console.WriteLine($"Thank you for returning my {valuables}!");
        }
    }
}
