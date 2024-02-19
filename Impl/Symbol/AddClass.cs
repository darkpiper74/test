using ConsoleApp8.Interfaces;
using System;
using System.Linq;

namespace ConsoleApp8.Impl
{
    public class SymbolAdd : ICalcAdd
    {
        public string Add(string valueA, string valueB)
        {
            bool carryFlag = false;
            string result = String.Empty;
            var (ArgMax, ArgMin) = ExtensionClass.StringsToReversedArray(valueA, valueB);
            for (int i = 0; i < ArgMax.Length; i++)
            {
                var r = ((i < ArgMax.Length) ? ArgMax[i].ParseChar() : 0)
                      + ((i < ArgMin.Length) ? ArgMin[i].ParseChar() : 0)
                      + ((carryFlag) ? 1 : 0);
                carryFlag = r >= 10;
                result += (!carryFlag) ? r.ToString() : (r % 10).ToString();
            }
            return new String(result.Reverse().ToArray());
        }
    }

}
