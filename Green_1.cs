using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Green_1 : Green
    {
        private (char, double)[] _output;
        public (char, double)[] Output => _output;
        public Green_1(string input) : base(input) 
        {
            _output = null;
        }

        public override void Review()
        {
            if (Input == null || Input.Length == 0)
            {
                _output = new (char, double)[0];
                return;
            }

            string russian_letters = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            int[] count_russian_letters = new int[33];
            int k = 0;

            for (int i = 0; i < Input.Length; i++)
            {
                char lower_letter = char.ToLower(Input[i]);

                if (char.IsLetter(lower_letter))
                {
                    k += 1;
                }

                if (russian_letters.Contains(lower_letter))
                {
                    count_russian_letters[russian_letters.IndexOf(lower_letter)] += 1;
                }
            }

            int unique_letters_count = 0;
            for (int i = 0; i < russian_letters.Length; ++i)
            {
                if (count_russian_letters[i] > 0)
                {
                    unique_letters_count += 1;
                }
            }

            (char, double)[] result = new (char, double)[unique_letters_count];

            int ind = 0;
            for (int i = 0; i < russian_letters.Length; ++i)
            {
                if (count_russian_letters[i] > 0)
                {
                    result[ind] = (russian_letters[i], (double)count_russian_letters[i] / k);
                    ind += 1;
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
                result += $"{_output[i].Item1} - {_output[i].Item2:F4}";
                if (i < _output.Length - 1)
                {
                    result += Environment.NewLine;
                }
            }

            return result;
        }
    }
}