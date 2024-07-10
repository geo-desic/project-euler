using Microsoft.Extensions.Logging;

namespace ProjectEuler.Problems
{
    public class Problem004 : Problem<int>
    {
        public Problem004(ILogger<Problem004> logger) : base(logger) { }

        protected override int CalculateAnswer()
        {
            var answer = 0;

            Logger.LogDebug("Incremental Results:");
            for (var i = 999; i >= 100; --i)
            {
                for (var j = 999; j >= i; --j)
                {
                    var product = i * j;
                    if (product <= answer) break;
                    if (product.IsPalindrome())
                    {
                        Logger.LogDebug("{product} = {i} * {j}", product, i, j);
                        answer = product;
                        break;
                    }
                }
            }

            return answer;
        }
    }
}
