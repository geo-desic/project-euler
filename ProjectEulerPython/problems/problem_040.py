from problems.problem import Problem

class DigitIndexInformation:

  def __init__(self, digit: int, number: int, number_index):
    self.digit = digit
    self.number = number
    self.number_index = number_index

def number_digit(n: int, d: int) -> int:
  return int(str(n)[d])

def digit_index_to_information(i: int) -> DigitIndexInformation:
  d = 0
  n = 0
  ni = 0
  if i < 10: # 1 to 10; digits: 1
    n = i
    ni = 0
    d = i
  elif i < 190: # 10 to 189; digits: 2
    n = i // 2 + 5
    ni = i % 2
    d = number_digit(n, ni)
  elif i < 2890: # 190 to 2889; digits: 3
    n = (i - 1) // 3 + 37
    ni = (i - 1) % 3
    d = number_digit(n, ni)
  elif i < 38890: # 2890 to 38889; digits: 4
    n = (i - 2) // 4 + 278
    ni = (i - 2) % 4
    d = number_digit(n, ni)
  elif i < 488890: # 38890 to 488889; digits: 5
    n = i // 5 + 2222
    ni = i % 5
    d = number_digit(n, ni)
  elif i < 5888890: # 488890 to 5888889; digits: 6
    n = (i - 4) // 6 + 18519
    ni = (i - 4) % 6
    d = number_digit(n, ni)
  elif i < 68888890: # 5888890 to 68888889; digits: 7
    n = i // 7 + 158730
    ni = i % 7
    d = number_digit(n, ni)
  else:
    raise ValueError(f"out of range: i = {i}")
  return DigitIndexInformation(d, n, ni)

class Problem040(Problem):

  def calculate_answer(self) -> int:
    digit_indices = [1, 10, 100, 1000, 10000, 100000, 1000000]

    answer = 1
    digits = []
    for i in digit_indices:
      info = digit_index_to_information(i)
      answer *= info.digit
      digits.append(info.digit)
      self.print_detail(f"d_{i} = {info.digit} (number = {info.number}; index = {info.number_index + 1})")
    self.print_detail(f"{answer} = {' * '.join([str(d) for d in digits])}")

    return answer