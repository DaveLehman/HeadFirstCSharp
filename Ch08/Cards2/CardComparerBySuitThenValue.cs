using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Cards2
{
    class CardComparerBySuitThenValue : IComparer<Card>
    {
        public int Compare([AllowNull] Card x, [AllowNull] Card y)
        {
            if (x.Suit > y.Suit)
                return 1;
            if (x.Suit < y.Suit)
                return -1;
            if (x.Value < y.Value)
                    return -1;
            if (x.Value > y.Value)
                    return 1;
            return 0;                              
        }
    }
}
