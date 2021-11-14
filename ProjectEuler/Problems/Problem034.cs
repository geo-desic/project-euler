namespace ProjectEuler.Problems
{
    public class Problem034 : Problem<int>
    {
        protected override int CalculateAnswer()
        {
            var answer = 0;

            WriteLineDetail("Incremental Results:");
            for (var n = 10; n < 99999; ++n)
            {
                var value = n;
                int digit;
                var digitFactorialSum = 0;
                while (value > 0)
                {
                    digit = value % 10;
                    digitFactorialSum += DigitFactorial(digit);
                    value /= 10;
                }
                if (n == digitFactorialSum)
                {
                    WriteLineDetail(n);
                    answer += n;
                }
            }

            return answer;
        }

        private static int DigitFactorial(int digit)
        {
            if (digit == 0) return 1;
            if (digit == 1) return 1;
            if (digit == 2) return 2;
            if (digit == 3) return 6;
            if (digit == 4) return 24;
            if (digit == 5) return 120;
            if (digit == 6) return 720;
            if (digit == 7) return 5040;
            if (digit == 8) return 40320;
            if (digit == 9) return 362880;
            throw new System.Exception("invalid digit");
        }
    }
}
