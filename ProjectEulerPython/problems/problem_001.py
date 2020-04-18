from problems.problem import Problem

class Problem001(Problem):

  def calculate_answer(self) -> int:
    answer = 0
    n = 1000
    self.print_detail("Multiples:")
    for i in range(1, n):
      if i % 3 == 0 or i % 5 == 0:
        self.print_detail(i)
        answer += i
    return answer