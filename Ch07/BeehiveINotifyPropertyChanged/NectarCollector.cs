using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveINotifyPropertyChanged
{
    class NectarCollector:Bee
    {
        // These constants affect game dynamics and emergent behavior, which affects game aesthetics
        private const float NECTAR_COLLECTED_PER_SHIFT = 33.25F;
        public override float CostPerShift { get { return 1.95F; } }
        public NectarCollector() : base("Nectar Collector")
        {
            //Debug.WriteLine("New NectarCollector created");
        }

        /// <summary>
        /// Called by Bee.WorkTheNextShift() if this bee is a NectarCollector bee
        /// </summary>
        protected override void DoJob()
        {
            HoneyVault.CollectNectar(NECTAR_COLLECTED_PER_SHIFT);
            //Debug.WriteLine("NectarCollector bee does its job");
        }
    }
}
