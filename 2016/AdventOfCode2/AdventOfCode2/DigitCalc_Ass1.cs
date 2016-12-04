using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2
{
    public class DigitCalc_Ass1
    {
        private string _resultingDigits;
        private Tuple<int, int> _currPos;

        public DigitCalc_Ass1()
        {
            _resultingDigits = "";
            _currPos = new Tuple<int, int>(0, 0);
        }
        public void ExecuteInstructions(List<string> digitInstructions)
        {
            foreach (var row in digitInstructions)
            {
                int i = 0; int len = row.Count();
                foreach (char directionChar in row)
                {
                    i++;
                    SetNewPositionFromADirection(directionChar);
                    if (i == len) SetDigitForRow();
                }
            }
        }

        public string GetResultingDigits { get { return _resultingDigits; } }

        private void SetDigitForRow()
        {
            _resultingDigits += GetDigitFromPosition(_currPos);
        }

        private void SetNewPositionFromADirection(char directionChar)
        {
            Tuple<int, int> newCoord = null;
            switch (directionChar)
            {
                case 'U': // Up
                    newCoord = new Tuple<int, int>(_currPos.Item1, _currPos.Item2 + 1);
                    break;
                case 'R': // Right
                    newCoord = new Tuple<int, int>(_currPos.Item1 + 1, _currPos.Item2);
                    break;
                case 'D': // Down
                    newCoord = new Tuple<int, int>(_currPos.Item1, _currPos.Item2 - 1);
                    break;
                case 'L': // Left
                    newCoord = new Tuple<int, int>(_currPos.Item1 - 1, _currPos.Item2);
                    break;
                default:
                    break;
            }

            if (IsWithinBoundaries(newCoord)) _currPos = newCoord;
        }

        private bool IsWithinBoundaries(Tuple<int, int> newCoord)
        {
            if (newCoord == null) throw new ArgumentNullException("New coordinates from instructions are null. Probably because of a bad character in instruction.");

            int x = newCoord.Item1;
            int y = newCoord.Item2;
            return (x <= 1 && x >= -1) && (y <= 1 && y >= -1);
        }

        public string GetDigitFromPosition(Tuple<int, int> pos) 
        {
            if (pos.Item1 == -1 && pos.Item2 == 1)
                return "1";
            if (pos.Item1 == 0 && pos.Item2 == 1)
                return "2";
            if (pos.Item1 == 1 && pos.Item2 == 1)
                return "3";
            if (pos.Item1 == -1 && pos.Item2 == 0)
                return "4";
            if (pos.Item1 == 0 && pos.Item2 == 0)
                return "5";
            if (pos.Item1 == 1 && pos.Item2 == 0)
                return "6";
            if (pos.Item1 == -1 && pos.Item2 == -1)
                return "7";
            if (pos.Item1 == 0 && pos.Item2 == -1)
                return "8";
            if (pos.Item1 == 1 && pos.Item2 == -1)
                return "9";
            
            return null;
        }
    }
}
