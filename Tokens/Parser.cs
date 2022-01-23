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
                    string replacer = Regex.Replace(match.Value, @"\s+", " ").Split(" ")[1];
                    this.tokens[TokenType.ReservedWords].Add(new Token(TokenType.ReservedWords, this.tokens[TokenType.ReservedWords].Count, replacer));
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
            else if (Expressions.stringDefinition.IsMatch(this.expression))
            {
                Match match = Expressions.stringDefinition.Match(expression);
                while (match.Success)
                {
                    this.tokens[TokenType.constStrings].Add(new Token(TokenType.constStrings, this.tokens[TokenType.constStrings].Count, match.Value));
                    match = match.NextMatch();
                }
            }
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
