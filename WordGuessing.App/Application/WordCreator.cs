using WordGuessing.App.Models;

namespace WordGuessing.App.Application
{
    public class WordCreator
    {
        public TargetWord Create(string value)
        {
            return new TargetWord(value);
        }
    }
}
