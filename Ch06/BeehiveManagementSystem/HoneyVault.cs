using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    static class HoneyVault
    {
        // These constants affect game dynamics and emergent behavior, which affects game aesthetics
        private const float NECTAR_CONVERSION_RATIO = .19f;
        private const float LOW_LEVEL_WARNING = 10f;

        static private float honey = 25f;       // The beehive's honey stash
        static private float nectar = 100f;     // The beehive's nectar stash


        /// <summary>
        /// HoneyVault's Status Report is the first part of the Queen's status report.
        /// </summary>
        static public string StatusReport { get
            {
                string returnString = $"Vault report:\n{honey:0.0} units of honey\n{nectar:0.0} units of nectar\n";
                if (honey <= LOW_LEVEL_WARNING) returnString += "LOW HONEY - ADD A HONEY MANUFACTURER\n";
                if (nectar <= LOW_LEVEL_WARNING) returnString += "LOW NECTAR - ADD A NECTAR COLLECTOR\n\n";
                return returnString;
            } }

        /// <summary>
        /// Called by HoneyManufacturer.DoJob(). Reduces private nectar field by amount, and adds that amount to private honey field. If nectar is less than amount, converts all available nectar.
        /// </summary>
        /// <param name="amount">How much nectar to convert.</param>
        static public void ConvertNectarToHoney(float amount)
        {
            float nectarToConvert = amount;
            if (nectarToConvert > nectar)
            {
                nectarToConvert = nectar;
            }
            nectar -= nectarToConvert;
            honey += (nectarToConvert * NECTAR_CONVERSION_RATIO);
        }

        /// <summary>
        /// Called by Bee.WorkTheNextShift() and Queen.DoJob(). Reduces private honey field.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>Amount of honey to consume. If there's enough honey to coume amount, returns true, otherwise, returns false.</returns>
        static public bool ConsumeHoney(float amount)
        {
            // think this is a typo ...
            // if (amount >= honey)
            if(honey >= amount)
            {
                honey -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Called By NectarCollector.DoJob(). Adds to private nectar field.
        /// </summary>
        /// <param name="amount">Amount of nectar to add. Must be greater than zero.</param>
        static public void CollectNectar(float amount)
        {
            // think this is a typo if amount greater than zero, adds to the honey field
            if (amount > 0) nectar += amount;
        }

        
    }
}
