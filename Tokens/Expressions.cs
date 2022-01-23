using System.Text.RegularExpressions;

namespace Analyzer.Tokens
{
    public static class Expressions
    {
        //public static Regex mainClassDefinition = new Regex(@"pub\s+class\s+[a-zA-Z]+\s+\{$", RegexOptions.IgnoreCase);

        //public static Regex variableDefinition = new Regex(@"int\s+[a-zA-Z]+\s+=\s+\d;");

        public static Regex reservedDefinition = new Regex(@"int|flo|dou|boo|str|pub|class|print|true|false");

        public static Regex variableDefinition = new Regex(@"(int|boo|flo|dou|str)\s+[a-zA-Z]+");

        public static Regex operatorsDefinition = new Regex(@"==|>=|<=|!=|=|!|>|<|\+|-|/|%|&&|\*");

        //public static Regex stringDefinition = new Regex("\"[a-zA-Z]+\"");
        public static Regex stringDefinition = new Regex("\"[^\"]*\"");

        //public static Regex decimalDefinition = new Regex("[0-9]*\\.[0-9]+");
        //public static Regex constIntegerDefinition = new Regex("[0-9]+");
        public static Regex constNumeric = new Regex(@"[+-]?([0-9]+\.?[0-9]*|\.[0-9]+)");

        public static Regex specialDefinition = new Regex(";|{|}|\\(|\\)");

        public static Regex GetExpressionByToken(TokenType tokenType)
        {
            switch (tokenType)
            {
                case TokenType.Operators:
                    return operatorsDefinition;
                case TokenType.ConstStrings:
                    return stringDefinition;
                case TokenType.ReservedWords:
                    return reservedDefinition;
                case TokenType.Identifiers:
                    return variableDefinition;
                case TokenType.ConstNums:
                    return constNumeric;
                case TokenType.Special:
                    return specialDefinition;
                default:
                    return null;
            }
        }
    }
}
