using System;
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

        public void GetDefaultAction(string expression, Regex expressionDefinition, TokenType tokenType, List<Token> tokens)
        {
            if (expressionDefinition == null || !(expressionDefinition.IsMatch(expression))) return;
            Match match = expressionDefinition.Match(expression);
            while (match.Success)
            {
                tokens.Add(new Token(tokenType, tokens.Count, match.Value));
                match = match.NextMatch();
            }
        }

        public Action<string, Regex, TokenType, List<Token>> GetDefaultAction2()
        {
            return (string expression, Regex expressionDefinition, TokenType tokenType, List<Token> tokens) =>
            {
                if (!(expressionDefinition.IsMatch(expression))) return;
                Match match = expressionDefinition.Match(expression);
                while (match.Success)
                {
                    tokens.Add(new Token(tokenType, tokens.Count, match.Value));
                    match = match.NextMatch();
                }
            };
        }
    }
}
