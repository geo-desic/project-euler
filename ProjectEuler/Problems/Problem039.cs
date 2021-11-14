using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    public class Problem039 : Problem<int>
    {
        protected override int CalculateAnswer()
        {
            // p = perimeter
            // a < b < c = hypotenuse
            var answer = 0;
            const int MAX_PERIMITER = 1000;
            var solutionCounts = new int[MAX_PERIMITER + 1];
            var triangles = GeneratePythagoreanTriples(MAX_PERIMITER / 2 + 1);
            var maxSolutions = 0;
            foreach (var triangle in triangles)
            {
                if (triangle.P <= MAX_PERIMITER)
                {
                    var solutions = ++solutionCounts[triangle.P];
                    if (solutions > maxSolutions)
                    {
                        maxSolutions = solutions;
                        answer = triangle.P;
                        WriteLineDetail($"p = {answer}; solutions = {solutions}");
                    }
                }
            }
            return answer;
        }

        private static List<PythagoreanTriple> GeneratePythagoreanTriples(int upperBound)
        {
            // https://en.wikipedia.org/wiki/Pythagorean_triple
            var result = new List<PythagoreanTriple>();
            for (var a = 1; a < upperBound; ++a)
            {
                var aa = a * a;
                var b = a + 1;
                var c = b + 1;
                while (c <= upperBound)
                {
                    int cc = aa + b * b;
                    while (c * c < cc) { ++c; }
                    if (c * c == cc && c <= upperBound) result.Add(new PythagoreanTriple(a, b, c));
                    ++b;
                }
            }
            return result;
        }

        private class PythagoreanTriple
        {
            public int A { get; }
            public int B { get; }
            public int C { get; }
            public int P { get; }
            public PythagoreanTriple(int a, int b, int c)
            {
                A = a;
                B = b;
                C = c;
                P = a + b + c;
            }
        }
    }
}
