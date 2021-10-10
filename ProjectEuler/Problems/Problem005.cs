namespace ProjectEuler.Problems
{
    public class Problem005 : Problem<long>
    {
        protected override long CalculateAnswer()
        {
            var lcmFactorization = new PrimeFactorization();

            WriteLineDetail("Incremental Results:");
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
                WriteLineDetail($"{i}: {lcmFactorization.ComputeProduct()}");
            }

            return lcmFactorization.ComputeProduct();
        }
    }
}
