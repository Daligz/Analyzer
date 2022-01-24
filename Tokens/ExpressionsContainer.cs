using Analyzer.Rules;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Analyzer.Tokens
{
    class ExpressionsContainer
    {
        private TokenType tokenType;
        private ICollection<Regex> regex;

        public ExpressionsContainer(TokenType tokenType, ICollection<Regex> regex)
        {
            this.tokenType = tokenType;
            this.regex = regex;
        }

        public TokenType GetTokenType()
        {
            return this.tokenType;
        }

        public ICollection<Regex> GetRegex()
        {
            return this.regex;
        }

        public void ExecuteAction(ref string expression, ICollection<Regex> expressionsDefinitions, TokenType tokenType, Dictionary<TokenType, List<Token>> tokens)
        {
            foreach (Regex expressionDefinition in expressionsDefinitions)
            {
                if (tokenType == TokenType.Identifiers)
                {
                    this.GetIndentifiersAction(ref expression, expressionDefinition, tokenType, tokens);
                    return;
                }
                this.GetDefaultAction(ref expression, expressionDefinition, tokenType, tokens);
            }
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
            if (GetIndentifiersOperationsAction(ref expression, tokenType, tokens)) return;
            Match match = expressionDefinition.Match(expression);
            while (match.Success)
            {
                string[] splittedExpression = Regex.Replace(match.Value, Expressions.whiteSpacesDefinition.ToString(), "").Split(" ");
                if (Expressions.reservedDefinition.IsMatch(splittedExpression[1]))
                {
                    Errors.DataTypeNotFound(splittedExpression[1]);
                    expression = " ";
                    return;
                }
                expression = expressionDefinition.Replace(expression, $"{splittedExpression[0]}", 1);
                tokens[tokenType].Add(new Token(tokenType, tokens[tokenType].Count, splittedExpression[1]));
                match = match.NextMatch();
            }
        }

        private bool GetIndentifiersOperationsAction(ref string expression, TokenType tokenType, Dictionary<TokenType, List<Token>> tokens)
        {
            Regex expressionDefinition = Expressions.operationsDefinition;
            if (expressionDefinition == null || !(expressionDefinition.IsMatch(expression))) return false;
            Match match = expressionDefinition.Match(expression);
            while (match.Success)
            {
                if (!(Expressions.operatorsDefinition.IsMatch(match.Value))) return false;
                Match subMatch = Expressions.operatorsDefinition.Match(match.Value);
                string[] splittedExpression = match.Value.Split(subMatch.Value);
                expression = expression.Replace(splittedExpression[0], "").Replace(splittedExpression[1], "");
                tokens[tokenType].Add(new Token(tokenType, tokens[tokenType].Count, splittedExpression[0]));
                tokens[tokenType].Add(new Token(tokenType, tokens[tokenType].Count, splittedExpression[1].Trim()));
                match = match.NextMatch();
            }
            return false;
        }
    }
}
