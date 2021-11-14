import int_helpers
import math_helpers
from problems.problem import Problem

def count_digits_base4_to_max_index10(c: int) -> int:
  result = 0
  factor = 1
  for i in range(c):
    result += factor * 3
    factor *= 4
  return result

def digit_mapping_left(d: int) -> int:
  # 0 => 2
  # 1 => 3
  # 2 => 5
  # 3 => 7
  if d == 0:
    return 2
  if d == 1:
    return 3
  if d == 2:
    return 5
  if d == 3:
    return 7
  raise ValueError(f"invalid digit: {d}")

def digit_mapping_middle(d: int) -> int:
  # 0 => 1
  # 1 => 3
  # 2 => 7
  # 3 => 9
  if d == 0:
    return 1
  if d == 1:
    return 3
  if d == 2:
    return 7
  if d == 3:
    return 9
  raise ValueError(f"invalid digit: {d}")

def digit_mapping_right(d: int) -> int:
  # 0 => 3
  # 1 => 7
  if d == 0:
    return 3
  if d == 1:
    return 7
  raise ValueError(f"invalid digit: {d}")

def upper_bound_sieve(c: int) -> int:
  power10 = int_helpers.power(10, c + 1)
  return 10 * (7 * power10 + (power10 - 1)) + 7

class Problem037(Problem):

  def calculate_answer(self) -> int:
    # must be at least 2 digits or more
    # allowable digits
    # left   : 2, 3, 5, 7 (single digit primes)
    # middle : 1, 3, 7, 9 (0, 2, 4, 5, 6, 8 would not work because after right truncation to that digit it would be divisible by 2 or 5)
    # right  : 3, 7       (single digit primes except 2 and 5 since it would not be prime for two or more digits)

    answer = 0
    count_middle_digits_bound = 4
    is_prime = math_helpers.index_prime_by_sieve(upper_bound_sieve(count_middle_digits_bound))

    self.print_detail("Incremental Results:")

    for count_middle_digits in range(count_middle_digits_bound + 1):
      max_index = count_digits_base4_to_max_index10(count_middle_digits)
      for m in range(max_index + 1):
        middle_digits = 0
        factor10_middle = 1
        m_temp = m
        for d in range(count_middle_digits):
          middle_digits += factor10_middle * digit_mapping_middle(m_temp % 4)
          m_temp //= 4
          factor10_middle *= 10
        for l in range(4):
          left_and_middle_digits = factor10_middle * digit_mapping_left(l) + middle_digits
          factor10_left_and_middle = factor10_middle * 10
          for r in range(2):
            number = 10 * left_and_middle_digits + digit_mapping_right(r)
            prime_truncatable_left = True
            prime_truncatable_right = True

            number_truncated_right = number
            while number_truncated_right > 0:
              if not is_prime[number_truncated_right]:
                prime_truncatable_right = False
                break
              number_truncated_right //= 10

            if prime_truncatable_right:
              number_truncated_left = number
              factor_mod = factor10_left_and_middle
              while number_truncated_left > 0:
                if not is_prime[number_truncated_left]:
                  prime_truncatable_left = False
                  break
                number_truncated_left %= factor_mod
                factor_mod //= 10

              if prime_truncatable_left:
                self.print_detail(number)
                answer += number

    return answer