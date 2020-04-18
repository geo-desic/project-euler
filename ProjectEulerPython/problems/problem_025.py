from problems.problem import Problem

class Problem025(Problem):

  def calculate_answer(self) -> int:
    a = 1
    b = 1
    total_digits = 1000
    detail_size = total_digits // 10
    detail_threshold = detail_size

    answer = 3
    while True:
      c = a + b
      digit_count = len(str(c))
      if digit_count == total_digits:
        break
      elif digit_count >= detail_threshold:
        self.print_detail("index = " + str(answer) + "; length = " + str(digit_count))
        detail_threshold += detail_size
      a = b
      b = c
      answer += 1

    return answer