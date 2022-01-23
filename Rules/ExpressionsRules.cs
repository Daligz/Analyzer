using Analyzer.Tokens;

namespace Analyzer.Rules
{
    public static class ExpressionsRules
    {
        public static void RunChecks(ref string expression)
        {
            TerminatorCheck(ref expression);
        }

        private static void TerminatorCheck(ref string expression)
        {
            if (Expressions.endsWithTerminator.IsMatch(expression)) return;
            expression = "";
            Errors.TerminatorNotFound();
        }
    }
}
