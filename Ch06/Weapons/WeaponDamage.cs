using System;
using System.Collections.Generic;
using System.Text;

namespace Weapons
{
    class WeaponDamage
    {
        /* 2. Implement the WeaponDamage class and make it match the class diagram. Here are
         * a few things to consider:
         *  * The properties in WeaponDamage are almost identical to the proeprties in the SwordDamage
         *      and ArrowDamage classes at the beginning of the chapter. There's just one keyword different
         *  * Don't put any code in the CalculateDamage class. It needs to be virtual, it can't be private
         *  * Add a constructor that sets the starting roll
         * 
         */
        // backing fields
        private int roll;
        private bool magic;
        private bool flaming;

        // //////////////////////////    PROPERTIES     //////////////////////////////
        /// <summary>
        /// Contains the calculated damage
        /// </summary>
        public int Damage { get; protected set; }

        /// <summary>
        /// Sets or gets the roll
        /// </summary>
        public int Roll
        {
            get { return roll; }
            set
            {
                roll = value;
                CalculateDamage();
            }
        }

        /// <summary>
        /// True if the weapon is magic, false otherwise
        /// </summary>
        public bool Magic
        {
            get { return magic; }
            set
            {
                magic = value;
                CalculateDamage();
            }
        }

        /// <summary>
        /// True if the weapon is flaming, false otherwise
        /// </summary>
        public bool Flaming
        {
            get { return flaming; }
            set
            {
                flaming = value;
                CalculateDamage();
            }
        }
        // //////////////////////////   CONSTRUCTOR    ///////////////////////////////
        public WeaponDamage(int startingRoll)
        {
            roll = startingRoll;
            CalculateDamage();
        }

        // //////////////////////// METHODS   ////////////////////////////////////////
        protected virtual void CalculateDamage()
        {
            /* The subclasses override this */
        }

    }
}
