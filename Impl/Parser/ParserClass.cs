using ConsoleApp8.Interfaces;
using ConsoleApp8.Intf.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp8.Impl.Parser
{
    public class ParserClass : IParser
    {
        private readonly string _argpol = "--revpol";
        private readonly string _arginf = "--infix";
        private string _string;
        public  ICalc Calc;

        public Stack<string> Numbers { get; private set; } 
            = new Stack<string>();
        public Stack<string> Operations { get; private set; } 
            = new Stack<string>();
        public ParserClass(ICalc calc)
        { Calc = calc; }
        public bool ArgParse(string[] args)
        {
            if (args.Length == 0) 
                throw new BadArgumentException("No argument");
            if (args[0].Equals(_arginf, StringComparison.OrdinalIgnoreCase))
                throw new InfixSupportException("Unsupported notation");
            if (args[0].Equals(_argpol, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
        public void Init(string arg) => _string = arg; 
        public void Parse()
        {
            var rePositiveNumber = new Regex(@"[0-9]+");
            var reNegativeNumber = new Regex(@"-[0-9]+");
            var reOperation = new Regex(@"[\-+*\/]");
            var tmp1 = new List<string>();
            var tmp2 = new List<string>();
            foreach(var i in _string.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (rePositiveNumber.IsMatch(i) || reNegativeNumber.IsMatch(i))
                {
                    tmp1.Add(i);
                    continue;
                }
                if (reOperation.IsMatch(i))
                {
                    tmp2.Add(i);
                    continue;
                }
                throw new BadNumberException($"Invalid character {i}");
            }
            Numbers = new Stack<string>(tmp1.Reverse<string>());
            Operations = new Stack<string>(tmp2.Reverse<string>());
        }
    }
}
