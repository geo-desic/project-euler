from datetime import date
from problems.problem import Problem

class Problem019(Problem):

  def calculate_answer(self) -> int:
    answer = 0

    self.print_detail("Incremental results:")
    for year in range(1901, 2001):
      year_total = 0
      for month in range(1, 13):
        value = date(year, month, 1)
        if value.weekday() == 6:
          year_total += 1
      self.print_detail(f"{year}: {year_total}")
      answer += year_total

    return answer