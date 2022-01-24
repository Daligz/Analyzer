using Analyzer.Tokens;
using System;
using System.Text.RegularExpressions;

namespace Analyzer.Rules
{
    public static class ExpressionsRules
    {
        public static void RunChecks(ref string expression)
        {
            TerminatorCheck(ref expression);
            VariableCheck(ref expression);
        }

        private static void TerminatorCheck(ref string expression)
        {
            if (Expressions.notEndsWithTerminator.IsMatch(expression))
            {
                string val = Expressions.notEndsWithTerminator.Match(expression).Value;
                if (!(val.Equals(";"))) {
                    Errors.DisrespectedTerminator(val);
                    expression = "";
                    return;
                }
            }
            if (Expressions.endsWithTerminator.IsMatch(expression)) return;
            expression = "";
            Errors.TerminatorNotFound();
        }

        private static void VariableCheck(ref string expression)
        {
            if (!(Expressions.variableDefinition.IsMatch(expression))) return;
            Match match = Expressions.variableDefinition.Match(expression);
            while (match.Success)
            {
                string var = expression.Split(" ")[1];
                if (Expressions.constNumeric.IsMatch(var) || Expressions.specialDefinition.IsMatch(var) || Expressions.operationsDefinition.IsMatch(var))
                {
                    Errors.WrongVariableFormat(var);
                    expression = "";
                    return;
                }
                match = match.NextMatch();
            }
        }
    }
}
