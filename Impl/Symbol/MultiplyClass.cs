using ConsoleApp8.Interfaces;
using System;
using System.Linq;

namespace ConsoleApp8.Impl
{
    public class SymbolMultiply : ICalcMultiply
    {
        private readonly ICalcAdd addIntf;
        public SymbolMultiply(ICalcAdd add)
        {
            this.addIntf = add;
        }

        public string Multiply(string valueA, string valueB)
        {
            string result = String.Empty;
            var (ArgMax, ArgMin) = ExtensionClass.StringsToReversedArray(valueA, valueB);
            for (int j = 0; j < ArgMin.Length; j++)
            {
                int carry = 0;
                int multiply = ArgMin[j].ParseChar();
                string respart = String.Empty;
                for (int i = 0; i < ArgMax.Length; i++)
                {
                    var r = ArgMax[i].ParseChar() * multiply + carry;
                    carry = r / 10;
                    r %= 10;
                    respart += r.ToString();
                }
                respart = ((j > 0) ? "0".Repeat(j) : "") + respart;
                result = (!String.IsNullOrEmpty(result))
                    ? addIntf.Add(result, new String(respart.Reverse().ToArray()))
                    : new String(respart.Reverse().ToArray());
            }
            return result;
        }
    }
}
