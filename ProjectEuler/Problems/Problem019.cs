using System;

namespace ProjectEuler.Problems
{
    public class Problem019 : Problem<int>
    {
        protected override int CalculateAnswer()
        {
            var answer = 0;

            WriteLineDetail("Incremental Results:");
            for (var year = 1901; year <= 2000; ++year)
            {
                var yearTotal = 0;
                for (var month = 1; month <= 12; ++month)
                {
                    var date = new DateTime(year, month, 1);
                    if (date.DayOfWeek == DayOfWeek.Sunday) ++yearTotal;
                }
                WriteLineDetail($"{year}: {yearTotal}");
                answer += yearTotal;
            }

            return answer;
        }
    }
}
