using System;
using System.Collections.Generic;
namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> myStack = new Stack<string>();
            myStack.Push("first in line");
            myStack.Push("second in line");
            myStack.Push("third in line");
            myStack.Push("last in line");

            // Peek looks at the first item in the stack without doing anything
            Console.WriteLine($"Peek() returned:\n{myStack.Peek()}");
            // Dequeue pulls the next item from the front
            Console.WriteLine($"The first Pop() returned: \n{myStack.Pop()}");
            Console.WriteLine($"The second Pop() returned: \n{myStack.Pop()}");

            // Clear() removes all
            Console.WriteLine($"Count before Clear():\n{myStack.Count}");
            myStack.Clear();
            Console.WriteLine($"Count after Clear():\n{myStack.Count}");
        }
    }
}
