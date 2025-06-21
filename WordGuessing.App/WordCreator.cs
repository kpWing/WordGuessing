namespace WordGuessing.App
{
    public class WordCreator
    {
        public TargetWord Create(string value)
        {
            return new TargetWord(value);
        }

    }

    public class TargetWord
    {
        private char[] _revealedWord;

        public TargetWord(string value)
        {
            Value = value;
            _revealedWord = MaskedValue.ToArray();
        }
        public string Value { get; private set; }
        public string MaskedValue => string.IsNullOrEmpty(Value) ? string.Empty : new string('_', Value.Length);

        public string GetRevealedWord(char c)
        {
            for (var i = 0; i < Value.Length; i++)
            {
                if (char.ToUpper(Value[i]) == char.ToUpper(c))
                {
                    _revealedWord[i] = Value[i];
                }
            }
            return new string(_revealedWord);
        }
    }
}
