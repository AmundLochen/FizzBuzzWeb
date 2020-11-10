using System;
using System.Linq;

namespace FizzBuzz
{
    public class FizzBuzzService
    {
        public int Length {get; set;}
        public bool Fuzz { get; set; }
        public bool Jazz { get; set; }
        public bool Backwards { get; set; }

        public FizzBuzzService(int length, bool fuzz = false, bool jazz = false, bool backwards = false)
        {
            Length = length;
            Fuzz = fuzz;
            Jazz = jazz;
            Backwards = backwards;
        }

        public string[] GetFizzBuzzResult()
        {
            string[] result = new string[Length];

            for (int i = 0; i < Length; i++)
            {
                int number = i + 1;
                if (number % 3 == 0)
                    result[i] += "Fizz";
                if (Fuzz && number % 4 == 0)
                    result[i] += "Fuzz";
                if (number % 5 == 0)
                    result[i] += "Buzz";
                if (Jazz && number % 9 == 0)
                    result[i] += "Jazz";
                if (result[i] == null)
                    result[i] = number.ToString();
            }
            if (Backwards)
                return result.Reverse().ToArray();

            return result;
        }
    }
}
