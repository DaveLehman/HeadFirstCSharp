using System;
using System.Collections.Generic;
using System.Text;

namespace Lumberjacks
{
    enum Flapjack
    {
        Crispy,
        Soggy,
        Browned,
        Banana,
    }
    
    class Lumberjack
    {
        
        public string Name { get; private set; }
        private Stack<Flapjack> flapjackStack = new Stack<Flapjack>();
        public Lumberjack(string name)
        {
            Name = name;
        }
        public void TakeFlapjack(Flapjack flapjack)
        {
             flapjackStack.Push(flapjack);
        }
        public void EatFlapjacks()
        {
            Console.WriteLine($"{Name} is eating flapjacks");
            while(flapjackStack.Count > 0)
            {
                Flapjack flapjack = flapjackStack.Pop();
                switch(flapjack)
                {
                    case Flapjack.Crispy:
                        Console.WriteLine($"{Name} ate a crispy flapjack");
                        break;
                    case Flapjack.Soggy:
                        Console.WriteLine($"{Name} ate a soggy flapjack");
                        break;
                    case Flapjack.Browned:
                        Console.WriteLine($"{Name} ate a browned flapjack");
                        break;
                    case Flapjack.Banana:
                        Console.WriteLine($"{Name} ate a banana flapjack");
                        break;
                    default:
                        Console.WriteLine("Found a bad type of flapjack somehow!");
                        break;
                }
            }
        }

    }
}
