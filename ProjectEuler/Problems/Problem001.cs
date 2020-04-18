namespace ProjectEuler.Problems
{
    public class Problem001 : Problem<int>
    {
        protected override int CalculateAnswer()
        {
            WriteLineDetail("Multiples:");
            var answer = 0;
            for (var i = 1; i < 1000; ++i)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    WriteLineDetail(i);
                    answer += i;
                }
            }
            return answer;
        }
    }
}
