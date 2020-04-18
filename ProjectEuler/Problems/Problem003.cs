namespace ProjectEuler.Problems
{
    public class Problem003 : Problem<long>
    {
        protected override long CalculateAnswer()
        {
            var answer = 0L;
            var n = 600851475143L;
            var primeFactorization = MathHelpers.PrimeFactorization(n);

            WriteLineDetail("Prime Factors:");
            foreach (var item in primeFactorization.Entries)
            {
                WriteLineDetail(item.Prime);
                if (item.Prime > answer) answer = item.Prime;
            }

            return answer;
        }
    }
}
