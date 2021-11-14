from problems.problem import Problem

def digit_factorial(d: int) -> int:
  if d == 0:
    return 1
  if d == 1:
    return 1
  if d == 2:
    return 2
  if d == 3:
    return 6
  if d == 4:
    return 24
  if d == 5:
    return 120
  if d == 6:
    return 720
  if d == 7:
    return 5040
  if d == 8:
    return 40320
  if d == 9:
    return 362880
  raise ValueError("invalid digit")

class Problem034(Problem):

  def calculate_answer(self) -> int:
    answer = 0

    self.print_detail("Incremental Results:")

    for n in range(10, 99999):
      value = n
      digit = 0
      digit_factorial_sum = 0
      while value > 0:
        digit = value % 10
        digit_factorial_sum += digit_factorial(digit)
        value //= 10
      if n == digit_factorial_sum:
        self.print_detail(n)
        answer += n

    return answer