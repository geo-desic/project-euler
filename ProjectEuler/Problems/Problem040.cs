using System;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    public class Problem040 : Problem<long>
    {
        protected override long CalculateAnswer()
        {
            var answer = 1L;
            var digits = new List<int>();
            foreach (var index in digitIndices)
            {
                var info = DigitIndexToInformation(index);
                answer *= info.Digit;
                digits.Add(info.Digit);
                WriteLineDetail($"d_{index} = {info.Digit} (number = {info.Number}; index = {info.NumberIndex + 1})");
            }
            WriteLineDetail($"{answer} = {string.Join(" * ", digits)}");
            return answer;
        }

        private readonly int[] digitIndices =
        {
            1,
            10,
            100,
            1000,
            10000,
            100000,
            1000000,
        };

        private static DigitIndexInformation DigitIndexToInformation(long index)
        {
            int digit;
            long number;
            int numberIndex;
            if (index < 10) // 1 to 10; digits: 1
            {
                number = index;
                numberIndex = 0;
                digit = (int)index;
            }
            else if (index < 190) // 10 to 189; digits: 2
            {
                number = index / 2 + 5;
                numberIndex = (int)(index % 2L);
                digit = NumberDigit(number, numberIndex);
            }
            else if (index < 2890) // 190 to 2889; digits: 3
            {
                number = (index - 1) / 3 + 37;
                numberIndex = (int)((index - 1) % 3L);
                digit = NumberDigit(number, numberIndex);
            }
            else if (index < 38890) // 2890 to 38889; digits: 4
            {
                number = (index - 2) / 4 + 278;
                numberIndex = (int)((index - 2) % 4L);
                digit = NumberDigit(number, numberIndex);
            }
            else if (index < 488890) // 38890 to 488889; digits: 5
            {
                number = index / 5 + 2222;
                numberIndex = (int)(index % 5L);
                digit = NumberDigit(number, numberIndex);
            }
            else if (index < 5888890) // 488890 to 5888889; digits: 6
            {
                number = (index - 4) / 6 + 18519;
                numberIndex = (int)((index - 4) % 6L);
                digit = NumberDigit(number, numberIndex);
            }
            else if (index < 68888890) // 5888890 to 68888889; digits: 7
            {
                number = index / 7 + 158730;
                numberIndex = (int)(index % 7L);
                digit = NumberDigit(number, numberIndex);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return new DigitIndexInformation(digit, number, numberIndex);
        }

        private static int NumberDigit(long number, int digit)
        {
            return number.ToString()[digit] - '0';
        }

        private class DigitIndexInformation
        {
            public int Digit { get; }
            public long Number { get; }
            public int NumberIndex { get; }

            public DigitIndexInformation(int digit, long number, int numberIndex)
            {
                Digit = digit;
                Number = number;
                NumberIndex = numberIndex;
            }
        }
    }
}
