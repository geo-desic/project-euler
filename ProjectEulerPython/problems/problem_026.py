from problems.problem import Problem

def min_pow_10_mult_of_r_greater_than_d(d: int, r: int) -> int:
  a = r
  while d > a:
    a *= 10
  return a

def cycle_length(d: int) -> int:
  result = 0
  r = 1
  seen = {}
  while not r in seen:
    seen[r] = result
    dividend = min_pow_10_mult_of_r_greater_than_d(d, r)
    r = dividend % d
    if r == 0:
      return 0
    result += 1

  return result - seen[r]

class Problem026(Problem):

  def calculate_answer(self) -> int:
    answer = 0
    n = 1000
    longest_cycle_length = 0

    for d in range(2, n):
      length = cycle_length(d)
      if length > longest_cycle_length:
        answer = d
        longest_cycle_length = length
        self.print_detail("d = " + str(d) + "; cycle length = " + str(length))

    return answer