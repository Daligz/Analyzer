using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Analyzer.Tokens
{
    class Parser
    {
        private string expression;
        private Dictionary<TokenType, List<Token>> tokens = new Dictionary<TokenType, List<Token>>();

        public Parser(string expression)
        {
            this.expression = expression;
            foreach(TokenType tokenType in TokenType.GetValues(typeof(TokenType)))
            {
                this.tokens.Add(tokenType, new List<Token>());
            }
        }

        public void compute()
        {

            if (Expressions.variableDefinition.IsMatch(this.expression))
            {
                Match match = Expressions.variableDefinition.Match(expression);
                while (match.Success)
                {
                    this.tokens[TokenType.ReservedWords].Add(new Token(TokenType.ReservedWords, this.tokens[TokenType.ReservedWords].Count, match.Value));
                    match = match.NextMatch();
                }
            }
            else if (Expressions.mainClassDefinition.IsMatch(this.expression))
            {
                Match match = Expressions.mainClassDefinition.Match(expression);
                while (match.Success)
                {
                    this.tokens[TokenType.ReservedWords].Add(new Token(TokenType.ReservedWords, this.tokens[TokenType.ReservedWords].Count, match.Value));
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
        }

        public void print()
        {
            foreach (KeyValuePair<TokenType, List<Token>> tokenDictionary in this.tokens)
            {
                foreach (Token token in tokenDictionary.Value)
                {
                    Console.WriteLine($"{token.GetTokenType()} | ({(int)token.GetTokenType()}, {token.GetIndex()}) | {token.GetValue()}");
                }
            }
        }
    }
}
