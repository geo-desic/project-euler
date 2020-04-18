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