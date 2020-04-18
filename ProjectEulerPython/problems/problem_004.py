import int_helpers
from problems.problem import Problem

class Problem004(Problem):

  def calculate_answer(self) -> int:
    answer = 0

    self.print_detail("Incremental results:")
    for i in range(999, 99, -1):
      for j in range(999, i - 1, -1):
        product = i * j
        if product <= answer:
          break
        if int_helpers.is_palindrome(product):
          answer = product
          self.print_detail(str(product) + " = " + str(i) + " * " + str(j))
          break

    return answer