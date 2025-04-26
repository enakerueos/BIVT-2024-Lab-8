using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Green_3 : Green
    {
        private string[]? _output;
        private string _sequence;
        public string[]? Output => _output;

        public Green_3(string input, string sequence) : base(input)
        {
            _output = null;
            _sequence = sequence;
        }

        public override void Review()
        {
            if (Input == null || Input.Length == 0)
            {
                _output = new string[0];
                return;
            }

            string delimiters = @"/\,.?![]{};:()""""'' ";
            string lower_input = Input.ToLower();
            string lowerseq = _sequence.ToLower();

            string[] words = lower_input.Split(delimiters.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string[] result = new string[0];

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];

                bool valid = true;
                foreach (char c in word)
                {
                    if (!char.IsLetter(c))
                    {
                        valid = false;
                        break;
                    }
                }

                if (!valid)
                {
                    continue;
                }

                if (word.Contains(lowerseq))
                {
                    bool t = false;
                    for (int j = 0; j < result.Length; j++)
                    {
                        if (result[j] == word)
                        {
                            t = true;
                            break;
                        }
                    }

                    if (!t)
                    {
                        Array.Resize(ref result, result.Length + 1);
                        result[^1] = word;
                    }
                }
            }

            _output = result;
        }

        public override string ToString()
        {
            if (_output == null || _output.Length == 0)
            {
                return "";
            }

            string result = "";

            for (int i = 0; i < _output.Length; ++i)
            {
                result += $"{_output[i]}";
                if (i < _output.Length - 1)
                {
                    result += Environment.NewLine;
                }
            }

            return result;
        }
    }
}

