using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveINotifyPropertyChanged
{
    class EggCare:Bee
    {
        // These constants affect game dynamics and emergent behavior, which affects game aesthetics
        private const float CARE_PROGRESS_PER_SHIFT = 0.15F;
        public override float CostPerShift { get { return 1.35F; } }

        private readonly Queen myQueen;
        public EggCare(Queen queenRef) : base("Egg Care")
        {
            myQueen = queenRef;
            //Debug.WriteLine("New EggCare created");
        }

        /// <summary>
        /// Called by Bee.WorkTheNextShift() if this bee is a EggCare bee
        /// </summary>
        protected override void DoJob()
        {
            myQueen.CareForEggs(CARE_PROGRESS_PER_SHIFT);
            //Debug.WriteLine("EggCare bee does its job");
        }
    }
}
