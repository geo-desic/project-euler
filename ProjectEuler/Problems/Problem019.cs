using Microsoft.Extensions.Logging;
using System;

namespace ProjectEuler.Problems
{
    public class Problem019 : Problem<int>
    {
        public Problem019(ILogger<Problem019> logger) : base(logger) { }

        protected override int CalculateAnswer()
        {
            var answer = 0;

            Logger.LogDebug("Incremental Results:");
            for (var year = 1901; year <= 2000; ++year)
            {
                var yearTotal = 0;
                for (var month = 1; month <= 12; ++month)
                {
                    var date = new DateTime(year, month, 1);
                    if (date.DayOfWeek == DayOfWeek.Sunday) ++yearTotal;
                }
                Logger.LogDebug("{year}: {yearTotal}", year, yearTotal);
                answer += yearTotal;
            }

            return answer;
        }
    }
}
