using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Analyzer.Tokens
{
    class Parser
    {
        private string expression;
        private Dictionary<TokenType, List<Token>> tokens = new Dictionary<TokenType, List<Token>>();
        private ICollection<ExpressionsContainer> expressionsContainers = new List<ExpressionsContainer>();

        public Parser(string expression)
        {
            this.expression = expression;
            foreach(TokenType tokenType in TokenType.GetValues(typeof(TokenType)))
            {
                this.tokens.Add(tokenType, new List<Token>());
                this.expressionsContainers.Add(new ExpressionsContainer(tokenType, Expressions.GetExpressionByToken(tokenType)));
            }
        }

        public void compute()
        {

            foreach (ExpressionsContainer expressionContainer in this.expressionsContainers)
            {
                expressionContainer.ExecuteAction(this.expression, expressionContainer.GetRegex(), expressionContainer.GetTokenType(), this.tokens);
            }
            /*if (Expressions.variableDefinition.IsMatch(this.expression))
            {
                Match match = Expressions.variableDefinition.Match(expression);
                while (match.Success)
                {
                    string replacer = Regex.Replace(match.Value, @"\s+", " ").Split(" ")[1];
                    this.tokens[TokenType.ReservedWords].Add(new Token(TokenType.ReservedWords, this.tokens[TokenType.ReservedWords].Count, replacer));
                    match = match.NextMatch();
                }
            }
            else if (Expressions.operatorsDefinition.IsMatch(this.expression))
            {
                Match match = Expressions.operatorsDefinition.Match(expression);
                while (match.Success)
                {
                    this.tokens[TokenType.Operators].Add(new Token(TokenType.Operators, this.tokens[TokenType.Operators].Count, match.Value));
                    match = match.NextMatch();
                }
            }
            else if (Expressions.stringDefinition.IsMatch(this.expression))
            {
                Match match = Expressions.stringDefinition.Match(expression);
                while (match.Success)
                {
                    this.tokens[TokenType.constStrings].Add(new Token(TokenType.constStrings, this.tokens[TokenType.constStrings].Count, match.Value));
                    match = match.NextMatch();
                }
            } else
            {
                this.tokens[TokenType.Undefined].Add(new Token(TokenType.Undefined, this.tokens[TokenType.Undefined].Count, expression));
            }*/
        }

        public void print()
        {
            Console.WriteLine();
            foreach (KeyValuePair<TokenType, List<Token>> tokenDictionary in this.tokens)
            {
                Console.WriteLine($"{tokenDictionary.Key}:");
                foreach (Token token in tokenDictionary.Value)
                {
                    Console.WriteLine($" - {token.GetTokenType()} | ({(int)token.GetTokenType()}, {token.GetIndex()}) | {token.GetValue()}");
                }
                Console.WriteLine();
            }
        }
    }
}
