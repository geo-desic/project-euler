namespace ProjectEuler.Problems
{
    public class Problem006 : Problem<long>
    {
        protected override long CalculateAnswer()
        {
            var n = 100;
            var sumOfSquares1ToN = SumOfSquares1ToN(n);
            var sum1ToNSquared = Sum1ToNSquared(n);

            WriteLineDetail($"Sum Of Squares 1 To {n}:");
            WriteLineDetail(sumOfSquares1ToN);
            WriteLineDetail($"Sum 1 To {n} Squared:");
            WriteLineDetail(sum1ToNSquared);

            return sum1ToNSquared - sumOfSquares1ToN;
        }

        private static long SumOfSquares1ToN(long n)
        {
            return n * (n + 1L) * (2 * n + 1L) / 6L;
        }

        private static long Sum1ToNSquared(long n)
        {
            var sum = n * (n + 1L) / 2L;
            return sum * sum;
        }
    }
}
