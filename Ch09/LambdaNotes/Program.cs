using System;
using System.Linq;
namespace LambdaNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

        // Use the => operator to create lamba expressions
        public override string ToString()
        {
            return $"{Name} (Issue #{Issue})";
        }
        // can be re-written as
        public override string ToString() => $"{Name} (Issue #{Issue})";

        // the lambda operator defines a lambda expression, which is an anonymous function 
        // defined within a single statement. They look like this:
        // (input-parameters) => expression;
        // input parameters are just like parameters to a function. If only one input param,
        // you can leave off the paranthesis

        // Works on properties because properties are really methods that look like fields
        // DON'T try lamda on fields directly -- you can, but IDE will turn them into properties ...
        // More examples
        public string FunnyThingIHave { get { return "big red shoes"; } }
        public string FunnyThingIHave1 => "big red shoes";

        public float CostPerShift { get { return 1.95f; } }
        public string ScaryThingIHave { get { return $"{scaryThingCount} spiders"; } }
        public void ScareLittleChildren()
        {
            Console.WriteLine($"Boo! Gotcha! Look at my {ScaryThingIHave}");
        }
        // re-written
        public float CostPerShift1 { get => 1.95f; }
        public string ScaryThingIHave1 { get => $"{scaryThingCount} spiders"; }
        public void ScareLittleChildren1() => Console.WriteLine($"Boo! Gotcha! Look at my {ScaryThingIHave}");

        // Conditionals with lambda
        public void Reload()
        {
            if (balls > MAGAZINE_SIZE)
            {
                BallsLoaded = MAGAZINE_SIZE
            } else
            {
                BallsLoaded = balls;
            }
        }
        public void Reload1() => BallsLoaded = balls > MAGAZINE_SIZE ? MAGAZINE_SIZE : balls;

        // switch statement
        var score = 0;
        switch(card.Suit)
        {
            case Suits.Spades:
                score = 0;
                break;
            case Suits.Hearts:
                score = 4;
                break;
            default:
                score = 2;
                break;
        }
    // rewritten
    var score = card.Suit switch
    {
        Suits.Spades => 6;
        Suits.Hearts => 4;
        _ => 2;         // underscore defines the default
    };


    }//end Main


    }

