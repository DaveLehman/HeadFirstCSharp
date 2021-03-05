using System;

namespace Null2
{
    class Program
    {
        // this directive tells the compiler to treat any reference as a non-nullable reference type
        #nullable enable
        // causes squiggles to appear under Name with a warning that you have to give it a value before leaving constructor

        class Guy
        {
            //public string Name { get; set; }
            // Making Name nullable gets rid of the warning, but doesnt prevent Name from never being assigned
            public string? Name { get; set; }
            public int Age { get; set; }
            public override string ToString() => $"a {Age}-year old named {Name}";
        }

        static void Main(string[] args)
        {
            Guy guy;
            guy = new Guy() { Age = 25 };
            // This will generate a null exception
            Console.WriteLine("guy.Name is {0} letters long", guy.Name.Length);
        }
    }
}
