namespace ProjectEuler.Problems
{
    public class Problem004 : Problem<int>
    {
        protected override int CalculateAnswer()
        {
            var answer = 0;

            WriteLineDetail("Incremental Results:");
            for (var i = 999; i >= 100; --i)
            {
                for (var j = 999; j >= i; --j)
                {
                    var product = i * j;
                    if (product <= answer) break;
                    if (product.IsPalindrome())
                    {
                        WriteLineDetail($"{product} = {i} * {j}");
                        answer = product;
                        break;
                    }
                }
            }

            return answer;
        }
    }
}
