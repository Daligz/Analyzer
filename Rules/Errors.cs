using System;
using System.Collections.Generic;
using System.Text;

namespace Analyzer.Rules
{
    public static class Errors
    {
        public static void DataTypeNotFound(string variableValue = "undefined")
        {
            PrintWarning($"| ERROR | Un identificador no puede llamarse como una palabra reservada. [{variableValue}]");
        }

        public static void TerminatorNotFound()
        {
            PrintWarning($"| ERROR | No se declaró el final de la expresión. [;]");
        }

        private static void PrintWarning(string message)
        {
            Console.WriteLine("\n" + message);
            Console.WriteLine("\n\n[ No se puede completar el proceso. ]\n\n");
        }
    }
}
