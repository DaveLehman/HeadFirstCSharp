using System;
using System.Collections.Generic;
using System.Text;

namespace LazyEvaluation
{
    class PrintWhenGetting
    {
        private int instanceNumber;
        public int InstanceNumber
        {
            set { instanceNumber = value; }
            get
            {
                Console.WriteLine($"Getting #{instanceNumber}");
                return instanceNumber;
            }
        }
    }
}
