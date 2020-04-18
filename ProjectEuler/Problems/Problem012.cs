namespace ProjectEuler.Problems
{
    public class Problem012 : Problem<long>
    {
        protected override long CalculateAnswer()
        {
            var answer = 0L;

            WriteLineDetail("Incremental Results:");
            var i = 1;
            var maxDivisors = 1;
            while (maxDivisors <= 500)
            {
                var triangularNumber = MathHelpers.NthTriangularNumber(i++);
                var divisors = MathHelpers.DivisorCount(triangularNumber);
                if (divisors > maxDivisors)
                {
                    WriteLineDetail("Triangular #" + i + " = " + triangularNumber + "; Divisor Count = " + divisors);
                    maxDivisors = divisors;
                    answer = triangularNumber;
                }
            }

            return answer;
        }
    }
}
