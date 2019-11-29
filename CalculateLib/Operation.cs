using System;
using System.Linq;
using System.Collections;

namespace CalculateLib
{
    public static class Operation
    {
        public static int SummOddByStep(IEnumerable list, int step)
        {
            return 0;
        }

        public static int SummList(IEnumerable list1, IEnumerable list2)
        {
            foreach (var x in list1) { Console.WriteLine(x); }
            foreach (var x in list2) { Console.WriteLine(x); }
            return 0;
        }

        public static bool IsPaliander(string val)
        {
            string valByCheck = val.Replace(" ", string.Empty);
            return valByCheck.SequenceEqual(valByCheck.Reverse()); ;
        }
    }
}
