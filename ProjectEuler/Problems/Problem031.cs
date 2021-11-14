namespace ProjectEuler.Problems
{
    public class Problem031 : Problem<long>
    {
        protected override long CalculateAnswer()
        {
            WriteLineDetail("Combinations:");

            var valueCombinations = new long[VALUE_TARGET + 1];
            valueCombinations[0] = 1;
            for (var indexCoinValue = 0; indexCoinValue < COIN_VALUES.Length; ++indexCoinValue)
            {
                for (var value = COIN_VALUES[indexCoinValue]; value <= VALUE_TARGET; ++value)
                {
                    valueCombinations[value] += valueCombinations[value - COIN_VALUES[indexCoinValue]];
                }
            }
            if (DetailedOutput)
            {
                for (var value = 0; value < valueCombinations.Length; ++value)
                {
                    WriteLineDetail($"C[{value}] = {valueCombinations[value]}");
                }
            }
            return valueCombinations[VALUE_TARGET];
        }

        private readonly int[] COIN_VALUES = new int[] { 1, 2, 5, 10, 20, 50, 100, 200 };
        private const int VALUE_TARGET = 200;
    }
}
