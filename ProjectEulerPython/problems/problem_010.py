import math_helpers
from problems.problem import Problem

class Problem010(Problem):

  def calculate_answer(self) -> int:
    answer = 0
    n = 2000000
    prime_sieve = math_helpers.index_prime_by_sieve(n)

    for i in range(2, n):
      if prime_sieve[i]:
        answer += i

    return answer
