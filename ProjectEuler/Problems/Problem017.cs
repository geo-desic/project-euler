using Microsoft.Extensions.Logging;

namespace ProjectEuler.Problems
{
    public class Problem017 : Problem<int>
    {
        public Problem017(ILogger<Problem017> logger) : base(logger) { }

        protected override int CalculateAnswer()
        {
            var answer = 0;

            for (var i = 1; i <= 1000; ++i)
            {
                answer += i.ToWords().Replace(" ", "").Length;
            }

            return answer;
        }
    }
}
