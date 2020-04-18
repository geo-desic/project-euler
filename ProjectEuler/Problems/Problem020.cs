namespace ProjectEuler.Problems
{
    public class Problem020 : Problem<int>
    {
        protected override int CalculateAnswer()
        {
            var product = "1";
            for (var i = 2; i <= 100; ++i)
            {
                product = MathHelpers.MultiplyIntegerStrings(product, i.ToString());
            }

            WriteLineDetail(product);

            var answer = 0;
            for (var i = 0; i < product.Length; ++i)
            {
                answer += product[i] - '0';
            }

            return answer;
        }
    }
}
