using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8.Impl
{
    public static class ExtensionClass
    {
        public static int ParseChar(this char ch)
            => int.Parse(ch.ToString());
        public static string Repeat(this string value,int count)
            => string.Join("", Enumerable.Repeat(value, count));
        public static (char[] ArgMax, char[] ArgMin) StringsToReversedArray(string valueA, string valueB)
        {
            var arg1 = ((valueA.Length >= valueB.Length) ? valueA : valueB)
                        .Reverse().ToArray();
            var arg2 = ((valueA.Length >= valueB.Length) ? valueB : valueA)
                        .Reverse().ToArray();
            return (arg1, arg2);
        }
    }
}
