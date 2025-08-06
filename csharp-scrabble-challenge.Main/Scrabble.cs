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

        public Scrabble(string word)
        {
            _word = word;
            //TODO: do something with the word variable
        }

        public int score()
        {
            int _score = 0;
            int _multiplier = 1;
            int _balanced_curly = 0;
            int _balanced_square = 0;
            char _opening_bracket = ' ';


            if (!OnlyHasValidChars(_word.ToLower())) { return 0; }
            foreach(char c in _word.ToLower())
            {
                if (c == '{')
                {
                    _balanced_curly++;
                    _multiplier *= 2;
                    _opening_bracket = '{';
                }
                else if (c == '[')
                {
                    _balanced_square++;
                    _multiplier *= 3;
                    _opening_bracket = '[';
                }
                else if(c == ']')
                {
                    if (_multiplier%3 != 0 || _opening_bracket == '{') { return 0;}
                    _balanced_square--;
                    _multiplier /= 3;
                    _opening_bracket = ' ';
                    
                }
                else if (c == '}')
                {
                    if (_multiplier % 2 != 0  || _opening_bracket == '[') { return 0; }
                    _balanced_curly--;
                    _multiplier /= 2;
                    _opening_bracket = ' ';

                }
                _score += _scores[c] * _multiplier;
            }
            if (_balanced_square != 0 || _balanced_curly != 0 || _multiplier != 1) { return 0; }
            return _score;
            //TODO: score calculation code goes here
        }
    }
}
