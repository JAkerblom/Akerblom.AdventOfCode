using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode4
{
    public class Room
    {
        public string[] NameGroup { get; internal set; }
        public int Digit { get; internal set; }
        public string Check { get; internal set; }
        public bool IsReal { get; internal set; }
        public string DecryptedName { get; internal set; }

        public Room(string name, string digit, string check)
        {
            NameGroup = name.Split('-').Where(x => x != "").ToArray();
            Digit = Int32.Parse(digit);
            Check = check;
            EvalRoom();
        }

        private void EvalRoom()
        {
            if (GetTopXChars(5) == Check) IsReal = true;

            int shift = Digit % 26;
            char[] charArr = ConcatenatedCharsOfNames();
            
        }

        private string GetTopXChars(int x)
        {
            return string.Concat(GetFrequencySortedCharList().Take(x));
        }

        private List<char> GetFrequencySortedCharList()
        {
            List<char> sortedList = ConcatenatedCharsOfNames()
                .GroupBy(g => g)
                .OrderByDescending(x => x.Count())
                .ThenBy(x => x.Key)
                .Select(x => x.Key)
                .ToList();
            return sortedList;
        }

        private char[] ConcatenatedCharsOfNames()
        {
            string concName = "";
            foreach (var n in NameGroup) concName += n;

            char[] charArr = concName.ToCharArray();
            return charArr;
        }
    }
}
