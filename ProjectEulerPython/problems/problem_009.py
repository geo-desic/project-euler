from problems.problem import Problem

class Problem009(Problem):

  def calculate_answer(self) -> int:
    answer = 0
    n = 1000

    for a in range(1, n):
      # due to symmetry between a and b we can assume a <= b
      for b in range(a, n - a):
        c = n - a - b # since a + b + c = n
        if a * a + b * b == c * c:
          answer = a * b * c
          self.print_detail("a = " + str(a) + "; b = " + str(b) + "; c = " + str(c))
          break

    if answer == 0:
      raise RuntimeError("Answer was not found")

    return answer
