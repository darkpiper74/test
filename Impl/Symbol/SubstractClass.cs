using ConsoleApp8.Interfaces;
using System;
using System.Linq;

namespace ConsoleApp8.Impl
{
    public class SymbolSubstract : ICalcSubstract
    {
        public string Subtract(string valueA, string valueB)
        {
            bool carryFlag = false;
            string result = String.Empty;
            var (ArgMax, ArgMin) = ExtensionClass.StringsToReversedArray(valueA, valueB);
            for (int i = 0; i < ArgMax.Length; i++)
            {
                var r1 = ((i < ArgMax.Length) ? ArgMax[i].ParseChar() : 0)
                         - ((carryFlag) ? 1 : 0);
                var r2 = (i < ArgMin.Length) ? ArgMin[i].ParseChar() : 0;
                carryFlag = r1 < r2;
                var r = ((carryFlag) ? 10 : 0) + r1 - r2;
                result += r.ToString();
            }
            return new String(result.Reverse().ToArray());
        }
    }
}
