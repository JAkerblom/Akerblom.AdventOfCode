using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode5
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadAndCountNiceStrings();
        }

        private static void ReadAndCountNiceStrings()
        {
            String filename = "..\\..\\niceAndNaughtyStrings.txt";
            String path = Path.Combine(Directory.GetCurrentDirectory(), filename);
            string[] lines = File.ReadAllLines(path);

            string[] patterns = new string[6]; // Container for the 3 different patterns.

            // Task one
            patterns[0] = @"(.*[aeiou].*){3,}"; // Make sure at least 3 vowels
            patterns[1] = @"(\w)\1+"; // Make sure at least one double occurring letter 
            patterns[2] = @"(ab|cd|pq|xy)+"; // Make sure not finding any of the strings 'ab', 'cd', 'pq', 'xy'

            // Task two
            patterns[3] = @"(\w{2}).*\1"; // Make sure a double occurring pair of letters
            patterns[4] = @"(\w{1})(\w{1})\1"; // Make sure a same letter pair with a letter bettween them

            bool rulesApply = false;
            int numberOfNiceStringsOne = 0; // Counter for task one
            int numberOfNiceStringsTwo = 0; // Counter for task two
            foreach (string str in lines)
            {
                // Task one
                Match m = Regex.Match(str, patterns[0]);
                Match n = Regex.Match(str, patterns[1]);
                Match o = Regex.Match(str, patterns[2]);
                rulesApply = m.Success && n.Success && !o.Success;
                if (rulesApply && !o.Success) numberOfNiceStringsOne++;

                Match p = Regex.Match(str, patterns[3]);
                Match q = Regex.Match(str, patterns[4]);
                rulesApply = p.Success && q.Success;
                if (rulesApply && p.Success) numberOfNiceStringsTwo++;
            }
            Console.WriteLine(numberOfNiceStringsOne);
            Console.WriteLine(numberOfNiceStringsTwo);
            Console.ReadLine();
        }
    }
}
