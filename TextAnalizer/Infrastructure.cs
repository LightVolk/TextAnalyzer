using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer
{
    public static class Infrastructure
    {
        /// <summary>
        /// Calculate and manipulate digit
        /// </summary>
        /// <param name="originDigitBuilder">origin digit builder</param>
        /// <param name="digit">digit</param>
        /// <param name="increment">increment</param>
        /// <returns>new digit</returns>
        public static int CalculateDigit(StringBuilder originDigitBuilder, int digit, int increment)
        {
            digit += increment;
            var originalDigitLenght = originDigitBuilder.Length;
            var currentDigitString = digit.ToString();
            if (currentDigitString.Length > originalDigitLenght)
            {
                currentDigitString = ShiftStringRight(currentDigitString);
                Int32.TryParse(currentDigitString, out digit);
            }

            return digit;
        }

        /// <summary>
        /// shift string 1 right
        /// </summary>
        /// <param name="input">input string</param>
        /// <returns>new string</returns>
        private static string ShiftStringRight(string input)
        {
            var lenght = input.Length;
            return input.Substring(1, lenght - 1);
        }
    }
}
