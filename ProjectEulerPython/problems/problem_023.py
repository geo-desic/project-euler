import math_helpers
from problems.problem import Problem

class Problem023(Problem):

  def calculate_answer(self) -> int:
    answer = 0
    upper_bound = 28123 # from problem description

    primes = math_helpers.primes_below(upper_bound)
    abundant_numbers = []

    for i in range(1, upper_bound + 1):
      if sum(math_helpers.divisors(i, True, primes)) > i:
        abundant_numbers.append(i)

    done = False
    two_abundant_number_sums = {}
    for i in range(0, len(abundant_numbers)):
      for j in range(i, len(abundant_numbers)):
        value = abundant_numbers[i] + abundant_numbers[j]
        if value <= upper_bound:
          two_abundant_number_sums[value] = True
        else:
          if 2 * abundant_numbers[i] > upper_bound:
            done = True
            break
      if done:
        break

    for i in range(1, upper_bound):
      if not i in two_abundant_number_sums:
        answer += i
        self.print_detail(f"{i}; sum = {answer}")

    return answer