using System;
using System.Collections.Generic;
using System.Text;

namespace EnumerableSequence
{
    class ManualSportsSequence:IEnumerable<Sport>
    {
        public IEnumerator<Sport> GetEnumerator()
        {
            return new ManualSportEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
