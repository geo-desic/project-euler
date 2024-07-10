using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    public class Problem035 : Problem<int>
    {
        public Problem035(ILogger<Problem035> logger) : base(logger) { }

        protected override int CalculateAnswer()
        {
            var answer = 0;
            var n = 1000000;

            var composite = MathHelpers.IndexCompositeBySieve(n);

            var primes = new List<int>();
            for (var i = 2; i < n; ++i)
            {
                if (!composite[i]) primes.Add(i);
            }

            Logger.LogDebug("Incremental Results:");
            foreach (var prime in primes)
            {
                var primeString = prime.ToString();
                if (prime < 10)
                {
                    ++answer;
                    Logger.LogDebug("{prime}", prime);
                }
                // if the prime is two digits or longer, it cannot include 0, 2, 4, 5, 6, or 8 because at least one rotation would be divisible by 2 or 5
                else if ((primeString.IndexOf('0') == -1 && primeString.IndexOf('2') == -1 && primeString.IndexOf('4') == -1 && primeString.IndexOf('5') == -1 && primeString.IndexOf('6') == -1 && primeString.IndexOf('8') == -1))
                {
                    var allRotationsPrime = true;
                    var rotation = prime;
                    do
                    {
                        rotation = RotateDigitsRight(rotation, primeString.Length);
                        if (composite[rotation])
                        {
                            allRotationsPrime = false;
                            break;
                        }
                    } while (rotation != prime);
                    if (allRotationsPrime)
                    {
                        ++answer;
                        Logger.LogDebug("{prime}", prime);
                    }
                }
            }

            return answer;
        }

        private static int RotateDigitsRight(int value, int length)
        {
            if (length == 1) return value;
            var onesDigit = value % 10;
            value /= 10;
            return 10.Power(length - 1) * onesDigit + value;
        }
    }
}
