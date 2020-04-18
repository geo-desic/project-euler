import list_helpers
import math
from prime_factorization import PrimeFactorization, PrimeFactorizationEntry

def divisor_count(n: int, proper: bool = False, ordered_primes: [int] = None) -> int:
  """Returns the number of positive divisors of n.

  This uses the following formula:
     If n = p^a * q^b * r^c *... is a prime factorization of n, then the number of divisors, d(n) = (a + 1)(b + 1)(c + 1)...
     For proof, see: https://math.stackexchange.com/questions/433848/prime-factors-number-of-divisors

  Example:
    12 has proper positive divisors 1, 2, 3, 4, and 6; 12 is included if proper = False
  """
  result = 1
  factorization = prime_factorization(n, ordered_primes)
  for entry in factorization.entries():
    result *= entry.power + 1

  if proper:
    result -= 1

  return result

def divisors(n: int, proper: bool = False, ordered_primes: [int] = None) -> [int]:
  """Returns a list of all (proper) divisors of the integer n.

  Args:
    n: Divisors will be provided for this integer.
    proper: If False, all divisors will be provided. If True, only proper divisors will be provided (i.e. divisors not equal to n).
    ordered_primes: If provided, this should be a list of all prime numbers in increasing order between 1 and the square root of n (inclusive).

  """
  factorization = prime_factorization(n, ordered_primes)
  divisor_factorization = PrimeFactorization()
  for entry in factorization.entries():
    divisor_factorization.add_entry(entry.prime, 0)

  result = []
  product = 1
  while True:
    if not proper or product != n:
      result.append(product)

    incremented = False
    for divisor_entry in divisor_factorization.entries():
      if divisor_entry.power < factorization.entry(divisor_entry.prime).power:
        product *= divisor_entry.prime
        divisor_entry.power += 1
        incremented = True
        break
      else:
        for i in range(0, divisor_entry.power):
          product = product // divisor_entry.prime
        divisor_entry.power = 0
    if not incremented:
      break

  return result

def index_prime_by_sieve(n: int) -> [bool]:
  """Returns a boolean list where the ith entry (i.e. index) is True if i is a prime number."""
  result = [True for i in range(n + 1)]
  result[0] = False
  result[1] = False
  for i in range(2, int(math.sqrt(n)) + 1):
    if result[i]:
      for j in range(i * i, n + 1, i):
        result[j] = False
  return result

def lexicographic_permute(elements: [object]) -> bool:
  """Modifies the list (in-place) to the next lexicographical permutation. Returns True if the next permutation is the initial one, False otherwise.

  Examples:
    [A, C, B] would be modified to [B, A, C] and False would be returned
    [C, B, A] would be modified to [A, B, C] and True would be returned

  """
  last_index = len(elements) - 1

  if last_index < 1:
    return True

  i = last_index - 1
  while i >= 0 and not elements[i] < elements[i + 1]:
    i -= 1

  result = False
  if i < 0:
    result = True
    elements.reverse() # reverse all elements
  else:
    j = last_index
    while j > i + 1 and not elements[j] > elements[i]:
      j -= 1
    #swap elements[i] with elements[j]
    temp = elements[i]
    elements[i] = elements[j]
    elements[j] = temp
    list_helpers.reverse_elements(elements, i + 1) # reverse the elements (in place) indexed i + 1 through the end of the list

  return result


def nth_triangular_number(n: int) -> int:
  """Returns the nth triangular number; for proof see: https://en.wikipedia.org/wiki/Triangular_number"""
  return n * (n + 1) // 2

def prime_factorization(n: int, ordered_primes: [int] = None) -> PrimeFactorization:
  """Returns a prime factorization for the integer n.

  Args:
    n: The integer (target) for the prime factorization.
    ordered_primes: If provided it should be a comprehensive increasing list of all primes less than or equal to the square root of n.

  Example:
    360 = 2^3 * 3^2 * 5

  """
  result = PrimeFactorization()
  power = 0

  if (n < 0):
    n = -n

  if ordered_primes is None:
    # 2, the only even prime, is treated separately so the for loop below is more efficient (i.e. it can increment by 2 instead of 1)
    while n % 2 == 0:
      n /= 2
      power += 1

    if power > 0:
      result.add_entry(2, power)

    for i in range(3, int(math.sqrt(n)) + 1, 2):
      power = 0
      while n % i == 0:
        n = n // i
        power += 1
      if power > 0:
        result.add_entry(i, power)
  else:
    for p in ordered_primes:
      power = 0
      while n % p == 0:
        n = n // p
        power += 1
      if power > 0:
        result.add_entry(p, power)

  if n > 2:
    result.add_entry(n, 1)

  return result

def primes_below(n: int) -> [int]:
  """Returns a list of all prime numbers in increasing order between 2 and the integer n."""
  result = []
  prime_sieve = index_prime_by_sieve(n)
  for i in range(2, len(prime_sieve)):
    if prime_sieve[i]:
      result.append(i)
  return result