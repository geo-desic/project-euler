using Microsoft.Extensions.Logging;

namespace ProjectEuler.Problems
{
    public class Problem024 : Problem<string>
    {
        public Problem024(ILogger<Problem024> logger) : base(logger) { }

        protected override string CalculateAnswer()
        {
            var characters = "0123456789";
            var elements = characters.ToCharArray();
            var n = 1000000;

            var index = 1;
            var returnedToFirstPermutation = false;
            while (true)
            {
                if (index % 10000 == 0) Logger.LogDebug("{index}: {elements}", index, new string(elements));
                if (index == n || returnedToFirstPermutation)
                {
                    break;
                }
                var result = MathHelpers.LexicographicPermute(elements);
                ++index;
                if (result) returnedToFirstPermutation = true;
            }

            var answer = new string(elements);
            return answer;
        }
    }
}
