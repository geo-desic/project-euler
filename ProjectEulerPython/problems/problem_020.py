from problems.problem import Problem

class Problem020(Problem):

  def calculate_answer(self) -> int:
    n = 100
    product = 1
    for i in range(2, n + 1):
      product *= i

    self.print_detail("Product:")
    self.print_detail(product)

    answer = 0
    product_str = str(product)
    for i in range(0, len(product_str)):
      answer += int(product_str[i])

    return answer