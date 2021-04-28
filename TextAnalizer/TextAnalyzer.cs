using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer.Text
{
    public class TextAnalyzer
    {
        /// <summary>
        /// modify text
        /// </summary>
        /// <param name="text_in">input text</param>
        /// <param name="increment">increment</param>
        /// <returns></returns>
        public string ModifyText(string text_in, int increment)
        {
            if (string.IsNullOrEmpty(text_in)) return string.Empty;
            if (increment < 0) return string.Empty;

            var lenght = text_in.Length;
            var digitBuilder = new StringBuilder();
            var resultBuilder = new StringBuilder(text_in.Length);

            for (int ch = 0; ch < text_in.Length; ch++)
            {
                var letter = text_in[ch];
                if (Char.IsDigit(letter))
                {
                    digitBuilder.Append(letter);
                    continue;
                }

                if (digitBuilder.Length <= 0) // just string
                {
                    resultBuilder.Append(letter);
                    continue;
                }

                //find number
                var digitResult = Int32.TryParse(digitBuilder.ToString(), out int digit);
                if (digitResult)
                {
                    digit = Infrastructure.CalculateDigit(digitBuilder, digit, increment);

                    resultBuilder.Append(digit.ToString());
                    resultBuilder.Append(letter);
                    digitBuilder.Clear();
                }
            }

            if (digitBuilder.Length > 0) //find last number in string
            {
                var digitResult = Int32.TryParse(digitBuilder.ToString(), out int digit);
                if (digitResult)
                {
                    digit = Infrastructure.CalculateDigit(digitBuilder, digit, increment);
                    resultBuilder.Append(digit.ToString());
                }
            }

            return resultBuilder.ToString();
        }

      
    }
}
