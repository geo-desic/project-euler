def reverse_elements(elements: [object], start_index: int = -1, end_index: int = -1) -> [object]:
  """Reverses the elements of a list in-place from start_index to end_index."""
  if len(elements) == 0:
    return elements

  if start_index < 0:
    start_index = 0
  if end_index < 0:
    end_index = len(elements) - 1

  left_index = start_index
  right_index = end_index
  while left_index < right_index:
    temp = elements[left_index]
    elements[left_index] = elements[right_index]
    elements[right_index] = temp
    left_index += 1
    right_index -= 1

  return elements