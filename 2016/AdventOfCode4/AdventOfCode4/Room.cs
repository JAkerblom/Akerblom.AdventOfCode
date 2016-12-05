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
        public string Digit { get; internal set; }
        public string Check { get; internal set; }
        public bool IsReal { get; internal set; }

        public Room(string name, string digit, string check)
        {
            NameGroup = name.Split('-').Where(x => x != "").ToArray();
            Digit = digit;
            Check = check;
            EvalRoom();
        }

        private void EvalRoom()
        {
            if (GetTopXChars(5) == Check) IsReal = true;
        }

        private string GetTopXChars(int x)
        {
            return string.Concat(GetFrequencySortedCharList().Take(x));
        }

        private List<char> GetFrequencySortedCharList()
        {
            string concName = "";
            foreach (var n in NameGroup) concName += n;

            List<char> sortedList = concName.ToCharArray()
                .GroupBy(g => g)
                .OrderByDescending(x => x.Count())
                .ThenBy(x => x.Key)
                .Select(x => x.Key)
                .ToList();
            return sortedList;
        }
    }
}
