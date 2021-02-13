using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveWithIWorker
{
    class HoneyManufacturer:Bee
    {
        // These constants affect game dynamics and emergent behavior, which affects game aesthetics
        private const float NECTAR_PROCESSED_PER_SHIFT = 33.15F;
        public override float CostPerShift { get { return 1.7F; } }
        public HoneyManufacturer() : base("Honey Manufacturer")
        {
            //Debug.WriteLine("New HoneyManufacturer created");
        }

        /// <summary>
        /// Called by Bee.WorkTheNextShift() if this bee is a HoneyManufacturer bee
        /// </summary>
        protected override void DoJob()
        {
            HoneyVault.ConvertNectarToHoney(NECTAR_PROCESSED_PER_SHIFT);
            //Debug.WriteLine("HoneyManufacturer bee does its job");
        }

    }
}
