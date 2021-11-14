from problems.problem import Problem

def generate_pythagorean_triples(ub: int) -> []:
  # https://en.wikipedia.org/wiki/Pythagorean_triple
  result = []
  for a in range(1, ub):
    aa = a * a
    b = a + 1
    c = b + 1
    while c <= ub:
      cc = aa + b * b
      while c * c < cc:
        c += 1
      if c * c == cc and c <= ub:
        result.append([a + b + c, a, b, c])
      b += 1
  return result

class Problem039(Problem):

  def calculate_answer(self) -> int:
    # p = perimeter
    # a < b < c = hypotenuse
    answer = 0
    max_perimeter = 1000
    solution_counts = [0 for i in range(max_perimeter + 1)]
    triangles = generate_pythagorean_triples(max_perimeter // 2 + 1)
    max_solutions = 0
    for triangle in triangles:
      p = triangle[0]
      if p <= max_perimeter:
        solution_counts[p] += 1
        solutions = solution_counts[p]
        if (solutions > max_solutions):
          max_solutions = solutions
          answer = p
          self.print_detail(f"p = {answer}; solutions = {solutions}")
    return answer
