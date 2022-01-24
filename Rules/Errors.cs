using System;

namespace Analyzer.Rules
{
    public static class Errors
    {
        public static void DataTypeNotFound(string val = "undefined")
        {
            PrintWarning($"| ERROR | Un identificador no puede llamarse como una palabra reservada. [{val}]");
        }

        public static void TerminatorNotFound()
        {
            PrintWarning($"| ERROR | No se declaró el final de la expresión. [;]");
        }

        public static void DisrespectedTerminator(string val = "undefined")
        {
            PrintWarning($"| ERROR | No puedes seguir la expresión después de indicar el final. [{val}]");
        }
        
        public static void WrongVariableFormat(string val = "undefined")
        {
            PrintWarning($"| ERROR | No puedes declarar una variable con caracteres inválidos. [{val}] | (Sólo puedes usar letras)");
        }

        private static void PrintWarning(string message)
        {
            Console.WriteLine("\n" + message);
            Console.WriteLine("\n\n[ No se puede completar el proceso. ]\n\n");
        }
    }
}
