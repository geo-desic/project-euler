using System;

namespace ProjectEuler
{
    /// <summary>
    /// Represents an entry in a prime factorization.
    /// <example>For example, 2^2 is one entry in the prime factorization of 60.</example>
    /// </summary>
    public sealed class PrimeFactorizationEntry : IEquatable<PrimeFactorizationEntry>
    {
        public PrimeFactorizationEntry(long prime, int power)
        {
            Prime = prime;
            Power = power;
        }

        public long Prime { get; set; }
        public int Power { get; set; }

        /// <summary>
        /// Returns a copy of this entry object.
        /// </summary>
        public PrimeFactorizationEntry Copy()
        {
            return (PrimeFactorizationEntry)MemberwiseClone();
        }

        /// <summary>
        /// Returns true if this entry is equivalent to the other entry provided, false otherwise.
        /// </summary>
        public bool Equals(PrimeFactorizationEntry? other)
        {
            return other != null && Prime == other.Prime && Power == other.Power;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as PrimeFactorizationEntry);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                hash = (hash * 31) + Prime.GetHashCode();
                hash = (hash * 31) + Power.GetHashCode();
                return hash;
            }
        }
    }
}
