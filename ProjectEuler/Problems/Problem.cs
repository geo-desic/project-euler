using System;

namespace ProjectEuler.Problems
{
    public abstract class Problem<T>
    {
        public Problem(bool consoleOutput = true, bool detailedOutput = true)
        {
            ConsoleOutput = consoleOutput;
            DetailedOutput = detailedOutput;
        }

        public bool ConsoleOutput { get; set; }

        public bool DetailedOutput { get; set; }

        protected abstract T CalculateAnswer();

        public T Answer()
        {
            var answer = CalculateAnswer();

            if (ConsoleOutput)
            {
                Console.WriteLine("Answer:");
                Console.WriteLine(answer);
            }

            return answer;
        }

        protected void WriteLineDetail(object value)
        {
            if (ConsoleOutput && DetailedOutput)
            {
                Console.WriteLine(value);
            }
        }
    }
}
