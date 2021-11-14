import math
from problems.problem import Problem

def fractions_equivalent(n1: int, d1: int, n2: int, d2: int) -> bool:
  return n1 * d2 == n2 * d1

class Problem033(Problem):

  def calculate_answer(self) -> int:
    # n  : numerator
    # n10: numerator's tens digit
    # n1 : numerator's ones digit
    # d  : denomiator
    # d10: denomiator's tens digit
    # d1 : denomiator's ones digit
    n_product = 1
    d_product = 1

    self.print_detail("Incremental Results:")

    for n10 in range(1, 10):
      for n1 in range(1, 10):
        if n1 != n10:
          n = n10 * 10 + n1
          # a: non-cancelled digit in denominator
          for a in range(1, 10):
            # case d1 == a   ==>  d10 == n1
            d1 = a
            d10 = n1
            d = d10 * 10 + d1
            if n < d and fractions_equivalent(n, d, n10, d1):
              self.print_detail(f"{n} / {d} = {n10} / {d1}") # str(n) + " / " + str(d) + " = " + str(n10) + " / " + str(d1)
              n_product *= n10
              d_product *= d1
            # case d10 == a  ==>  d1  == n10
            d1 = n10
            d10 = a
            d = d10 * 10 + d1
            if n < d and fractions_equivalent(n, d, n1, d10):
              self.print_detail(f"{n} / {d} = {n1} / {d10}") # str(n) + " / " + str(d) + " = " + str(n1) + " / " + str(d10)
              n_product *= n1
              d_product *= d10
    gcd = math.gcd(n_product, d_product)
    n_product //= gcd
    d_product //= gcd
    self.print_detail("Product In Lowest Terms:")
    self.print_detail(f"{n_product} / {d_product}")

    return d_product