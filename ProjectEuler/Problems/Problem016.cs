﻿using Microsoft.Extensions.Logging;

namespace ProjectEuler.Problems
{
    public class Problem016 : Problem<int>
    {
        public Problem016(ILogger<Problem016> logger) : base(logger) { }

        protected override int CalculateAnswer()
        {
            var product = twoTo100;

            for (var i = 2; i <= 10; ++i)
            {
                product = MathHelpers.MultiplyIntegerStrings(product, twoTo100);
            }

            Logger.LogDebug("{product}", product);

            var answer = 0;
            for (var i = 0; i < product.Length; ++i)
            {
                answer += product[i] - '0';
            }

            return answer;
        }

        //2^100
        private readonly string twoTo100 = "1267650600228229401496703205376";
    }
}
