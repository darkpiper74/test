using ConsoleApp8.Impl;
using ConsoleApp8.Impl.Parser;
using System;

namespace ConsoleApp8
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var CalcSymbol = new CalcClass(
                new SymbolAdd(),
                new SymbolSubstract(),
                new SymbolMultiply(new SymbolAdd())
                );
            var par = new ParserClass( CalcSymbol );
            try
            {
                if (par.ArgParse(args))
                {
                    par.Init(Console.In.ReadLine());
                    par.Parse();
                    foreach (var i in par.Operations)
                    {

                        switch (i)
                        {
                            case "+":
                                par.Numbers.Push(
                                    par.Calc.Add(
                                        par.Numbers.Pop(),
                                        par.Numbers.Pop())
                                    );
                                break;
                            case "-":
                                par.Numbers.Push(
                                    par.Calc.Subtract(
                                        par.Numbers.Pop(),
                                        par.Numbers.Pop())
                                    );
                                break;
                            case "*":
                                par.Numbers.Push(
                                    par.Calc.Multiply(
                                        par.Numbers.Pop(),
                                        par.Numbers.Pop())
                                    );
                                break;
                            case "/":
                                throw new IntDivideSupportException("Unsupported operation");
                        }
                    }
                    Console.Out.WriteLine(par.Numbers.Pop());
                    return 0;
                }
            }catch(BadArgumentException ex)
            {
                Console.Error.WriteLine(ex.Message);
                return 1;
            }
            catch (InfixSupportException ex)
            {
                Console.Error.WriteLine(ex.Message);
                return 2;
            }
            catch (IntDivideSupportException ex)
            {
                Console.Error.WriteLine(ex.Message);
                return 3;
            }
            catch (BadNumberException ex)
            {
                Console.Error.WriteLine(ex.Message);
                return 4;
            }
            return 5;
        }
    }
}
