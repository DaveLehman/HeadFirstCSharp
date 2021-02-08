using System;
using System.Collections.Generic;
using System.Text;

namespace DamageCalculator
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
        public const int BASE_DAMAGE = 3;
        public const int FLAME_DAMAGE = 2;

        public int Roll;
        public decimal MagicMultiplier = 1M;
        public int FlamingDamage = 0;
        public int Damage;

        public void CalculateDamage()
        {
            Damage = (int)(Roll * MagicMultiplier) + BASE_DAMAGE + FlamingDamage;
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
        }

        public void SetFlaming(bool isFlaming)
        {
            CalculateDamage();
            if (isFlaming)
            {
                Damage += FLAME_DAMAGE;
            }
        }
    }
}
