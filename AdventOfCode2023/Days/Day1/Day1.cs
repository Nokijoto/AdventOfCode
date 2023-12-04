
using AdventOfCode2023.Models;
using AdventOfCode2023.Models.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode2023.Days.Day1
{
    public class Day1
    {
        public string FilePath { get; set; }
       
        // RIGHT  ANSWER : 54605
        public void Answer(string FilePath)
        {
            FileOperations FileOperations = new FileOperations();
            LinesCheckerModule LinesCheckerModule = new LinesCheckerModule();
            ICollection<string> Lines = FileOperations.ReadFileContent(FilePath);
            
            ICollection<int> NumbersToSum = new List<int>();
            int Sumator=0;
            foreach (var Line in Lines)
            {
                int FoundNumber = LinesCheckerModule.FindNumberFromLine(Line, (int)Flags.includeDigits);
                
                NumbersToSum.Add(FoundNumber);
                Sumator += FoundNumber;
             
            }
            
           // PrintNumbersInRows(NumbersToSum.ToList(), 20);
            Console.WriteLine($"DAY 1  ANSWER: {NumbersToSum.Sum()}");
        }

        static void PrintNumbersInRows(List<int> numbers, int numbersPerRow)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.Write($"{i + 1,2}:  "); 
                Console.Write("{ " +numbers[i] + " }");

                if ((i + 1) % numbersPerRow == 0)
                {
                    Console.WriteLine(); 
                }
            }
        }

        public void AnswerWithRegex(string FilePath)
        {
            Console.Clear();

            FileOperations FileOperations = new FileOperations();
            ICollection<string> Lines = FileOperations.ReadFileContent(FilePath);
            RegexCheckerModule RegexCheckerModule = new RegexCheckerModule();
            ICollection<int> NumbersToSum = new List<int>();
            int Sumator = 0;
            foreach (var Line in Lines)
            {
                int FoundNumber = RegexCheckerModule.FindNumberFromLine(Line, (int)Flags.includeLetters);
                
                NumbersToSum.Add(FoundNumber);
                Sumator += FoundNumber;
              
            }
           // PrintNumbersInRows(NumbersToSum.ToList(), 20);
            Console.WriteLine($"DAY 1 ANSWER WITH REGEX: {NumbersToSum.Sum()}");
            Console.WriteLine("=====================================");
        }

    }
}
