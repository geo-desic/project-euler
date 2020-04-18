using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    public class Problem029 : Problem<long>
    {
        protected override long CalculateAnswer()
        {
            // unique a^b terms where 2 <= a <= 100 and 2 <= b <= 100

            var minA = 2L;
            var minB = 2;
            var maxA = 100L;
            var maxB = 100;

            // generate a list of all (possibly repetitive) terms in prime factorization format
            var terms = new List<PrimeFactorization>();
            for (var a = minA; a <= maxA; ++a)
            {
                var factorizationOfA = MathHelpers.PrimeFactorization(a);
                for (var b = minB; b <= maxB; ++b)
                {
                    var factorization = factorizationOfA.Copy();
                    foreach (var entry in factorization.Entries)
                    {
                        entry.Power *= b;
                    }
                    terms.Add(factorization);
                }
            }

            // compare each pair of terms and remove any duplicates
            for (var i = 0; i < terms.Count; ++i)
            {
                var term1 = terms[i];
                var j = i + 1;
                while (j < terms.Count)
                {
                    var term2 = terms[j];
                    if (term1.Equals(term2)) terms.RemoveAt(j);
                    else ++j;
                }
            }

            return terms.Count;
        }
    }
}
