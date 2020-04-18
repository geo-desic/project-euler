from problems.problem import Problem

def populate_digits(n: int, digits: [int]):
  for i in range(0, len(digits)):
    d = 0
    if n > 0:
      d = n % 10
      n //= 10
    digits[i] = d

def sum_5th_powers(digits: [int]) -> int:
  result = 0
  for d in digits:
    result += d * d * d * d * d
  return result

class Problem030(Problem):

  def calculate_answer(self) -> int:
    max = 5 * 9 * 9 * 9 * 9 * 9 # 9^5 + 9^5 + 9^5 + 9^5 + 9^5 = 295245
    max_digits = 9
    digits = [0 for i in range(0, max_digits)]

    answer = 0
    self.print_detail("Incremental results:")
    for i in range(2, max + 1):
      populate_digits(i, digits)
      if i == sum_5th_powers(digits):
        answer += i
        self.print_detail(i)

    return answer