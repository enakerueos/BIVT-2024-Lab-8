using System;

namespace Lab_8
{
    public class Green_4 : Green
    {
        private string[] _output;
        public string[] Output => _output;

        public Green_4(string input) : base(input)
        {
            _output = null;
        }

        public override void Review()
        {
            if (Input == null || Input.Length == 0)
            {
                _output = new string[0];
                return;
            }

            string[] surnames = Input.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            for (int i = 0; i < surnames.Length; ++i)
            {
                for (int j = i + 1; j < surnames.Length; ++j)
                {
                    string lower_first = surnames[i].ToLower();
                    string lower_second = surnames[j].ToLower();
                    int count = 0;

                    int minLength = Math.Min(surnames[i].Length, surnames[j].Length);
                    for (int k = 0; k < minLength; k++)
                    {
                        if (lower_first[k] != lower_second[k])
                        {
                            if (lower_first[k] > lower_second[k])
                            {
                                (surnames[i], surnames[j]) = (surnames[j], surnames[i]);
                            }
                            break;
                        }
                        count++;
                    }

                    if (count == minLength)
                    {
                        if (surnames[i].Length > surnames[j].Length)
                        {
                            string t = surnames[i];
                            surnames[i] = surnames[j];
                            surnames[j] = t;
                        }
                    }
                }
            }

            _output = surnames;
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

