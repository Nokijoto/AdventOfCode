using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2023.Models
{
    internal class RegexCheckerModule
    {
        public int FindNumberFromLine(string Line,int Flag)
        {
            int FoundNumber=0;
            if(Flag == 0)
            {
                FoundNumber = FindNumbersOnly(Line);
            }
            else if(Flag == 1)
            {
                FoundNumber = FindNumbersInLetters(Line);
            }
            else
            {
                Console.WriteLine("Wrong Flag");
            }
            return FoundNumber;
        }

        private int FindNumbersInLetters(string line)
        {

            string[] funnyConnectedParts = { "oneight","eightwo","eighthree","nineight","twone","fiveight","sevenine"};
            foreach (var part in funnyConnectedParts)
            {
                if (line.Contains(part))
                {
                    switch (part)
                    {
                        case "oneight": line = line.Replace(part, "18"); break;
                        case "eightwo": line = line.Replace(part, "82"); break;
                        case "eighthree": line = line.Replace(part, "83"); break;
                        case "nineight": line = line.Replace(part, "98"); break;
                        case "twone": line = line.Replace(part, "21"); break;
                        case "fiveight": line = line.Replace(part, "58"); break;
                        case "sevenine": line = line.Replace(part, "79"); break;
                    }
                }
            }
            string[] patterns = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string pattern = @"one|two|three|four|five|six|seven|eight|nine|\d";
            List<int> matches = new List<int>();

            MatchCollection matchCollection = Regex.Matches(line, pattern);

            foreach (Match match in matchCollection)
            {
                    int number;
                    if (int.TryParse(match.Value, out number))
                    {
                        matches.Add(number);
                    }
                    else
                    {
                        matches.Add((Array.IndexOf(patterns, match.Value)) + 1);
                    }
            }
            return combineTwoDigits(matches.First(),matches.Last());
        }

       
        private int FindNumbersOnly(string line)
        {
            string pattern = @"1|2|3|4|5|6|7|8|9";
            List<int> matches = new List<int>();

            MatchCollection matchCollection = Regex.Matches(line, pattern);

            foreach (Match match in matchCollection)
            {
                int number;
                if (int.TryParse(match.Value, out number))
                {
                    matches.Add(number);
                }
            }
            return combineTwoDigits(matches.First(), matches.Last());
        }

        private int combineTwoDigits(int firstDigit, int secondDigit)
        {
            return firstDigit * 10 + secondDigit;
        }
    }
}
