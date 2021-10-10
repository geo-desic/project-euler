import math_helpers
from prime_factorization import PrimeFactorization
from problems.problem import Problem

class Problem005(Problem):

  def calculate_answer(self) -> int:
    lcm_factorization = PrimeFactorization()

    self.print_detail("Incremental results:")
    for i in range(2, 20):
      factorization = math_helpers.prime_factorization(i)
      for entry in factorization.entries():
        lcm_entry = lcm_factorization.entry(entry.prime)
        if lcm_entry is None:
          lcm_factorization.add_entry(entry.prime, entry.power)
        else:
          if entry.power > lcm_entry.power:
            lcm_entry.power = entry.power
      self.print_detail(f"{i}: {lcm_factorization.compute_product()}")

    return lcm_factorization.compute_product()