from problems.problem import Problem

class Problem002(Problem):

  def calculate_answer(self) -> int:
    answer = 0
    a = 1
    b = 2
    n = 4000000

    self.print_detail("Even terms:")
    while b <= n:
      if b % 2 == 0:
        self.print_detail(b)
        answer += b
      c = a + b
      a = b
      b = c
    return answer