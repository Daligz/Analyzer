using Analyzer.Tokens;
using System;

namespace Analyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Escribe alguna expresión: ");
            string expression = Console.ReadLine();
            Parser parser = new Parser(expression);
            parser.compute();
            parser.print();
            parser.check();
        }
    }
}
