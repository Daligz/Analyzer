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
                expressionContainer.ExecuteAction(ref this.expression, expressionContainer.GetRegex(), expressionContainer.GetTokenType(), this.tokens);
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

        public void check()
        {
            this.expression = Regex.Replace(expression.Trim(), @"\s+", " ");
            if (String.IsNullOrWhiteSpace(this.expression))
            {
                Console.WriteLine("LA EXPRESION NO TIENE ERRORES!");
                return;
            }
            string[] splittedExpression = this.expression.Split(" ");
            Console.WriteLine($"|X| LA EXPRESION TIENE {splittedExpression.Length} ERRORES |X|");
            foreach (string error in splittedExpression)
            {
                Console.WriteLine($"[ X ] - {error}");
            }
        }
    }
}
