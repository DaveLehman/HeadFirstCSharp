using System;

namespace Null1
{
    class Program
    {
        class Guy
        {
            public string Name { get; set; }
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
