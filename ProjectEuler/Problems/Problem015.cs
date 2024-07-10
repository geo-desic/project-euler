using Microsoft.Extensions.Logging;

namespace ProjectEuler.Problems
{
    public class Problem015 : Problem<long>
    {
        public Problem015(ILogger<Problem015> logger) : base(logger) { }

        protected override long CalculateAnswer()
        {
            //every path can be represented by a string of length 40 containing exactly twenty D (down) characters and twenty R (right)
            //example: "RRRRRRRRRRRRRRRRRRRRDDDDDDDDDDDDDDDDDDDD" represents the path going along the top all the way to the right then all the way down
            //the number of such unique strings is simply (40 choose 20) or 40! / (20! * 20!) = (40 * 39 * ... 22 * 21) / 20!
            //the even factors in the numerator have be simplified with 11 through 20 in the denominator

            var answer = (2L * 39L * 2L * 37L * 2L * 35L * 2L * 33L * 2L * 31L * 2L * 29L * 2L * 27L * 2L * 25L * 2L * 23L * 2L * 21L) /
                (10L * 9L * 8L * 7L * 6L * 5L * 4L * 3L * 2L);

            return answer;
        }
    }
}
