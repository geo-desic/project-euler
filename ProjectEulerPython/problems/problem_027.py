import math_helpers
from problems.problem import Problem

def f(n:int, a: int, b: int) -> int:
  """f(n) = n^2 + an + b"""
  return n * n + a * n + b

class Problem027(Problem):

  def calculate_answer(self) -> int:
    upper_bound_n = 100 # guess
    upper_bound_f = f(upper_bound_n, 99, 1000)
    prime_sieve = math_helpers.index_prime_by_sieve(upper_bound_f)

    #f(0) = b ==> b must be a (positive) prime
    primes_below_1000 = math_helpers.primes_below(1000)
    max_length = 0

    a = 1
    b = 1

    for b_inc in primes_below_1000:
      for a_inc in range(1, 1000, 2):
        for unit in range(-1, 3, 2):
          length = 0
          n = 0
          a_current = unit * a_inc
          while True:
            f_n = f(n, a_current, b_inc)
            if f_n < 0:
              f_n = -f_n
            if prime_sieve[f_n]:
              length += 1
            else:
              break
            n += 1
          if length > max_length:
            a = a_current
            b = b_inc
            max_length = length
            self.print_detail("length = " + str(length) + "; a = " + str(a) + "; b = " + str(b))

    return a * b