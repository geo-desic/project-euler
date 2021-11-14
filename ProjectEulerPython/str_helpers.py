from math_helpers import is_pandigital as mh_is_pandigital

INT_WORDS_BELOW_20 = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"]
INT_WORDS_TENS_DIGIT = ["ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"]
INT_WORDS_AND = "and"
INT_WORDS_HUNDRED_SUFFIX = "hundred"
INT_WORDS_NEGATIVE = "negative"
INT_WORDS_SUFFIX_POWERS_1000 = ["thousand", "million", "billion", "trillion", "quadrillion", "quintillion", "sextillion", "septillion", "octillion", "nonillion", "decillion"]

def index_first_char_not_equal_to(value: str, char: str, start_index: int = 0) -> int:
  """Returns the index of the first character in string 'value' not containing the character provided by 'char' starting at index start_index."""
  for i in range(start_index, len(value)):
    if value[i] != char:
      return i
  return -1

def int_to_words(n: int, include_and: bool = True) -> str:
  """Returns the integer n as a string of words.

  Args:
    n: The integer for which words will be provided.
    include_and: If True, the word 'and' will be included in the output. Otherwise, it will be omitted.

  Example:
    19356 would return 'nineteen thousand three hundred and fifty six'

  """
  list = []
  n_str = str(n)

  if n_str[0] == "-":
    list.append(INT_WORDS_NEGATIVE)
    n_str = n_str[1:]

  digits_remaining = n_str

  while True:
    i = index_first_char_not_equal_to(digits_remaining, "0")
    if i < 0:
      digits_remaining = ""
    else:
      digits_remaining = digits_remaining[i:]
    if len(digits_remaining) > 0:
      power_1000 = (len(digits_remaining) - 1) // 3
      digits_group = digits_remaining[0:len(digits_remaining) - 3 * power_1000]
      if len(digits_group) == 3:
        first_digit = int(digits_group[0])
        list.append(INT_WORDS_BELOW_20[first_digit])
        list.append(INT_WORDS_HUNDRED_SUFFIX)
        if include_and and index_first_char_not_equal_to(digits_remaining, "0", 1) > 0:
          list.append(INT_WORDS_AND)
      digits_remaining_group = digits_group[-2:]
      if digits_remaining_group == "00":
        pass
      else:
        ones_digit = int(digits_remaining_group[-1])
        tens_digit = 0
        if len(digits_remaining_group) > 1:
          tens_digit = int(digits_remaining_group[0])
        if (len(digits_remaining_group) == 2 and (digits_remaining_group[0] == "0" or digits_remaining_group[0] == "1")) or len(digits_remaining_group) == 1:
          value = ones_digit + 10 * tens_digit
          list.append(INT_WORDS_BELOW_20[value])
        else:
          list.append(INT_WORDS_TENS_DIGIT[tens_digit - 1])
          if ones_digit > 0:
            list.append(INT_WORDS_BELOW_20[ones_digit])
      if power_1000 > 0:
        list.append(INT_WORDS_SUFFIX_POWERS_1000[power_1000 - 1])
      if len(digits_group) >= len(digits_remaining):
        digits_remaining = ""
      else:
        digits_remaining = digits_remaining[len(digits_group):]
    if len(digits_remaining) == 0:
      break

  answer = " ".join(list)

  return answer

def is_palindrome(s: str) -> bool:
  return s == reverse(s)

def is_pandigital(value: str, d_min: int, d_max: int) -> bool:
  """Returns true if the strings digits are pandigital (i.e. contain all digits from min to max exactly once), false otherwise.

  Args:
    value: String of digits where each character is between 0 and 9
    d_min: The pandigital digit minimum bound
    d_max: The pandigital digit maximum bound

  Examples:
    is_pandigital("3142", 1, 4) returns true
    is_pandigital("3122", 1, 4) returns false

  """
  if value is None or len(value) == 0:
    return False
  digits = [int(d) for d in value]
  return mh_is_pandigital(digits, d_min, d_max)

def reverse(s: str) -> str:
  """Reverses the string provided.

  Example:
    "Abcd" returns "dcbA".

  """
  return s[::-1]

def right(s: str, length: int) -> str:
  """Returns the string's rightmost characters of the length provided."""
  if (length == 0):
    return ""
  if (length > len(s)):
    return s
  return s[-length:]