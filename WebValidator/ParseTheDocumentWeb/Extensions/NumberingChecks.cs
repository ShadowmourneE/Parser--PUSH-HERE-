using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParseTheDocumentWeb.Extensions
{
    public static class NumberingChecks
    {
        //Example: current 1.1.1.3.1 prev 1.1.1.3 check 1.1.1.3==1.1.1.3
        public static bool CheckRoot(string prev, string current)
        {
            if (String.IsNullOrEmpty(prev))
                return true;
            if (String.IsNullOrEmpty(current))
                return true;
            var prevNumbering = prev.Split('.').
                Select(n => int.Parse(n)).
                ToArray();
            var currentNumbering = current.Split('.').
                Select(n => int.Parse(n)).
                Take(prevNumbering.Count()).
                ToArray();
            return prevNumbering.SequenceEqual(currentNumbering);
        }
        //Example: current 1.1.1.4 prev 1.1.1.3.1 check 1.1.1 == 1.1.1 and 4>3
        public static bool CheckNumberingPrev(string prev, string current)
        {
            if (String.IsNullOrEmpty(prev))
                return true;
            if (String.IsNullOrEmpty(current))
                return true;
            var prevNumbering = prev.Split('.').
                Select(n => int.Parse(n)).
                ToArray();
            var currentNumbering = current.Split('.').
                Select(n => int.Parse(n)).
                ToArray();
            int lastIndex = currentNumbering.Count() - 1;
            if (currentNumbering[lastIndex] <= prevNumbering[lastIndex])
            {
                return false;
            }
            lastIndex -= 1;
            prevNumbering = prevNumbering.Take(lastIndex).ToArray();
            currentNumbering = currentNumbering.Take(lastIndex).ToArray();
            return currentNumbering.SequenceEqual(prevNumbering);
        }
        //Example: current 1.1.1.3.2 prev 1.1.1.3.1 check 1.1.1.3 == 1.1.1.3 and 2>1
        public static bool CheckNumberingCurrent(string prev, string current)
        {
            if (String.IsNullOrEmpty(prev))
                return true;
            if (String.IsNullOrEmpty(current))
                return true;
            var prevNumbering = prev.Split('.').
                Select(n => int.Parse(n)).
                ToArray();
            var currentNumbering = current.Split('.').
                Select(n => int.Parse(n)).
                ToArray();
            if (currentNumbering.Last() <= prevNumbering.Last())
            {
                return false;
            }
            int lastIndex = prevNumbering.Count() - 1;
            prevNumbering = prevNumbering.Take(lastIndex).ToArray();
            currentNumbering = currentNumbering.Take(lastIndex).ToArray();
            return prevNumbering.SequenceEqual(currentNumbering);
        }
    }
}
