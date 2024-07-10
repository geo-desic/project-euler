using Microsoft.Extensions.Logging;

namespace ProjectEuler.Problems
{
    public class Problem020 : Problem<int>
    {
        public Problem020(ILogger<Problem020> logger) : base(logger) { }

        protected override int CalculateAnswer()
        {
            var product = "1";
            for (var i = 2; i <= 100; ++i)
            {
                product = MathHelpers.MultiplyIntegerStrings(product, i.ToString());
            }

            Logger.LogDebug("{product}", product);

            var answer = 0;
            for (var i = 0; i < product.Length; ++i)
            {
                answer += product[i] - '0';
            }

            return answer;
        }
    }
}
