using Microsoft.Extensions.Logging;

namespace ProjectEuler.Problems
{
    public class Problem001 : Problem<int>
    {
        public Problem001(ILogger<Problem001> logger) : base(logger) { }

        protected override int CalculateAnswer()
        {
            Logger.LogDebug("Multiples:");
            var answer = 0;
            for (var i = 1; i < 1000; ++i)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    Logger.LogDebug("{multiple}", i);
                    answer += i;
                }
            }
            return answer;
        }
    }
}
