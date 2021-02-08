using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace DamageCalculator2
{
    class SwordDamage
    {
        public const int BASE_DAMAGE = 3;
        public const int FLAME_DAMAGE = 2;

        public int Roll;
        public decimal MagicMultiplier = 1M;
        public int FlamingDamage = 0;
        public int Damage;

        public void CalculateDamage()
        {
            Damage = (int)(Roll * MagicMultiplier) + BASE_DAMAGE + FlamingDamage;
            Debug.WriteLine($"CalculateDamage finished: {Damage} (roll: {Roll})");
        }

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
            Debug.WriteLine($"SetMagic finished: {Damage} (roll: {Roll})");
        }

        public void SetFlaming(bool isFlaming)
        {
            CalculateDamage();
            if (isFlaming)
            {
                Damage += FLAME_DAMAGE;
            }
            Debug.WriteLine($"SetFlaming finished: {Damage} (roll: {Roll})");
        }
    }

    /*
     * There's a subtle bug here. This class worked find in the Console App because the
     * console app always did the calls in the same order. Now that we're in a WPF, we
     * just ported over the SwordDamage thinking that it ought to work, since it was
     * 'debugged' in the console.
     * 
     * But the console app only ran the calls in one particular order -- the way according to 
     * how the class was written. Now that we're a WPF app, user clicks are determining what gets 
     * called when.
     * Roll gets called (12)
     * SetFlaming adds the extra 2hp of damage to the damage field
     * Then SetMagic gets called, and then CqalculateDamage which resets the Damage field
     * and discards the extra flaming damage
     * 
     * 
     */
}
