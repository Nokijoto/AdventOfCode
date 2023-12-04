using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Models
{
    public class FileOperations
    {
        public ICollection<string> ReadFileContent(string filePath)
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
    }
}
