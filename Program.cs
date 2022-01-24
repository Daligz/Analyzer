using Analyzer.Tokens;
using Analyzer.Rules;
using System;

namespace Analyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Escribe alguna expresión: ");
            string expression = Console.ReadLine();
            ExpressionsRules.RunChecks(ref expression);
            Parser parser = new Parser(expression);
            parser.Compute();
            parser.Print();
            parser.Check();
        }
    }
}
