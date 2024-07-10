using Microsoft.Extensions.Logging;
using System;

namespace ProjectEuler.Problems
{
    public class Problem009 : Problem<long>
    {
        public Problem009(ILogger<Problem009> logger) : base(logger) { }

        protected override long CalculateAnswer()
        {
            var answer = 0L;
            var n = 1000;

            for (var a = 1; a <= n - 1; ++a)
            {
                //due to symmetry between a and b we can assume a <= b
                for (var b = a; b <= n - 1 - a; ++b)
                {
                    var c = n - a - b;
                    if (c * c == a * a + b * b)
                    {
                        Logger.LogDebug("Pythagorean Triplet:");
                        Logger.LogDebug("a = {a}; b = {b}; c = {c}", a, b, c);
                        answer = a * b * c;
                        break;
                    }
                }
            }
            if (answer == 0L) throw new Exception("Answer was not found");

            return answer;
        }
    }
}
