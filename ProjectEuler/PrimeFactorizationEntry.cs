namespace ProjectEuler
{
    public class PrimeFactorizationEntry
    {
        public PrimeFactorizationEntry(long prime, int power)
        {
            Prime = prime;
            Power = power;
        }

        public long Prime { get; set; }
        public int Power { get; set; }

        public PrimeFactorizationEntry Copy()
        {
            return (PrimeFactorizationEntry)MemberwiseClone();
        }

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
