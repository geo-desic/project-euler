from problems.problem import Problem

# 2^100
TWO_TO_100 = 1267650600228229401496703205376

class Problem016(Problem):

  def calculate_answer(self) -> int:
    product = TWO_TO_100
    for i in range(2, 11):
      product *= TWO_TO_100
    self.print_detail("Product:")
    self.print_detail(product)

    answer = 0
    product_str = str(product)
    for i in range(0, len(product_str)):
      answer += int(product_str[i])

    return answer