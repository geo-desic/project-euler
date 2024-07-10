using Microsoft.Extensions.Logging;
using System;

namespace ProjectEuler.Problems
{
    public class Problem036 : Problem<long>
    {
        public Problem036(ILogger<Problem036> logger) : base(logger) { }

        protected override long CalculateAnswer()
        {
            var answer = 0L;
            var n = 1000000L;

            Logger.LogDebug("Incremental Results:");
            for (var i = 1L; i < n; ++i)
            {
                var iAsBinary = Convert.ToString(i, 2);
                if (i.IsPalindrome() && iAsBinary.IsPalindrome())
                {
                    Logger.LogDebug("{i}; {iAsBinary}", i, iAsBinary);
                    answer += i;
                }
            }

            return answer;
        }
    }
}
