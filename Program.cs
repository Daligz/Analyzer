using Analyzer.Tokens;
using Analyzer.Rules;
using System;

namespace Analyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.Write("Escribe una expresión: ");
                string expression = Console.ReadLine();
                ExpressionsRules.RunChecks(ref expression);
                Parser parser = new Parser(expression);
                parser.Compute();
                parser.Print();
                parser.Check();
                Console.WriteLine("\n\n(Escribe \"q\" para salir)");
                Console.WriteLine("(Presiona cualquier tecla para escribir otra expresión)");
            } while (Console.ReadKey().Key != ConsoleKey.Q);
        }
    }
}
