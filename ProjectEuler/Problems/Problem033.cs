using Microsoft.Extensions.Logging;

namespace ProjectEuler.Problems
{
    public class Problem033 : Problem<int>
    {
        public Problem033(ILogger<Problem033> logger) : base(logger) { }

        protected override int CalculateAnswer()
        {
            // n  : numerator
            // n10: numerator's tens digit
            // n1 : numerator's ones digit
            // d  : denomiator
            // d10: denomiator's tens digit
            // d1 : denomiator's ones digit

            var numeratorProduct = 1;
            var denominatorProduct = 1;

            Logger.LogDebug("Incremental Results:");
            for (var n10 = 1; n10 <= 9; ++n10)
            {
                for (var n1 = 1; n1 <= 9; ++n1)
                {
                    if (n1 != n10)
                    {
                        var n = n10 * 10 + n1;

                        // a: non-cancelled digit in denominator
                        for (var a = 1; a <= 9; ++a)
                        {
                            int d;
                            int d10;
                            int d1;

                            // case d1 == a   ==>  d10 == n1
                            d1 = a;
                            d10 = n1;
                            d = d10 * 10 + d1;
                            if (FractionsEquivalent(n, d, n10, d1) && n < d)
                            {
                                Logger.LogDebug("{n} / {d} = {n10} / {d1}", n, d, n10, d1);
                                numeratorProduct *= n10;
                                denominatorProduct *= d1;
                            }

                            // case d10 == a  ==>  d1  == n10
                            d1 = n10;
                            d10 = a;
                            d = d10 * 10 + d1;
                            if (FractionsEquivalent(n, d, n1, d10) && n < d)
                            {
                                Logger.LogDebug("{n} / {d} = {n1} / {d10}", n, d, n1, d10);
                                numeratorProduct *= n1;
                                denominatorProduct *= d10;
                            }
                        }
                    }
                }
            }

            var gcd = (int)MathHelpers.Gcd(numeratorProduct, denominatorProduct);
            numeratorProduct /= gcd;
            denominatorProduct /= gcd;
            Logger.LogDebug("Product In Lowest Terms:");
            Logger.LogDebug("{numeratorProduct} / {denominatorProduct}", numeratorProduct, denominatorProduct);

            return denominatorProduct;
        }

        private static bool FractionsEquivalent(int numerator1, int denominator1, int numerator2, int denominator2)
        {
            return numerator1 * denominator2 == numerator2 * denominator1;
        }
    }
}
