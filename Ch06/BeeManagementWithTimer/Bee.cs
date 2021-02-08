using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace BeeManagementWithTimer
{
    abstract class Bee
    {
        public virtual float CostPerShift { get; }  // Each subclass overrides with it's own honey cost.
        public string Job { get; private set; } // valid choices are "Nector Collector", "Honey Manufacturer",
                                                // "Egg Care", "Queen"

        public Bee(string job)
        {
            Job = job;
        }

        // When you press the button to work the next shift, the event handler calls Queen's
        // WorkTheNextShift method, which is inherited from Bee. Here's what happens next:
        // Bee.WorkTheNextShift calls HoneyVault.ConsumeHoney(HoneyConsumed) using the 
        // CostPerShift property (which each subclass overrides with a different value) to determine
        // how much honey she needs to work.
        //
        // Bee.WorkTheNextShift then calls DoJob, which the Queen also overrides
        //
        // Queen.DoJob adds 0.45 eggs to her private eggs field. The EggCare bee will call her
        // CareForEggs method, which decreases eggs and increases unassigned workers
        //
        // Then it uses a foreach loop to call each worker's WorkTheNextShift method
        // It consumes honey for each unassigned worker
        // Finally it calls its UpdateStatusReport method

        /// <summary>
        /// Called by MainWindow.xaml.cs's Work The Next Shift button's click handler on its own internal
        /// queen instance as well as Queen.DoJob(). If enough honey is available to do a Job, call DoJob().
        /// </summary>
        public void WorkTheNextShift()
        {
            //Debug.WriteLine($"Trying to consume {CostPerShift} honey so we can do a job");
            if (HoneyVault.ConsumeHoney(CostPerShift))
            {
                DoJob();
            }
            else
            {
                //Debug.WriteLine("Bee.WorkTheNextShift can't find enough honey");
            }
        }

        /// <summary>
        /// Should never be called. Each subclass of Bee overrides this method with it's own DoJob()
        /// </summary>
        protected virtual void DoJob()
        {
            /* shouldn't be called */
            Debug.WriteLine("Unexpected Bee.DoJob called!");
        }
    }
}
