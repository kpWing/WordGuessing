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
        public TargetWord(string value)
        {
            Value = value;
        }
        public string Value { get; private set; }
        public string MaskedValue => string.IsNullOrEmpty(Value) ? string.Empty : new string('_', Value.Length);
    }
}
