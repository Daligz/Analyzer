using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Analyzer.Tokens
{
    class ExpressionsContainer
    {
        private TokenType tokenType;
        private Regex regex;

        public ExpressionsContainer(TokenType tokenType, Regex regex)
        {
            this.tokenType = tokenType;
            this.regex = regex;
        }

        public TokenType GetTokenType()
        {
            return this.tokenType;
        }

        public Regex GetRegex()
        {
            return this.regex;
        }

        public void ExecuteAction(ref string expression, Regex expressionDefinition, TokenType tokenType, Dictionary<TokenType, List<Token>> tokens)
        {
            if (tokenType == TokenType.Identifiers)
            {
                this.GetIndentifiersAction(ref expression, expressionDefinition, tokenType, tokens);
                return;
            }
            this.GetDefaultAction(ref expression, expressionDefinition, tokenType, tokens);
        }

        private void GetDefaultAction(ref string expression, Regex expressionDefinition, TokenType tokenType, Dictionary<TokenType, List<Token>> tokens)
        {
            if (expressionDefinition == null || !(expressionDefinition.IsMatch(expression))) return;
            Match match = expressionDefinition.Match(expression);
            while (match.Success)
            {
                expression = Regex.Replace(expression, expressionDefinition.ToString(), "");
                tokens[tokenType].Add(new Token(tokenType, tokens[tokenType].Count, match.Value));
                match = match.NextMatch();
            }
        }

        private void GetIndentifiersAction(ref string expression, Regex expressionDefinition, TokenType tokenType, Dictionary<TokenType, List<Token>> tokens)
        {
            if (expressionDefinition == null || !(expressionDefinition.IsMatch(expression))) return;
            Match match = expressionDefinition.Match(expression);
            while (match.Success)
            {
                string[] splittedExpression = match.Value.Split(" ");
                expression = expressionDefinition.Replace(expression, $"{splittedExpression[0]}", 1);
                tokens[tokenType].Add(new Token(tokenType, tokens[tokenType].Count, splittedExpression[1]));
                match = match.NextMatch();
            }
        }
    }
}
