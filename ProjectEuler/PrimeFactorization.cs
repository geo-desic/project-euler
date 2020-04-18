using System.Collections.Generic;
using System.Text;

namespace ProjectEuler
{
    public class PrimeFactorization
    {
        public PrimeFactorization()
        {
            entriesDictionary = new Dictionary<long, PrimeFactorizationEntry>();
            entriesList = new List<PrimeFactorizationEntry>();
        }

        private Dictionary<long, PrimeFactorizationEntry> entriesDictionary;

        private List<PrimeFactorizationEntry> entriesList;

        public IReadOnlyList<PrimeFactorizationEntry> Entries
        {
            get
            {
                return entriesList;
            }
        }

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

        public PrimeFactorizationEntry Entry(long prime)
        {
            if (entriesDictionary.TryGetValue(prime, out PrimeFactorizationEntry entry))
            {
                return entry;
            }
            return null;
        }

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

        public PrimeFactorization Copy()
        {
            var result = new PrimeFactorization();
            foreach (var entry in entriesList)
            {
                result.AddEntry(entry.Prime, entry.Power);
            }
            return result;
        }

        public bool Equals(PrimeFactorization other)
        {
            if (other != null)
            {
                foreach (var entry1 in entriesList)
                {
                    if (!entry1.Equals(other.Entry(entry1.Prime))) return false;
                }
                foreach (var entry2 in other.Entries)
                {
                    if (!entry2.Equals(Entry(entry2.Prime))) return false;
                }
                return true;
            }
            return false;
        }

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
