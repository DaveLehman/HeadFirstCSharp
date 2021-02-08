using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamageCalculatorWPFFixed
{
    class SwordDamage
    {
        /*
* A guy is creating a dnd game; playing with his formula to calculate sword damage.
* His formula is as follows:
* Sword damage is 3d6 + 3 base HP of damage
* Flaming swords add +2 damage
* Magic swords: 3d6 roll is multiplied by 1.75, rounded down, then add base damage
* and flaming damage, if any.
*/
        private const int BASE_DAMAGE = 3;
        private const int FLAME_DAMAGE = 2;
        // backing fields
        private int roll;
        private bool magic;
        private bool flaming;


        /// <summary>
        /// The constructor calculates damage based on default Magic and Flaming values
        /// // and a starting 3d6 roll.
        /// </summary>
        /// <param name="initialRoll">Starting 3d6 roll</param>
        public SwordDamage(int initialRoll)
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
            Damage = BASE_DAMAGE;
            if (Magic)
            {
                Damage += (int)(Roll * 1.75);
            }
            else
            {
                Damage += Roll;
            }
            if (Flaming) Damage += FLAME_DAMAGE;
        }

    }
}

