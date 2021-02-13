using System;
using System.Collections.Generic;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> myQueue = new Queue<string>();
            myQueue.Enqueue("first in line");
            myQueue.Enqueue("second in line");
            myQueue.Enqueue("third in line");
            myQueue.Enqueue("last in line");

            // Peek looks at the first item in the queue without doing anything
            Console.WriteLine($"Peek() returned:\n{myQueue.Peek()}");
            // Dequeue pulls the next item from the front
            Console.WriteLine($"The first Dequeue() returned: \n{myQueue.Dequeue()}");
            Console.WriteLine($"The second Dequeue() returned: \n{myQueue.Dequeue()}");

            // Clear() removes all
            Console.WriteLine($"Count before Clear():\n{myQueue.Count}");
            myQueue.Clear();
            Console.WriteLine($"Count after Clear():\n{myQueue.Count}");

        }
    }
}
