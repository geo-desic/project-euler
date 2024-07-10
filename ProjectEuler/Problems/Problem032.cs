using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    public class Problem032 : Problem<int>
    {
        public Problem032(ILogger<Problem032> logger) : base(logger) { }

        protected override int CalculateAnswer()
        {
            var answer = 0;
            // m := multiplicand, n := multiplier, p := product
            // p = m * n where m < n

            // 3 possible cases:
            // (1) m is 1 digit, n is 4 digits, and p is 4 digits
            // (2) m is 2 digits, n is 4 digits, and p is 3 digits
            // (3) m is 2 digits, n is 3 digits, and p is 4 digits

            var uniqueProducts = new List<int>();

            Logger.LogDebug("Incremental Results:");

            for (var m = 2; m <= 99; ++m)
            {
                var nMin = 1000 / m; // 1000 is the smallest 4 digit number
                var nMax = 9999 / m; // 9999 is the largest 4 digit number
                if (nMin <= m) nMin = m + 1; // n must be larger than m
                if (nMax <= m) nMax = m + 1; // n must be larger than m
                if (m.ToString().IndexOf('0') == -1) // skip if m contains the digit 0
                {
                    for (var n = nMin; n <= nMax; ++n)
                    {
                        var p = n * m;
                        var identityString = $"{n}{m}{p}";
                        if (identityString.IsPandigital(1, 9))
                        {
                            if (!uniqueProducts.Contains(p))
                            {
                                uniqueProducts.Add(p);
                                answer += p;
                                Logger.LogDebug("{p} = {m} * {n}", p, m, n);
                            }
                        }
                    }
                }
            }

            return answer;
        }
    }
}
