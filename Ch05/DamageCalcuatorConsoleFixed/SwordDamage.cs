using System;
using System.Collections.Generic;
using System.Text;

namespace DamageCalcuatorConsoleFixed
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

        //6. Add a constructor that takes the initial Roll as its parameter. Now that the
        // CalculateDamage() is only called from the property set accessors and constructor,
        // there's no need for another class to call it make it private
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

        // 1. delete the Roll field and replace it with a property named Roll and a backing field
        // named roll. The getter returns the value fo the backing field. The setter updates
        // the backing field, then calls CalculateDamage()
        //public int Roll;
        private int roll;
        /// <summary>
        /// Sets or gets the 3d6 roll
        /// </summary>
        public int Roll
        {
            get { return roll; }
            set { roll = value;
                CalculateDamage();
            }
        }

        // 5a. Delete the MagicMultiplier and Flaming damage fields
        // public decimal MagicMultiplier = 1M;
        //public int FlamingDamage = 0;
        // 4. Create an auto-implemented property named Damage with a public get accessor 
        // and a private set accessor
        //public int Damage;
        /// <summary>
        /// Contains the calculated damage
        /// </summary>
        public int Damage { get; private set; }


        private bool magic;
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

        // 2. Delete the SetFlaming method and replace it with a property named Flaming 
        // and a backing field named flaming. It works like the Roll property -- the getter
        // returns the backing field and the setter updates it and calls CalculateDamage()
        /* public void SetFlaming(bool isFlaming)
         {
             CalculateDamage();
             if (isFlaming)
             {
                 Damage += FLAME_DAMAGE;
             }
         } */
        private bool flaming;
        /// <summary>
        /// True if the sword is flaming, false otherwise
        /// </summary>
        public bool Flaming
        {
            get { return flaming; }
            set { flaming = value;
                CalculateDamage();
            }
        }

        //5b Modify Calculate Damage so it checks the Property Values for the Roll Magic and Flaming 
        // properties and does the entire calculation inside the method
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

        /* 3. Delete SetMagic method and replcate it with a property named Magic and a backing
         * field named magic that works just like the Flaming and Roll properties 
        public void SetMagic(bool isMagic)
        {
            if (isMagic)
            {
                MagicMultiplier = 1.75M;
            }
            else
            {
                MagicMultiplier = 1.0M;
            }
        }*/
    }
}
