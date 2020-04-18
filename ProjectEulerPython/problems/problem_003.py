import math_helpers
from problems.problem import Problem

class Problem003(Problem):

  def calculate_answer(self) -> int:
    answer = 0
    n = 600851475143
    prime_factorization = math_helpers.prime_factorization(n)

    self.print_detail("Prime factors:")
    for entry in prime_factorization.entries():
      self.print_detail(entry.prime)
      if (entry.prime) > answer:
        answer = entry.prime

    return answer