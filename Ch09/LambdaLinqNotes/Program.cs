using System;
using System.Collections.Generic;
using System.Linq;
namespace LambdaLinqNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new[] { 1, 2, 3, 4, };
            var result = from i in array select i * 2;
            // result will contain the sequence { 2, 4, 6, 8 }
            // the Select method is defined as 
            // IEnumerable<int> IEnumerable<int>.Select<int, int>(Func<int, int> selector)
            // whenever you have a method that takes a Func<int, int> parameter, you can use a 
            // lambda expression to refactor
            var array1 = new[] { 1, 2, 3, 4, };
            var result1 = array.Select(i => i * 2);
            // Therefore, Linq queries can be written as chained linq methods
            int[] values = new int[] { 0, 12, 44, 36, 92, 54, 13, 8 };
            IEnumerable<int> result2 =
                from v in values
                where v < 37
                orderby -v
                select v;
            var result3 = values.Where(v => v < 37).OrderBy(v => -v); //or
            var result4 = values.Where(v => v < 37).OrderByDescending(v => v);
            // that v => v is a lambda identity function that always returns the same thing
            // .OrderByDescending(v => v) reverses the sequence

            // GroupBy method creates group queries from chained methods
            var grouped =
                from card in deck
                group card by card.Suit into suitGroup
                orderby suitGroup.Key descending
                select suitGroup;
            // can use a lambda to group by the card's Suit: card => card.Suit 
            // and another lambda to order the groups by key: group => group.Key
            // so
            var grouped2 = deck.GroupBy(card => card.Suit).OrderByDescending(grouped => grouped.Key);

        }
    }
}
