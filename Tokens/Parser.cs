using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Analyzer.Tokens
{
    class Parser
    {
        private string expression;
        private Dictionary<TokenType, List<Token>> tokens = new Dictionary<TokenType, List<Token>>();
        private List<ExpressionsContainer> expressionsContainers = new List<ExpressionsContainer>();

        public Parser(string expression)
        {
            this.expression = expression;
            foreach(TokenType tokenType in TokenType.GetValues(typeof(TokenType)))
            {
                this.tokens.Add(tokenType, new List<Token>());
                this.expressionsContainers.Add(new ExpressionsContainer(tokenType, Expressions.GetExpressionByToken(tokenType)));
            }
        }

        public void Compute()
        {
            foreach (ExpressionsContainer expressionContainer in this.expressionsContainers)
            {
                expressionContainer.ExecuteAction(ref this.expression, expressionContainer.GetRegex(), expressionContainer.GetTokenType(), this.tokens);
            }
        }

        public void Print()
        {
            Console.WriteLine();
            foreach (KeyValuePair<TokenType, List<Token>> tokenDictionary in this.tokens)
            {
                Console.WriteLine($"{tokenDictionary.Key}:");
                foreach (Token token in tokenDictionary.Value)
                {
                    Console.WriteLine($" - ({(int)token.GetTokenType()}, {token.GetIndex()}) | {token.GetValue()}");
                }
                Console.WriteLine();
            }
        }

        public void Check()
        {
            this.expression = Regex.Replace(expression.Trim(), @"\s+", " ");
            if (String.IsNullOrEmpty(this.expression))
            {
                Console.WriteLine("LA EXPRESIÓN NO TIENE ERRORES!");
                return;
            }
            string[] splittedExpression = this.expression.Split(" ");
            Console.WriteLine($"|X| LA EXPRESIÓN TIENE {splittedExpression.Length} ERRORES |X|");
            foreach (string error in splittedExpression)
            {
                Console.WriteLine($"[ X ] - {error}");
            }
        }
    }
}
