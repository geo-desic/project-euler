namespace ProjectEuler.Problems
{
    public class Problem028 : Problem<long>
    {
        protected override long CalculateAnswer()
        {
            var n = 1001;
            var grid = new long[n, n];

            //populate grid with values
            var middle_index = (n - 1) / 2;
            var distance = 0;
            var distance_max = middle_index;
            var x = middle_index;
            var y = middle_index;
            var x_inc = 1;
            var y_inc = 0;
            var current_number = 1L;
            while (distance <= distance_max)
            {
                grid[x, y] = current_number;
                var distance_next = Distance(middle_index, x + x_inc, y + y_inc);
                if (distance_next > distance)
                {
                    //allow enlarging the distance by 1 only in the "right" direction
                    if (x_inc == 1 && distance_next == distance + 1)
                    {
                        ++distance;
                        x += x_inc;
                        y += y_inc;
                        ChangeDirection(ref x_inc, ref y_inc);
                    }
                    else
                    {
                        ChangeDirection(ref x_inc, ref y_inc);
                        x += x_inc;
                        y += y_inc;
                    }
                }
                else
                {
                    x += x_inc;
                    y += y_inc;
                }
                ++current_number;
            }

            var answer = 0L;
            //calculate diagonal sums
            for (var i = 0; i <= middle_index; ++i)
            {
                answer += grid[i, i];
                if (i != middle_index)
                {
                    answer += grid[i, n - i - 1];
                    answer += grid[n - i - 1, i];
                    answer += grid[n - i - 1, n - i - 1];
                }
            }

            return answer;
        }

        private int Distance(int middle_index, int x, int y)
        {
            var d1 = middle_index - x;
            if (d1 < 0) d1 = -d1;
            var d2 = middle_index - y;
            if (d2 < 0) d2 = -d2;
            if (d1 > d2) return d1;
            return d2;
        }

        private void ChangeDirection(ref int x_inc, ref int y_inc)
        {
            if (x_inc == 1 && y_inc == 0) //right
            {
                //down
                x_inc = 0;
                y_inc = 1;
            }
            else if (x_inc == 0 && y_inc == 1) //down
            {
                //left
                x_inc = -1;
                y_inc = 0;
            }
            else if (x_inc == -1 && y_inc == 0) //left
            {
                //up
                x_inc = 0;
                y_inc = -1;
            }
            else //up
            {
                //right
                x_inc = 1;
                y_inc = 0;
            }
        }
    }
}
