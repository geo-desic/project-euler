import int_helpers
import str_helpers
from problems.problem import Problem

class Problem038(Problem):

  def calculate_answer(self) -> int:
    # (1, 2, ..., n) and let i be the integer
    # i must start with 9 to be larger than the example given, 918273645
    # i must be less than 5 digits since n > 2 and can't be 2 or 3 digits since the result would not be exactly 9 digits
    # so we only need to check i between 9000 and 9999 (for n = 2)
    # i concatenated by 2i is 100000i + 2i = 100002i

    answer = 918273645 # example given
    for i in range(9999, 8999, -1):
      m = 100002 * i
      if str_helpers.is_pandigital(str(m), 1, 9):
        answer = m
        break

    return answer