using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    public class Problem026 : Problem<int>
    {
        protected override int CalculateAnswer()
        {
            var answer = 0;
            var n = 1000;
            var longestCycleLength = 0;

            for (var d = 2; d < n; ++d)
            {
                var cycleLength = CycleLength(d);
                if (cycleLength > longestCycleLength)
                {
                    answer = d;
                    longestCycleLength = cycleLength;
                    WriteLineDetail("d = " + d + "; cycle length = " + cycleLength);
                }
            }

            return answer;
        }

        private int MinPower10MultipleOfRGreaterThanD(int d, int r)
        {
            var a = r;
            while (d > a)
            {
                a *= 10;
            }
            return a;
        }

        private int CycleLength(int d)
        {
            var result = 0;
            var r = 1;
            var seen = new Dictionary<int, int>();
            while (!seen.ContainsKey(r))
            {
                seen[r] = result;
                var dividend = MinPower10MultipleOfRGreaterThanD(d, r);
                r = dividend % d;
                if (r == 0) return 0;
                ++result;
            }
            return result - seen[r];
        }
    }
}
