from typing import Dict, List, Optional

class PrimeFactorizationEntry:
  """Objects of this class represent a prime factorization entry, that is a prime and a power.

  Example:
    2^3 is one entry in the prime factorization of 360 = 2^3 * 3^2 * 5
  """

  def __init__(self, prime: int, power: int):
    self.prime = prime
    self.power = power

class PrimeFactorization:
  """Objects of this class represent a prime factorization.

  Example:
    360 = 2^3 * 3^2 * 5
  """

  def __init__(self):
    self._entries_list: List[PrimeFactorizationEntry] = []
    self._entries_dict: Dict[int, PrimeFactorizationEntry] = {}

  def add_entry(self, prime: int, power: int):
    if prime in self._entries_dict:
      self._entries_dict[prime].power = power
    else:
      entry = PrimeFactorizationEntry(prime, power)
      self._entries_dict[prime] = entry
      self._entries_list.append(entry)

  def compute_product(self) -> int:
    result = 1
    for entry in self._entries_list:
      for i in range(1, entry.power + 1):
        result *= entry.prime
    return result

  def entry(self, prime: int) -> Optional[PrimeFactorizationEntry]:
    if prime in self._entries_dict:
      return self._entries_dict[prime]
    return None

  def entries(self) -> List[PrimeFactorizationEntry]:
    return self._entries_list