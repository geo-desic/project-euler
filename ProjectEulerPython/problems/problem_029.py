from problems.problem import Problem

class Problem029(Problem):

  def calculate_answer(self) -> int:
    min_a = 2
    min_b = 2
    max_a = 100
    max_b = 100

    terms = {} # map only allows unique keys
    for a in range(min_a, max_a + 1):
      for b in range(min_b, max_b + 1):
        product = 1
        for i in range(0, b):
          product *= a
        terms[product] = True

    return len(terms)