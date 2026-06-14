using Microsoft.Extensions.Logging;

namespace ProjectEuler.Problems
{
    public abstract class Problem<T> : IProblem
    {
        protected Problem(ILogger<Problem<T>> logger)
        {
            Logger = logger;
        }

        protected ILogger<Problem<T>> Logger { get; private set; }

        protected abstract T CalculateAnswer();

        public T Answer()
        {
            var answer = CalculateAnswer();
            Logger.LogInformation("Answer = {Answer}", answer);

            return answer;
        }

        object IProblem.Answer()
        {
            return Answer()!;
        }
    }
}
