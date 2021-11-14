from problems.problem import Problem

VALUE_TARGET = 200
COIN_VALUES = [1, 2, 5, 10, 20, 50, 100, 200]

class Problem031(Problem):

  def calculate_answer(self) -> int:
    self.print_detail("Combinations:")

    val_combinations = [0] * (VALUE_TARGET + 1)
    val_combinations[0] = 1
    for i in range(len(COIN_VALUES)):
      for j in range(COIN_VALUES[i], VALUE_TARGET + 1):
        val_combinations[j] += val_combinations[j - COIN_VALUES[i]]
    if (self._detailed_output):
      for i in range(len(val_combinations)):
        self.print_detail(f"C[{i}] = {val_combinations[i]}")
    return val_combinations[VALUE_TARGET]