using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Analyzer.Tokens
{
    public static class Expressions
    {
        //public static Regex mainClassDefinition = new Regex(@"pub\s+class\s+[a-zA-Z]+\s+\{$", RegexOptions.IgnoreCase);

        //public static Regex variableDefinition = new Regex(@"int\s+[a-zA-Z]+\s+=\s+\d;");

        public static Regex reservedDefinition = new Regex(@"int|flo|dou|boo|str|pub|class|print|true|false");

        //public static Regex variableDefinition = new Regex(@"(int|boo|flo|dou|str)\s+[a-zA-Z]+");
        public static Regex variableDefinition = new Regex(@"(int|boo|flo|dou|str)\s+([a-zA-Z]+|([0-9])+|(_))");

        public static Regex operatorsDefinition = new Regex(@"==|>=|<=|!=|=|!|>|<|\+|-|/|%|&&|\*");

        //public static Regex stringDefinition = new Regex("\"[a-zA-Z]+\"");
        public static Regex stringDefinition = new Regex("\"[^\"]*\"");

        //public static Regex decimalDefinition = new Regex("[0-9]*\\.[0-9]+");
        //public static Regex constIntegerDefinition = new Regex("[0-9]+");
        public static Regex constNumeric = new Regex(@"[+-]?([0-9]+\.?[0-9]*|\.[0-9]+)");

        public static Regex specialDefinition = new Regex(";|{|}|\\(|\\)|_");

        public static Regex endsWithTerminator = new Regex(@";$");
        public static Regex notEndsWithTerminator = new Regex(@";+.*");

        // Example: a + b or 5 / 5 or 2 - 2
        public static Regex operationsDefinition = new Regex(@"([a-zA-Z]+\s+(\+|\-|\*|\/|\%)\s+[a-zA-Z]+)|([a-zA-Z]+(\+|\-|\*|\/|\%)[a-zA-Z]+)|(([+-]?(?=\.\d|\d)(?:\d+)?(?:\.?\d*))(?:[eE]([+-]?\d+))?\s+(\+|\-|\*|\/|\%)\s+([+-]?(?=\.\d|\d)(?:\d+)?(?:\.?\d*))(?:[eE]([+-]?\d+))?)|([+-]?(?=\.\d|\d)(?:\d+)?(?:\.?\d*))(?:[eE]([+-]?\d+))?(\+|\-|\*|\/|\%)([+-]?(?=\.\d|\d)(?:\d+)?(?:\.?\d*))(?:[eE]([+-]?\d+))?");

        public static ICollection<Regex> GetExpressionByToken(TokenType tokenType)
        {
            switch (tokenType)
            {
                case TokenType.Identifiers:
                    return new[] { variableDefinition, operationsDefinition };
                case TokenType.Operators:
                    return new[] { operatorsDefinition };
                case TokenType.ConstStrings:
                    return new[] { stringDefinition };
                case TokenType.ReservedWords:
                    return new[] { reservedDefinition };
                case TokenType.ConstNums:
                    return new[] { constNumeric };
                case TokenType.Special:
                    return new[] { specialDefinition };
                default:
                    return null;
            }
        }
    }
}
