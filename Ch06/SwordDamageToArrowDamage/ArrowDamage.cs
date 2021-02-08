using System;
using System.Collections.Generic;
using System.Text;

namespace SwordDamageToArrowDamage
{
    class ArrowDamage
    {
        /*
* A guy is creating a dnd game; playing with his formula to calculate arrow damage.
* His formula is as follows:
* Arrow Base Damage is 1d6 *0.35 HP
* Flaming arrows add +1.25 HP damage
* Magic swords: Base Damage * 2.5 HP
* Result is rounded up
*/
        private const decimal BASE_MULTIPLIER = 0.35M;
        private const decimal MAGIC_MULTIPLIER = 2.5M;
        private const decimal FLAME_DAMAGE = 1.5M;
        // backing fields
        private int roll;
        private bool magic;
        private bool flaming;


        /// <summary>
        /// The constructor calculates damage based on default Magic and Flaming values
        /// // and a starting 3d6 roll.
        /// </summary>
        /// <param name="initialRoll">Starting 3d6 roll</param>
        public ArrowDamage(int initialRoll)
        {
            this.roll = initialRoll;
            CalculateDamage();
        }

        /// <summary>
        /// Contains the calculated damage
        /// </summary>
        public int Damage { get; private set; }

        /// <summary>
        /// Sets or gets the 3d6 roll
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
        /// True if the sword is magic, false otherwiwse
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
        /// True if the sword is flaming, false otherwise
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

        private void CalculateDamage()
        {
            decimal baseDamage = Roll * BASE_MULTIPLIER;
            if (Magic) baseDamage *= MAGIC_MULTIPLIER;
            if (Flaming) Damage = (int)Math.Ceiling(baseDamage + FLAME_DAMAGE);
            else
                Damage = (int)Math.Ceiling(baseDamage);
        }
    }
}
