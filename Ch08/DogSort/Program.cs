using System;
using System.Collections;
using System.Collections.Generic;

namespace DogSort
{
    enum Breeds
    {
        Collie = 3,
        Corgi = -9,
        Dachshund = 7,
        Pug = 0,
    }

    class Dog: IComparable<Dog>
    {
        public Breeds Breed { get; set; }
        public string Name { get; set; }
        public int CompareTo(Dog other)
        {
            if (Breed > other.Breed) return -1;
            if (Breed < other.Breed) return 1;
            return -Name.CompareTo(other.Name);
        }
        public override string ToString()
        {
            return $"A {Breed} named {Name}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Dog> dogs = new List<Dog>()
            {
                new Dog() {Breed = Breeds.Dachshund, Name = "Franz" },
                new Dog() {Breed = Breeds.Collie, Name = "Petunia" },
                new Dog() {Breed = Breeds.Pug, Name = "Porkchop" },
                new Dog() {Breed = Breeds.Dachshund, Name = "Brunhilda" },
                new Dog() {Breed = Breeds.Collie, Name = "Zippy" },
                new Dog() {Breed = Breeds.Corgi, Name = "Carrie" },

            };
            dogs.Sort();
            foreach (Dog dog in dogs)
                Console.WriteLine(dog);

        }
    }
}
