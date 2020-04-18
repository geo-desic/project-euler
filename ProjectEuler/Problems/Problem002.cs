namespace ProjectEuler.Problems
{
    public class Problem002 : Problem<int>
    {
        protected override int CalculateAnswer()
        {
            var answer = 0;
            var a1 = 1;
            var a2 = 2;

            WriteLineDetail("Terms:");
            while (a2 <= 4000000)
            {
                if (a2 % 2 == 0)
                {
                    WriteLineDetail(a2);
                    answer += a2;
                }
                var next = a1 + a2;
                a1 = a2;
                a2 = next;
            }

            return answer;
        }
    }
}
