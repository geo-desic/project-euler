def is_palindrome(n: int) -> bool:
  """Returns True if the integer is the same as the integer with all digits reversed, False otherwise."""
  return n == reverse_digits(n)

def power(b: int, e: int) -> int:
  """Returns the base value to the power of the exponent as an integer.

  Example:
    (5, 3) returns 125 = 5^3.

  Args:
    b: The base value.
    e: The exponent value.
  """
  result = 1
  while e > 0:
    if e & 0x1:
      result *= b
    e >>= 1
    b *= b
  return result

def reverse_digits(n: int) -> int:
  """Returns: The integer with all digits reversed.

  Example: 4297341 would return 1437924

  """
  negative = False
  if n < 0:
    negative = True
    n = -n

  result = 0
  while n > 0:
    result = result * 10 + n % 10
    n //= 10

  if negative:
    return -result

  return result

def to_digits(n: int) -> [int]:
  """Returns a list containing all digits in the integer provided starting at the least significant digit and increasing to the most significant digit.

  Args:
    n: The integer whose digits are to be determined.

  """
  result = []
  if n < 0:
    n = -n
  elif value == 0:
    result.append(0)
  while n > 0:
    result.append(n % 10)
    n = n // 10
  return result