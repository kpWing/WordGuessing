using WordGuessing.App.Models;

namespace WordGuessing.App.Interfaces
{
    public interface IWordCreator
    {
        TargetWord Create(string value);
    }
}
