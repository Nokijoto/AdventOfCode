
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
            ICollection<string> Lines = ReadFileContent(FilePath);

            ICollection<int> NumbersToSum = new List<int>();
            foreach (var Line in Lines)
            {
                
                NumbersToSum.Add(FindNumber(Line));
            }
            Console.WriteLine($"ANSWER: {NumbersToSum.Sum()}");
        }

        public ICollection<string>  ReadFileContent(string filePath)
        {
            // Check if the file exists
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The specified file does not exist.", filePath);
            }

            // Read the content of the file and store it in a list of chars
            List<int> NumbersToSum = new List<int>();
            ICollection<string> lines = new List<string>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
               do
               {
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        lines.Add(line);
                    }
                } while (line != null);
            }
            return lines;
        }



       public int FindNumber(string Line)
       {
          
            ICollection<int> array = new List<int>();
            foreach (char c in Line)
            {
                if (checkIfCharBetweenRange(c))
                {
                   
                    array.Add(convertToInt(c));
                }

            }
            return DigitsToDubleDigitNumber(array);
        }

        private int convertToInt(int SingleCharacter)
        {
            return SingleCharacter - 48;
        }
        private bool checkIfCharBetweenRange(char ToCheck)
        {
            int MinimalRange = 48;
            int MaximalRange = 57;
            if (ToCheck >= MinimalRange && ToCheck <= MaximalRange)
            {
                return true;
            }
            return false;
        }
        

        private int  DigitsToDubleDigitNumber(ICollection<int> array)
        {
            int DoubleDigitNumber;
            if (array.Count==1)
            {
                DoubleDigitNumber = (MergeTwoDigits(array.ElementAt(0), array.ElementAt(0)));
            }
            else
            {
                DoubleDigitNumber=(MergeTwoDigits(array.ElementAt(0), array.ElementAt(array.Count-1)));
            }
            return DoubleDigitNumber;
        }

        private int MergeTwoDigits(int x, int y)
        {
            return x * 10 + y;
        }


    }
}
