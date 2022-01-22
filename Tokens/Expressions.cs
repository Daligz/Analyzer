using System.Text.RegularExpressions;

namespace Analyzer.Tokens
{
    public static class Expressions
    {
        public static Regex mainClassDefinition = new Regex(@"pub\s+class\s+[a-zA-Z]+\s+\{$", RegexOptions.IgnoreCase);

        public static Regex endClassDefinition = new Regex(@"\};");

        public static Regex variableDefinition = new Regex(@"int\s+[a-zA-Z]+\s+=\s+\d;");

        public static Regex operatorsDefinition = new Regex(@"==|>=|<=|!=|=|!|>|<");
    }
}
