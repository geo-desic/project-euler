import int_helpers
import math_helpers
from problems.problem import Problem

def rotate_digits_right(value: int, length: int) -> int:
  if length == 1:
    return value
  ones_digit = value % 10
  value //= 10
  return int_helpers.power(10, length - 1) * ones_digit + value

class Problem035(Problem):

  def calculate_answer(self) -> int:
    answer = 0
    n = 1000000

    is_prime = math_helpers.index_prime_by_sieve(n)

    primes = []
    for i in range(2, n):
      if is_prime[i]:
        primes.append(i)

    self.print_detail("Incremental Results:")

    for p in primes:
      p_str = str(p)
      if p < 10:
        answer += 1
        self.print_detail(p)
      # if the prime is two digits or longer, it cannot include 0, 2, 4, 5, 6, or 8 because at least one rotation would be divisible by 2 or 5
      elif "0" not in p_str and "2" not in p_str and "4" not in p_str and "5" not in p_str and "6" not in p_str and "8" not in p_str:
        all_rotations_prime = True
        rotation = p
        while True:
          rotation = rotate_digits_right(rotation, len(p_str))
          if not is_prime[rotation]:
            all_rotations_prime = False
            break
          if rotation == p:
            break
        if all_rotations_prime:
          answer += 1
          self.print_detail(p)

    return answer