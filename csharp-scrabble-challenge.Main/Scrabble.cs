using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        private  Dictionary<char, int> _scores = new Dictionary<char, int> 
        {
            {'a', 1},
            {'b', 3},
            {'c', 3},
            {'d', 2},
            {'e', 1},
            {'f', 4},
            {'g', 2},
            {'h', 4},
            {'i', 1},
            {'j', 8},
            {'k', 5},
            {'l', 1},
            {'m', 3},
            {'n', 1},
            {'o', 1},
            {'p', 3},
            {'q', 10 },
            {'r', 1},
            {'s', 1},
            {'t', 1},
            {'u', 1},
            {'v', 4},
            {'w', 4},
            {'x', 8},
            {'y', 4},
            {'z', 10},
            {'{', 0},
            {'}', 0},
            {'[', 0},
            {']', 0}
        };
        private string _word = "";
        private bool OnlyHasValidChars(string str)
        {
            string lowerStr = str.ToLower();
            foreach (char c in lowerStr)
            {
                if (!_scores.ContainsKey(c))
                {
                    return false;
                }
            }
            return true;
        }

        public string RemoveDashes(string withDashes)
        {   if (!withDashes.Contains("\\")) {  return withDashes; }
            StringBuilder sb = new StringBuilder(withDashes);
            if (withDashes.Contains("\\"))
            {
                int indexOfDash = withDashes.IndexOf('\\');
                //string notValidString = withDashes.Substring(indexOfDash, 2);
                sb.Remove(indexOfDash, 2);
                RemoveDashes(sb.ToString());
            }
            return "";
        }

        private string RemoveNonValidChars(string str)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach(char c in str.ToLower())
            {
                if (_scores.ContainsKey(c))
                {
                    stringBuilder.Append(c);
                }
            }
            return stringBuilder.ToString();
        }
        public Scrabble(string word)
        {
            _word = word;
            //TODO: do something with the word variable
        }

        public void Test()
        {
            Console.WriteLine(RemoveDashes(_word));
            Console.WriteLine(RemoveNonValidChars(_word));
        }

        public int score()
        {
            int _score = 0;
            int _multiplier = 1;
            string notDashes = RemoveDashes(_word);
            string cleanString = RemoveNonValidChars(notDashes);
            foreach(char c in cleanString)
            {
                if (c == '{')
                {
                    _multiplier = 2;
                }
                else if (c == '[')
                {
                    _multiplier = 3;
                }
                else if (c == '}' || c == ']')
                {
                    _multiplier = 1;
                }
                _score += _scores[c] * _multiplier;
            }
            return _score;
            //TODO: score calculation code goes here
        }
    }
}
