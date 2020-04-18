from abc import ABC, abstractmethod

class Problem(ABC):
  """Project Euler problem (https://projecteuler.net)"""

  def __init__(self, console_output: bool = True, detailed_output: bool = True):
    self._console_output = console_output
    self._detailed_output = detailed_output

  @abstractmethod
  def calculate_answer(self):
    """All inheriting classes should implement this method containing all logic for calculating the answer to the problem."""
    pass

  def answer(self):
    answer = self.calculate_answer()
    if self._console_output:
      print("Answer:")
      print(str(answer))
    return answer


  def print_detail(self, value, end: str = '\n'):
    if self._console_output and self._detailed_output:
      print(str(value), end = end)