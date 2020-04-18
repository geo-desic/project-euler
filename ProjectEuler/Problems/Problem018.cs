using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    public class Problem018 : Problem<long>
    {
        public Problem018()
        {
            triangle = CreateTriangle();
            cache = new Dictionary<string, int>();
        }

        protected override long CalculateAnswer()
        {
            return MaxChildSum(0, 0);
        }

        //recursive function with cache
        private int MaxChildSum(int row, int column)
        {
            var key = row.ToString() + "," + column.ToString();
            if (cache.TryGetValue(key, out int value))
            {
                return value;
            }
            var result = triangle[row][column];

            //leaf: no need to store in cache
            if (row == triangle.Length - 1) return result;

            //element straight down always exists, so no need to validate
            var child1 = MaxChildSum(row + 1, column);

            //element down and right always exists, so no need to validate
            var child2 = MaxChildSum(row + 1, column + 1);

            if (child2 > child1) result += child2;
            else result += child1;

            cache[key] = result;

            return result;
        }

        private readonly int[][] triangle;

        private readonly Dictionary<string, int> cache;

        private int[][] CreateTriangle()
        {
            int[][] result = new int[15][];
            result[0] = new int[] { 75 };
            result[1] = new int[] { 95, 64 };
            result[2] = new int[] { 17, 47, 82 };
            result[3] = new int[] { 18, 35, 87, 10 };
            result[4] = new int[] { 20, 04, 82, 47, 65 };
            result[5] = new int[] { 19, 01, 23, 75, 03, 34 };
            result[6] = new int[] { 88, 02, 77, 73, 07, 63, 67 };
            result[7] = new int[] { 99, 65, 04, 28, 06, 16, 70, 92 };
            result[8] = new int[] { 41, 41, 26, 56, 83, 40, 80, 70, 33 };
            result[9] = new int[] { 41, 48, 72, 33, 47, 32, 37, 16, 94, 29 };
            result[10] = new int[] { 53, 71, 44, 65, 25, 43, 91, 52, 97, 51, 14 };
            result[11] = new int[] { 70, 11, 33, 28, 77, 73, 17, 78, 39, 68, 17, 57 };
            result[12] = new int[] { 91, 71, 52, 38, 17, 14, 91, 43, 58, 50, 27, 29, 48 };
            result[13] = new int[] { 63, 66, 04, 68, 89, 53, 67, 30, 73, 16, 69, 87, 40, 31 };
            result[14] = new int[] { 04, 62, 98, 27, 23, 09, 70, 98, 73, 93, 38, 53, 60, 04, 23 };
            return result;
        }
    }
}
