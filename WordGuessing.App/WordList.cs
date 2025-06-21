using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGuessing.App
{
    public static class WordList
    {
        private static readonly IReadOnlyList<string> _words = new List<string>
        {
            "apple",
            "banana",
            "cherry",
            "date",
            "elderberry",
            "fig",
            "grape",
            "honeydew",
            "kiwi",
            "lemon"
        };

        public static string GetRandomWord()
        {
            var random = new Random();
            var index = random.Next(_words.Count);
            return _words[index];
        }
    }
}
