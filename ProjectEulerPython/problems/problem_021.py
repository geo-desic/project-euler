import math_helpers
from problems.problem import Problem

class Problem021(Problem):

  def __init__(self):
    super().__init__()
    self._cache = {}

  def calculate_answer(self) -> int:
    answer = 0
    n = 10000
    primes = math_helpers.primes_below(n)

    for i in range(2, n):
      sum_1 = self.sum_proper_divisors(i, primes)
      sum_2 = self.sum_proper_divisors(sum_1, primes)
      if i == sum_2 and i != sum_1:
        answer += i
        self.print_detail(f"amicable number: {i} ({sum_1}); sum = {answer}")

    return answer

  def sum_proper_divisors(self, n: int, primes: [int]) -> int:
    if n in self._cache:
      return self._cache[n]

    value = sum(math_helpers.divisors(n, True, primes))
    self._cache[n] = value

    return value