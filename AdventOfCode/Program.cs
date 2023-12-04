// See https://aka.ms/new-console-template for more information
using AdventOfCode2023.Days.Day1;
using AdventOfCode2023.Days.Day2;
using System;
using System.IO;

Console.WriteLine("Advent of Code 2023");

Console.WriteLine("Day 1");
Day1 Day1 = new Day1();
Day1.FilePath = "C:\\Users\\Rexma\\Desktop\\AdventOfCode\\AdventOfCode\\AdventOfCode2023\\Data\\Day1\\input.txt";
//Day1.Answer(Day1.FilePath);
Console.WriteLine("Day 1 with Regex");
Day1.AnswerWithRegex(Day1.FilePath);
Console.WriteLine("=====================================");

//Console.WriteLine("Day 2");
//Day2 Day2 = new Day2();
//Day2.FilePath = "C:\\Users\\Rexma\\Desktop\\AdventOfCode\\AdventOfCode\\AdventOfCode2023\\Data\\Day2\\inputmini.txt";
//Day2.Answer(Day2.FilePath);