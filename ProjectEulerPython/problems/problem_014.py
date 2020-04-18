from problems.problem import Problem

def collatz(n: int) -> int:
  if n % 2 == 0:
    return n // 2
  return 3 * n + 1

class Problem014(Problem):

  def __init__(self):
    super().__init__()
    self._collatz_length = {}

  def calculate_answer(self) -> int:
    answer = 0
    n = 1000000
    max_chain_length = 0

    self.print_detail("Incremental results:")
    for i in range(1, n):
      length = self.collatz_length(i)
      if length > max_chain_length:
        answer = i
        max_chain_length = length
        self.print_detail("chain length = " + str(length) + "; starting value = " + str(i))

    return answer

  def collatz_length(self, n: int) -> int:
    i = n

    result = 1
    while i != 1:
      i = collatz(i)
      if i in self._collatz_length:
        result += self._collatz_length[i]
        break
      result += 1

    self._collatz_length[n] = result

    return result