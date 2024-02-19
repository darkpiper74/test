using ConsoleApp8.Interfaces;

namespace ConsoleApp8.Impl
{
    public class IntSubstract : ICalcSubstract
    {
        public string Subtract(string valueA, string valueB)
        {
            int a = int.Parse(valueA);
            int b = int.Parse(valueB);
            return System.Math.Abs(a - b).ToString();
        }
    }
}
