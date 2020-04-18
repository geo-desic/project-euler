from problems.problem import Problem

def distance(middle_index: int, x: int, y: int) -> int:
  dx = middle_index - x
  if dx < 0:
    dx = -dx
  dy = middle_index - y
  if dy < 0:
    dy = -dy
  if dx > dy:
    return dx
  return dy

def next_direction(dx: int, dy: int) -> (int, int):
  if dx == 1 and dy == 0: # right
    return (0, 1) # down
  if dx == 0 and dy == 1: # down
    return (-1, 0) # left
  if dx == -1 and dy == 0: # left
    return (0, -1) # up
  return (1, 0) # right

class Problem028(Problem):

  def calculate_answer(self) -> int:
    n = 1001
    grid = [] # 2 dimensional

    # fill with zeros
    for i in range(0, n):
      inner_grid = []
      for j in range(0, n):
        inner_grid.append(0)
      grid.append(inner_grid)

    middle_index = (n - 1) // 2
    d = 0
    d_max = middle_index
    x = middle_index
    y = middle_index
    dx = 1
    dy = 0
    current_number = 1

    # populate grid as described in the problem
    while d <= d_max:
      grid[x][y] = current_number
      d_next = distance(middle_index, x + dx, y + dy)
      if d_next > d:
        if dx == 1 and d_next == d + 1: # allow enlarging the distance by 1 only in the "right" direction
          d += 1
          x += dx
          y += dy
          dx, dy = next_direction(dx, dy)
        else: # greater than allowed distance, change direction
          dx, dy = next_direction(dx, dy)
          x += dx
          y += dy
      else: # continue to move in the same direction
        x += dx
        y += dy
      current_number += 1

    answer = 0
    # calculate diagonal sums
    for i in range(0, middle_index + 1):
      answer += grid[i][i]
      if i != middle_index:
        answer += grid[i][n - i - 1]
        answer += grid[n - i - 1][i]
        answer += grid[n - i - 1][n - i - 1]

    return answer