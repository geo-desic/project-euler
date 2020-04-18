namespace ProjectEuler.Problems
{
    public class Problem017 : Problem<int>
    {
        protected override int CalculateAnswer()
        {
            var answer = 0;

            for (var i = 1; i <= 1000; ++i)
            {
                answer += i.ToWords().Replace(" ", "").Length;
            }

            return answer;
        }
    }
}
