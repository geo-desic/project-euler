using Microsoft.Extensions.Logging;

namespace ProjectEuler.Problems
{
    public class Problem014 : Problem<long>
    {
        public Problem014(ILogger<Problem014> logger) : base(logger) { }

        protected override long CalculateAnswer()
        {
            var answer = 0L;
            var maxChainLength = 0;
            var n = 1000000;

            Logger.LogDebug("Incremental Results:");
            for (var i = 1L; i < n; ++i)
            {
                var length = MathHelpers.CollatzLength(i);
                if (length > maxChainLength)
                {
                    answer = i;
                    maxChainLength = length;
                    Logger.LogDebug("Chain Length = {length}; Starting Value = {startingValue}", length, i);
                }
            }

            return answer;
        }
    }
}
