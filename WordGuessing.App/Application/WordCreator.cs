using WordGuessing.App.Interfaces;
using WordGuessing.App.Models;

namespace WordGuessing.App.Application
{
    public class WordCreator : IWordCreator
    {
        public TargetWord Create(string value)
        {
            return new TargetWord(value);
        }
    }
}
