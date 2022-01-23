namespace Analyzer.Tokens
{
    class Token
    {
        private TokenType tokenType;
        private int index;
        private string value;

        public Token(TokenType tokenType, int index, string value)
        {
            this.tokenType = tokenType;
            this.index = index;
            this.value = value;
        }

        public TokenType GetTokenType()
        {
            return this.tokenType;
        }

        public int GetIndex()
        {
            return this.index;
        }

        public string GetValue()
        {
            return this.value;
        }
    }
}
