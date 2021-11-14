from problems.problem import Problem

def is_1_through_9_pandigital(n: str) -> bool:
  bitstring = 0
  for i in range(len(n)):
    d = ord(n[i]) - 48
    bit = 0x1 << d
    if d == 0 or (bitstring & bit) > 0:
      return False
    bitstring |= bit
  return True

class Problem032(Problem):

  def calculate_answer(self) -> int:
    answer = 0

    # m := multiplicand, n := multiplier, p := product
    # p = m * n where m < n
    #
    # 3 possible cases:
    # (1) m is 1 digit, n is 4 digits, and p is 4 digits
    # (2) m is 2 digits, n is 4 digits, and p is 3 digits
    # (3) m is 2 digits, n is 3 digits, and p is 4 digits

    unique_products = []

    self.print_detail("Incremental Results:")

    for m in range(2, 100):
      n_min = 1000 // m # 1000 is the smallest 4 digit number
      n_max = 9999 // m # 9999 is the largest 4 digit number
      if n_min <= m: # n must be larger than m
        n_min = m + 1
      if n_max <= m: # n must be larger than m
        n_max = m + 1
      if "0" not in str(m): # skip if m contains the digit 0
        for n in range(n_min, n_max + 1):
          p = n * m
          identity_string = str(n) + str(m) + str(p)
          if len(identity_string) == 9 and is_1_through_9_pandigital(identity_string):
            if p not in unique_products:
              unique_products.append(p)
              answer += p
              self.print_detail(f"{p} = {m} * {n}")
    return answer