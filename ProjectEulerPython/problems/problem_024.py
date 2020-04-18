import math_helpers
from problems.problem import Problem

class Problem024(Problem):

  def calculate_answer(self) -> int:
    elements = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
    n = 1000000
    batch = n // 20

    index = 1
    returned_first_permutation = False
    while True:
      if index % batch == 0:
        self.print_detail(str(index) + ": " + str(elements))
      if index == n or returned_first_permutation:
        break
      result = math_helpers.lexicographic_permute(elements)
      index += 1
      if result:
        returned_first_permutation = True

    answer = ""
    for i in range(0, len(elements)):
      answer += str(elements[i])
    return answer