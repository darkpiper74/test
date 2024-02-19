using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8.Intf.Parser
{
    public interface IParser
    {
        bool ArgParse(string[] args);
        void Init(string arg);
        void Parse();
    }
}
