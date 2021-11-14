namespace ProjectEuler.Problems
{
    public class Problem038 : Problem<long>
    {
        protected override long CalculateAnswer()
        {
            // (1, 2, ..., n) and let i be the integer
            // i must start with 9 to be larger than the example given, 918273645
            // i must be less than 5 digits since n > 2 and can't be 2 or 3 digits since the result would not be exactly 9 digits
            // so we only need to check i between 9000 and 9999 (for n = 2)
            // i concatenated by 2i is 100000i + 2i = 100002i

            var answer = 918273645;
            for (var i = 9999; i >= 9000; --i)
            {
                var m = 100002 * i;
                if (m.ToString().IsPandigital(1, 9))
                {
                    answer = m;
                    break;
                }
            }

            return answer;
        }
    }
}
