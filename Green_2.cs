using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Green_2 : Green
    {
        private char[]? _output;
        public char[]? Output => _output;

        public Green_2(string input) : base(input)
        {
            _output = null;
        }

        public override void Review()
        {
            if (Input == null || Input.Length == 0)
            {
                _output = new char[0];
                return;
            }

            string delimiters = @"/\,.?![]{};:()"""" ";

            string lower_letters = Input.ToLower();
            char[] unique_letters = new char[0];
            int[] counts_letters = new int[0];

            for (int i = 0; i < lower_letters.Length; ++i)
            {
                char lower = lower_letters[i];

                if (char.IsLetter(lower) && (i == 0 || delimiters.Contains(lower_letters[i - 1])))
                {
                    if (!unique_letters.Contains(lower))
                    {
                        Array.Resize(ref unique_letters, unique_letters.Length + 1);
                        Array.Resize(ref counts_letters, counts_letters.Length + 1);

                        unique_letters[unique_letters.Length - 1] = lower;
                        counts_letters[counts_letters.Length - 1] = 1;
                    }
                    else
                    {
                        int idx = -1;
                        for (int j = 0; j < unique_letters.Length; j++)
                        {
                            if (unique_letters[j] == lower)
                            {
                                idx = j;
                                break;
                            }
                        }
                        if (idx >= 0) counts_letters[idx]++;
                    }
                }
            }

            bool swapped;
            for (int i = 0; i < unique_letters.Length - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < unique_letters.Length - i - 1; j++)
                {
                    if ((counts_letters[j] < counts_letters[j + 1]) ||
                        (counts_letters[j] == counts_letters[j + 1] && unique_letters[j] > unique_letters[j + 1]))
                    {
                        (unique_letters[j], unique_letters[j + 1]) = (unique_letters[j + 1], unique_letters[j]);
                        (counts_letters[j], counts_letters[j + 1]) = (counts_letters[j + 1], counts_letters[j]);
                        swapped = true;
                    }
                }
                if (!swapped) break;
            }

            _output = unique_letters;
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
                    result += ", ";
                }
            }

            return result;
        }
    }
}