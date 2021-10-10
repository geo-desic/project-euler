using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    public class Problem023 : Problem<long>
    {
        protected override long CalculateAnswer()
        {
            var answer = 0L;
            var upperBound = 28123;

            var abundantNumbers = new List<int>();
            for (var i = 1; i <= upperBound; ++i)
            {
                if (MathHelpers.Divisors(i, true).Sum() > i) abundantNumbers.Add(i);
            }

            var done = false;
            var twoAbundantNumberSums = new Dictionary<int, bool> ();
            for (var i = 0; i < abundantNumbers.Count; ++i)
            {
                for (var j = i; j < abundantNumbers.Count; ++j)
                {
                    var sum = abundantNumbers[i] + abundantNumbers[j];
                    if (sum <= upperBound)
                    {
                        twoAbundantNumberSums[sum] = true;
                    }
                    else
                    {
                        if (2 * abundantNumbers[i] > upperBound)
                        {
                            done = true;
                            break;
                        }
                    }
                }
                if (done) break;
            }

            for (var i = 1; i < upperBound; ++i)
            {
                if (!twoAbundantNumberSums.ContainsKey(i))
                {
                    answer += i;
                    WriteLineDetail($"{i}; Sum = {answer}");
                }
            }

            return answer;
        }
    }
}
