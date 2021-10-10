namespace ProjectEuler.Problems
{
    public class Problem014 : Problem<long>
    {
        protected override long CalculateAnswer()
        {
            var answer = 0L;
            var maxChainLength = 0;
            var n = 1000000;

            WriteLineDetail("Incremental Results:");
            for (var i = 1L; i < n; ++i)
            {
                var length = MathHelpers.CollatzLength(i);
                if (length > maxChainLength)
                {
                    answer = i;
                    maxChainLength = length;
                    WriteLineDetail($"Chain Length = {length}; Starting Value = {i}");
                }
            }

            return answer;
        }
    }
}
