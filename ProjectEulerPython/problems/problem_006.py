from problems.problem import Problem

def sum_squares_1_to_n(n: int) -> int:
  """For proof of this formula, see https://math.stackexchange.com/questions/48080/sum-of-first-n-squares-equals-fracnn12n16"""
  return n * (n + 1) * (2 * n + 1) // 6

def sum_1_to_n_squared(n: int) -> int:
  """For proof of the formula (first line), see https://en.wikipedia.org/wiki/Triangular_number"""
  sum = n * (n + 1) // 2
  return sum * sum

class Problem006(Problem):

  def calculate_answer(self) -> int:
    n = 100
    sum_squares = sum_squares_1_to_n(n)
    sum_squared = sum_1_to_n_squared(n)

    self.print_detail("Sum of squares 1 to " + str(n) + ":")
    self.print_detail(sum_squares)
    self.print_detail("Sum 1 to " + str(n) + " squared:")
    self.print_detail(sum_squared)

    return sum_squared - sum_squares
