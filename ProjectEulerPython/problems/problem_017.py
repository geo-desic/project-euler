from problems.problem import Problem
import str_helpers

class Problem017(Problem):

  def calculate_answer(self) -> int:
    answer = 0
    n = 1000

    for i in range(1, n + 1):
      answer += len(str_helpers.int_to_words(i).replace(" ", ""))

    return answer