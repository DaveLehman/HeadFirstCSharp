using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace BeeManagementWithTimer
{
    class Queen:Bee
    {
        // These constants affect game dynamics and emergent behavior, which affects game aesthetics
        private const float EGGS_PER_SHIFT = 0.45F;
        private const float HONEY_PER_UNASSIGNED_WORKER = 0.5F;
        private float eggs;                 // number of eggs
        private float unassignedWorkers;    // number of workers waiting for assignment
        private Bee[] workers;              // array of Bee workers, intially set to 3, one for each of the subclasses
        public override float CostPerShift { get { return 2.15F; } }
        public string StatusReport { get; private set; }


        public Queen() : base("Queen")
        {
            eggs = 0;
            unassignedWorkers = 3;
            workers = new Bee[0];
            AssignBee("Nectar Collector");
            AssignBee("Honey Manufacturer");
            AssignBee("Egg Care");
            //Debug.WriteLine("New Queen created");
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
        /// Called by Bee.WorkTheNextShift() if this bee is a Queen bee
        /// </summary>
        protected override void DoJob()
        {
            // add eggs
            eggs += EGGS_PER_SHIFT;
            // tell the worker bees to work
            foreach (Bee bee in workers)
            {
                bee.WorkTheNextShift();
            }
            // feed honey to the uanassigned workers waiting for work
            HoneyVault.ConsumeHoney(HONEY_PER_UNASSIGNED_WORKER * unassignedWorkers);
            UpdateStatusReport();
            //Debug.WriteLine("Queen bee does its job");
        }

        /// <summary>
        /// Called by Queen.AssignBee(). Expand the workers array by one slot and add a Bee reference.
        /// </summary>
        /// <param name="worker">Worker to add to the workers array</param>
        private void AddWorker(Bee worker)
        {
            if (unassignedWorkers >= 1)
            {
                unassignedWorkers--;
                Array.Resize(ref workers, workers.Length + 1);
                workers[workers.Length - 1] = worker;
            }
        }

        /// <summary>
        /// Called by Click handler for Assign Job and by Queen constructor three times, once for each
        /// of her initial 3 workers.
        /// </summary>
        /// <param name="job">Must be "Nectar Collector","Honey Manufacturer","Egg Care"</param>
        public void AssignBee(string job)
        {
            // takes a parameter with a job name, like "Egg Care" and has a switch with cases
            // that call AddWorker to create a new Bee reference
            switch (job)
            {
                case "Nectar Collector":
                    AddWorker(new NectarCollector());
                    break;
                case "Honey Manufacturer":
                    AddWorker(new HoneyManufacturer());
                    break;
                case "Egg Care":
                    AddWorker(new EggCare(this));
                    break;
                case "Queen":
                default:
                    Debug.WriteLine($"Unexpected value in Queen.AssignBee: job is {job}");
                    break;
            }
            UpdateStatusReport();
            //Debug.WriteLine($"AssignBee called by job {job}");
        }

        /// <summary>
        ///  Called by EggCare.DoJob(). Egg Care bees need to access Queen's eggs field, so they carry
        ///  a reference to their Queen. That in turn allows EggCare.DoJob() to call this Queen method
        /// </summary>
        /// <param name="eggsToConvert"></param>
        public void CareForEggs(float eggsToConvert)
        {
            if (eggs >= eggsToConvert)
            {
                eggs -= eggsToConvert;
                unassignedWorkers += eggsToConvert;
            }
            else
                Debug.WriteLine("CareForEggs() failed to find enough eggs to convert");

        }

        /// <summary>
        /// Called by Queen.AssignBee() and Queen.DoJob(). Updates the StatusReport property, and 
        /// therefore the ComboBox in the XAML, along with
        /// click handlers and Main Window initializer
        /// </summary>
        private void UpdateStatusReport()
        {
            string returnStr = HoneyVault.StatusReport;
            returnStr += $"Egg count: {eggs} \nUnassigned workers: {unassignedWorkers}\n";
            returnStr += $"{WorkerCounts("Nectar Collector")}\n";
            returnStr += $"{WorkerCounts("Honey Manufacturer")}\n";
            returnStr += $"{WorkerCounts("Egg Care")}\n";
            returnStr += $"TOTAL WORKERS: {workers.Length}";
            StatusReport = returnStr;
        }

        /// <summary>
        /// Called by Queen.UpdateStatusReport. Depending on job and number of bees doing that job will print
        /// something like '1 Nectar Collector bee' or '3 Egg Care bees'
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        private string WorkerCounts(string job)
        {
            int count = 0;
            foreach (Bee worker in workers)
                if (worker.Job == job) count++;
            string plural = "s";
            if (count == 1) plural = "";
            return $"{count} {job} bee{plural}";
        }
    }
}
