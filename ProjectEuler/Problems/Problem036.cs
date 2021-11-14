using System;

namespace ProjectEuler.Problems
{
    public class Problem036 : Problem<long>
    {
        protected override long CalculateAnswer()
        {
            var answer = 0L;
            var n = 1000000L;

            WriteLineDetail("Incremental Results:");
            for (var i = 1L; i < n; ++i)
            {
                var iAsBinary = Convert.ToString(i, 2);
                if (i.IsPalindrome() && iAsBinary.IsPalindrome())
                {
                    WriteLineDetail($"{i}; {iAsBinary}");
                    answer += i;
                }
            }

            return answer;
        }
    }
}
