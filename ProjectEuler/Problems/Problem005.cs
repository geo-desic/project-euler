using Microsoft.Extensions.Logging;

namespace ProjectEuler.Problems
{
    public class Problem005 : Problem<long>
    {
        public Problem005(ILogger<Problem005> logger) : base(logger) { }

        protected override long CalculateAnswer()
        {
            var lcmFactorization = new PrimeFactorization();

            Logger.LogDebug("Incremental Results:");
            for (var i = 2; i <= 20; ++i)
            {
                var factorization = i.PrimeFactorization();
                foreach (var item in factorization.Entries)
                {
                    var lcmEntry = lcmFactorization.Entry(item.Prime);
                    if (lcmEntry == null) lcmFactorization.AddEntry(item.Prime, item.Power);
                    else
                    {
                        if (item.Power > lcmEntry.Power) lcmEntry.Power = item.Power;
                    }
                }
                Logger.LogDebug("{i}: {product}", i, lcmFactorization.ComputeProduct());
            }

            return lcmFactorization.ComputeProduct();
        }
    }
}
