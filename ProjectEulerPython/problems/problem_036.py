import int_helpers
import str_helpers
from problems.problem import Problem

class Problem036(Problem):

  def calculate_answer(self) -> int:
    answer = 0
    n = 1000000

    self.print_detail("Incremental Results:")

    for i in range(1, n):
      i_bin = bin(i)[2:]
      if int_helpers.is_palindrome(i) and str_helpers.is_palindrome(i_bin):
        self.print_detail(f"{i}; {i_bin}")
        answer += i

    return answer