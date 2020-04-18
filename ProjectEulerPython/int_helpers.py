def is_palindrome(n: int) -> bool:
  """Returns True if the integer is the same as the integer with all digits reversed, False otherwise."""
  return n == reverse_digits(n)

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
    n = n // 10

  if negative:
    return -result

  return result