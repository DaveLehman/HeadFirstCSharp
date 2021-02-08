using System;

namespace DamageCalcuatorConsoleFixed
{
    class Program
    {
        public static Random random = new Random();
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
            // 2. Use the new RollDice method for the SwordDamage constuctor argument
            SwordDamage damageObj = new SwordDamage(RollDice());


            char userInput;
            int baseRoll;


            while (true)
            {
                Console.WriteLine("0 for no magic/flaming, 1 for magic, 2 for flaming, 3 for both, anything else to quit:");
                userInput = Console.ReadKey(true).KeyChar;
                Console.WriteLine("User input is :" + userInput);
                // bail if not '0' '1' '2' '3'
                if ((userInput != '0') && (userInput != '1') && (userInput != '2') && (userInput != '3'))
                    return;
                damageObj.Roll = RollDice();
                damageObj.Magic = (userInput == '1' || userInput == '3');
                damageObj.Flaming = (userInput == '2' || userInput == '3');
                Console.WriteLine("Rolled " + damageObj.Roll + " for " + damageObj.Damage + " HP\n");

            } // end while
        } // end Main

          // 1. create a static method called RollDice that returns the results of a 3d6 roll. You'll need
          // to store the random instance in a static field instead of a variable so that
          // both main and RollDice can use it 
        static int RollDice()
        {
            return (random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7));
        }
    } // end class Program


}
