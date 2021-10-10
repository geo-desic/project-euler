namespace ProjectEuler.Problems
{
    public class Problem025 : Problem<long>
    {
        protected override long CalculateAnswer()
        {
            var a = "1";
            var b = "1";
            var totalDigits = 1000;
            var detailSize = totalDigits / 10;
            var detailThreshold = detailSize;

            string c;
            var answer = 3L;
            while (true)
            {
                c = MathHelpers.AddIntegerStrings(a, b);
                if (c.Length == totalDigits) break;
                else if (c.Length >= detailThreshold)
                {
                    WriteLineDetail($"Index = {answer}; Length = {c.Length}");
                    detailThreshold += detailSize;
                }
                a = b;
                b = c;
                ++answer;
            }

            return answer;
        }
    }
}
