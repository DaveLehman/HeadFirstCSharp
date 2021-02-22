using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace PowersOfTwo
{
    class PowersOfTwo:IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            var maxPower = Math.Round(Math.Log(int.MaxValue, 2));
            for(int power = 0; power < maxPower; power++)
            {
                yield return (int)Math.Pow(2, power);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
