using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode2023.Models
{
    public  class LinesCheckerModule
    {
        
        public int FindNumberFromLine(string Line,int Flag)
        {
            ICollection<int> Digits = new List<int>();
            if (Flag == 0)
            {
                Digits=DigitsIncluded(Line, Digits);
                return DigitsToDubleDigitNumber(Digits);
            }
            else if(Flag == 1)
            {
                Digits = LettersIncluded(Line, Digits);
            }
            else
            {
                return 0;
            }
            return 0;

        }

        private ICollection<int> LettersIncluded(string line, ICollection<int> Digits)
        {            
            Digits.Add(FindNumber(line));
            return Digits;
        }


        public ICollection<int> DigitsIncluded(string Line,ICollection<int> Digits)
        {
            foreach (char c in Line)
            {
                if (checkIfCharBetweenRange(c))
                {
                    Digits.Add(convertCharToInt(c));
                }
            }
            return Digits;
        }


        public int convertCharToInt(int SingleCharacter)
        {
            return SingleCharacter - 48;
        }
        public bool checkIfCharBetweenRange(char ToCheck)
        {
            int MinimalRange = 48;
            int MaximalRange = 57;
            if (ToCheck >= MinimalRange && ToCheck <= MaximalRange)
            {
                return true;
            }
            return false;
        }
        public int DigitsToDubleDigitNumber(ICollection<int> array)
        {
            int DoubleDigitNumber;
            if (array.Count == 1)
            {
                DoubleDigitNumber = (MergeTwoDigits(array.ElementAt(0), array.ElementAt(0)));
            }
            else
            {
                DoubleDigitNumber = (MergeTwoDigits(array.ElementAt(0), array.ElementAt(array.Count - 1)));
            }
            return DoubleDigitNumber;
        }

        public int MergeTwoDigits(int x, int y)
        {
            return x * 10 + y;
        }

        string[] patterns = new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "1", "2", "3", "4","5","6", "7", "8", "9" };

        public int FindNumber(string Line)
        {
            int patternIndex = 1;
            foreach (var pattern in patterns)
            {
                Match match = Regex.Match(Line, pattern);
                if (match.Success)
                {
                    
                    Console.WriteLine($"Found '{match.Value}' at position {match.Index} : {patternIndex}");
                    return patternIndex;
                }
                patternIndex++;
            }
            return 0;
        }

    }
}
  
