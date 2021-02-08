using System;

namespace DamageCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
 * A guy is creating a dnd game; playing with his formula to calculate sword damage.
 * His formula is as follows:
 * Sword damage is 3d6 + 3 base HP of damage
 * Flaming swords add +2 damage
 * Magic swords: 3d6 roll is multiplied by 1.75, rounded down, then add base damage
 * and flaming damage, if any. 
 * Console app allows multiple dice cases to generate, any of which can 
 * be regular, flaming and/or magic
 */
            SwordDamage damageObj = new SwordDamage();
            Random random = new Random();

            char userInput;
            int baseRoll;

            while(true)
            {
                Console.WriteLine("0 for no magic/flaming, 1 for magic, 2 for flaming, 3 for both, anything else to quit:");
                userInput = Console.ReadKey(true).KeyChar;
                Console.WriteLine("User input is :" + userInput);
                // bail if not '0' '1' '2' '3'
                if ((userInput != '0') && (userInput != '1') && (userInput != '2') && (userInput != '3'))
                    return;  

                baseRoll = random.Next(1, 7) + random.Next(1,7) + random.Next(1, 7);
                damageObj.Roll = baseRoll;
                damageObj.SetMagic(userInput == '1' || userInput == '3');
                damageObj.SetFlaming(userInput == '2' || userInput == '3');
                Console.WriteLine("Rolled " + baseRoll + " for " + damageObj.Damage + " HP\n");
                        //+ damage.Damage + " HP (flaming " + damage.SetFlaming + " magic " + damage.SetMagic );
            
            } // end while
        }
    }
}
