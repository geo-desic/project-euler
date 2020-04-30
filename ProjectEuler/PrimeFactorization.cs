using System.Collections.Generic;
using System.Text;

namespace ProjectEuler
{
    /// <summary>
    /// Represents the prime factorization for an integer.
    /// <example>For example, 2^2 * 3 * 5 is the prime factorization for the integer 60.</example>
    /// </summary>
    public class PrimeFactorization
    {
        public PrimeFactorization()
        {
            entriesDictionary = new Dictionary<long, PrimeFactorizationEntry>();
            entriesList = new List<PrimeFactorizationEntry>();
        }

        private readonly Dictionary<long, PrimeFactorizationEntry> entriesDictionary;

        private readonly List<PrimeFactorizationEntry> entriesList;

        /// <summary>
        /// The prime entries in the prime factorization.
        /// <example>For example, the prime factorization for 60 would have three entries: 2^2, 3, and 5.</example>
        /// </summary>
        public IReadOnlyList<PrimeFactorizationEntry> Entries
        {
            get
            {
                return entriesList;
            }
        }

        /// <summary>
        /// Adds an entry to this factorization object.
        /// </summary>
        public void AddEntry(long prime, int power)
        {
            if (entriesDictionary.TryGetValue(prime, out PrimeFactorizationEntry entry))
            {
                entry.Power = power;
            }
            else
            {
                entry = new PrimeFactorizationEntry(prime, power);
                entriesDictionary[prime] = entry;
                entriesList.Add(entry);
            }
        }

        /// <summary>
        /// Returns the entry of this factorization object containing the prime provided.
        /// <example>For example, if this object is the prime factorization of 60 = 2^2 * 3 * 5, given input 2 it would return the 2^2 entry.</example>
        /// </summary>
        public PrimeFactorizationEntry Entry(long prime)
        {
            if (entriesDictionary.TryGetValue(prime, out PrimeFactorizationEntry entry))
            {
                return entry;
            }
            return null;
        }

        /// <summary>
        /// Calculates the product of the prime factorization.
        /// <example>For example, the factorization 2^2 * 3 * 5 returns 60.</example>
        /// </summary>
        public long ComputeProduct()
        {
            var result = 1L;
            foreach (var item in entriesList)
            {
                for (var i = 1; i <= item.Power; ++i)
                {
                    result *= item.Prime;
                }
            }
            return result;
        }

        /// <summary>
        /// Returns a copy of this prime factorization object.
        /// </summary>
        public PrimeFactorization Copy()
        {
            var result = new PrimeFactorization();
            foreach (var entry in entriesList)
            {
                result.AddEntry(entry.Prime, entry.Power);
            }
            return result;
        }

        /// <summary>
        /// Returns true if this factorization is equivalent to the other factorization provided, false otherwise.
        /// </summary>
        public bool Equals(PrimeFactorization other)
        {
            if (other != null)
            {
                foreach (var entry1 in entriesList)
                {
                    if (!entry1.Equals(other.Entry(entry1.Prime))) return false;
                }
                foreach (var entry2 in other.entriesList)
                {
                    if (!entry2.Equals(Entry(entry2.Prime))) return false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns a string representation of the factorization.
        /// <example>For example, the prime factorization of 60 returns '2^2 * 3 * 5'.</example>
        /// </summary>
        public override string ToString()
        {
            var builder = new StringBuilder();
            var first = true;
            foreach (var entry in entriesList)
            {
                if (first) first = false;
                else
                {
                    builder.Append(" * ");
                }
                if (entry.Power != 0)
                {
                    builder.Append(entry.Prime);
                    if (entry.Power != 1)
                    {
                        builder.Append("^" + entry.Power);
                    }
                }
            }
            return builder.ToString();
        }
    }
}
