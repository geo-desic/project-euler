from problems.problem import Problem

class Problem015(Problem):

  def calculate_answer(self) -> int:
    # every path can be represented by a string of length 40 (= 20 + 20) containing exactly twenty D (down) and twenty R (right) characters
    # example: "RRRRRRRRRRRRRRRRRRRRDDDDDDDDDDDDDDDDDDDD" represents the path going along the top all the way to the right then all the way down
    # the number of such unique strings is simply (40 choose 20) = 40! / (20! * 20!) = (40 * 39 * ... * 22 * 21) / 20!
    # the even factors in the numerator have be simplified with 11 through 20 in the denominator

    answer = (2 * 39 * 2 * 37 * 2 * 35 * 2 * 33 * 2 * 31 * 2 * 29 * 2 * 27 * 2 * 25 * 2 * 23 * 2 * 21) // (10 * 9 * 8 * 7 * 6 * 5 * 4 * 3 * 2)

    return answer