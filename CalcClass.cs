using ConsoleApp8.Interfaces;

namespace ConsoleApp8.Impl
{
    public class CalcClass : ICalc
    {
        private readonly ICalcAdd addIntf;
        private readonly ICalcSubstract substractIntf;
        private readonly ICalcMultiply multiplyIntf;

        private string ClearLeadingZero(string value)
        {
            bool negative = value.StartsWith("-");
            if (negative)
                value = value.Substring(1);
            while (value.StartsWith("0"))
                value = value.Substring(1);
            if (string.IsNullOrEmpty(value))
                value = "0";

            return (negative) ? "-" + value : value;
        }
        private bool IsNegative(string value)
            => value.StartsWith("-");
        private bool IsNegativeResult(string valueA, string valueB)
            => IsNegative(valueA) && IsNegative(valueB);
        private bool IsOneValueNegative(string valueA, string valueB)
            => IsNegative(valueA) || IsNegative(valueB);
        private string ClearNegative(string value)
            => (IsNegative(value)) ? value.Substring(1) : value;
        private string CalcNego(string valueA, string valueB)
        {
            var nego = false;
            if (valueA.Length < valueB.Length) nego = true;
            else if (valueA.Length > valueB.Length) nego = false;
            else if (valueA.Length == valueB.Length)
                for (int i = 0; i < valueA.Length; i++)
                    nego |= valueA[i].ParseChar() < valueB[i].ParseChar();
            return (nego) ? "-" : "";
        }
        public CalcClass(ICalcAdd addIntf, ICalcSubstract substractIntf, ICalcMultiply multiplyIntf)
        {
            this.addIntf = addIntf;
            this.substractIntf = substractIntf;
            this.multiplyIntf = multiplyIntf;
        }

        public string Add(string valueA, string valueB)
        {
            valueA = ClearLeadingZero(valueA);
            valueB = ClearLeadingZero(valueB);

            if (IsNegativeResult(valueA, valueB))
                return "-" + addIntf.Add(
                    ClearNegative(valueA),
                    ClearNegative(valueB)); // -a + -b
            if (IsOneValueNegative(valueA, valueB))
            {
                if (IsNegative(valueA)) // -a + b
                    return Subtract(
                        ClearNegative(valueB),
                        ClearNegative(valueA));
                if (IsNegative(valueB)) // a + -b
                    return Subtract(
                        ClearNegative(valueA),
                        ClearNegative(valueB));  
            }
            return addIntf.Add(valueA, valueB); // a + b
        }

        public string Multiply(string valueA, string valueB)
        {
            valueA = ClearLeadingZero(valueA);
            valueB = ClearLeadingZero(valueB);
            
            return (
                (IsOneValueNegative(valueA, valueB) && 
                !IsNegativeResult(valueA, valueB)) ? "-":"") 
                + ClearLeadingZero( 
                    multiplyIntf.Multiply(
                        ClearNegative(valueA),
                        ClearNegative(valueB)));
        }

        public string Subtract(string valueA, string valueB)
        {
            valueA = ClearLeadingZero(valueA);
            valueB = ClearLeadingZero(valueB);

            if (IsNegativeResult(valueA, valueB)) // -a - -b = -a + b = b - a
                return Subtract(
                    ClearNegative(valueB), 
                    ClearNegative(valueA) ); 
            if (IsOneValueNegative(valueA, valueB)) // -a -b || a - -b
            {
                if (IsNegative(valueA)) // -a - b = - (a+b)
                    return "-" +
                        Add(
                           ClearNegative(valueA),
                           ClearNegative(valueB));
                if (IsNegative(valueB)) // a - -b = a + b
                    return Add(
                        ClearNegative(valueA),
                        ClearNegative(valueB)
                        );
            }

            // a - b
            valueA = ClearNegative(valueA);
            valueB = ClearNegative(valueB);
            return CalcNego(valueA, valueB) +
                ClearLeadingZero(substractIntf.Subtract(valueA, valueB)); ;
        }
    }
}