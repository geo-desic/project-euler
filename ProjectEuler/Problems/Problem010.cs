namespace ProjectEuler.Problems
{
    public class Problem010 : Problem<long>
    {
        protected override long CalculateAnswer()
        {
            var answer = 0L;
            var n = 2000000L;
            var compositeSieve = MathHelpers.IndexCompositeBySieve(n);

            for (var i = 2L; i < n; ++i)
            {
                if (!compositeSieve[i]) answer += i;
            }

            return answer;
        }
    }
}
