using System;
using System.Collections.Generic;
using System.Text;

namespace EnumerableDucksAndBirds
{
    /* Since all Ducks are Birds, covariance lets us convert a collection of Ducks
     * to a collection of Birds. That can be really useful if you have to pass a List<Duck>
     * to a method that only accepts a List<Bird>
     * */
    enum KindOfDuck
    {
        Mallard,
        Muscovy,
        Loon,
    }
    class Duck:Bird
    {
        public int Size { get; set; }
        public KindOfDuck Kind { get; set; }
        public override string ToString()
        {
            return $"A {Size}-inch {Kind}";
        }
    }
}
