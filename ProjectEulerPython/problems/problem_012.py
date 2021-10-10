import math_helpers
from problems.problem import Problem

class Problem012(Problem):

  def calculate_answer(self) -> int:
    answer = 0
    n = 65535 # guess, but for accuracy this should be at least the square root of the answer

    i = 1
    max_divisors = 1
    primes = math_helpers.primes_below(n)
    self.print_detail("Incremental results:")
    while max_divisors <= 500:
      triangular_number = math_helpers.nth_triangular_number(i)
      divisors = math_helpers.divisor_count(triangular_number, primes)
      if (divisors > max_divisors):
        max_divisors = divisors
        answer = triangular_number
        self.print_detail(f"Triangular #: {i} = {triangular_number}; divisor count = {divisors}")
      i += 1

    return answer
