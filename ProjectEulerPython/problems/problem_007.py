import math
import math_helpers
from problems.problem import Problem

def upper_bound(n: int) -> int:
  """For proof, see the section "Approximations for the nth prime number" at https://en.wikipedia.org/wiki/Prime_number_theorem"""
  if n <= 5:
    return 11;
  return int(n * (math.log(n) + math.log(math.log(n))))

class Problem007(Problem):

  def calculate_answer(self) -> int:
    n = 10001
    ub = upper_bound(n)
    prime_sieve = math_helpers.index_prime_by_sieve(ub)

    self.print_detail("Incremental results:")
    index = 0
    for i in range(2, ub + 1):
      if prime_sieve[i]:
        self.print_detail(i)
        index += 1
        if (index >= n):
          break;
    if (index < n):
      raise RuntimeError("Invalid upper bound: " + str(ub))

    return i
