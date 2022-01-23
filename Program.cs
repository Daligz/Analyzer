using Analyzer.Tokens;
using System;

namespace Analyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            Parser parser = new Parser(expression);
            parser.compute();
            parser.print();
            parser.check();
        }
    }
}
