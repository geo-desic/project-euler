namespace ProjectEuler
{
    /// <summary>
    /// Represents an entry in a prime factorization.
    /// <example>For example, 2^2 is one entry in the prime factorization of 60.</example>
    /// </summary>
    public class PrimeFactorizationEntry
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
        public bool Equals(PrimeFactorizationEntry other)
        {
            if (other != null)
            {
                if (Prime == other.Prime && Power == other.Power) return true;
            }
            return false;
        }
    }
}
