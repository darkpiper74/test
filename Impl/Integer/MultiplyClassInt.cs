using ConsoleApp8.Interfaces;

namespace ConsoleApp8.Impl
{
    public class IntMultiply : ICalcMultiply
    {
        public string Multiply(string valueA, string valueB)
        {
            int a = int.Parse(valueA);
            int b = int.Parse(valueB);
            return (a * b).ToString();
        }
    }
}
