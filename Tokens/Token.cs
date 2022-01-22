namespace Analyzer.Tokens
{
    class Token
    {
        private TokenType tokenType;
        private int index;
        private string value;
        private bool ignored;

        public Token(TokenType tokenType, int index, string value, bool ignored = false)
        {
            this.tokenType = tokenType;
            this.index = index;
            this.value = value;
            this.ignored = ignored;
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

        public bool IsIgnored()
        {
            return this.ignored;
        }
    }
}
