using System;
using System.Collections.Generic;
using System.Text;

namespace Weapons
{
    class SwordDamage:WeaponDamage
    {
        private const int BASE_DAMAGE = 3;
        private const int FLAME_DAMAGE = 2;
        public SwordDamage(int initialRoll):base(initialRoll)
        {

        }
        protected override void CalculateDamage()
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
