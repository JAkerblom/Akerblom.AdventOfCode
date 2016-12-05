using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode4.Tests
{
    public class RoomCalc
    {
        private string _pattern;
        private List<Room> _rooms;

        public RoomCalc(string pattern)
        {
            _pattern = pattern;
            _rooms = new List<Room>();
        }

        public void ExecuteRoomNameParser(List<string> _roomCodes)
        {
            foreach (var str in _roomCodes)
            {
                Match m = Regex.Match(str, _pattern);
                if (m.Success)
                {
                    var elementGroup = m.Groups.Cast<Group>().ToList();
                    _rooms.Add(new Room(
                        elementGroup[1].Value,
                        elementGroup[2].Value,
                        elementGroup[3].Value
                        ));
                }
            }
        }

        public int GetNumberOfRealRooms()
        {
            return _rooms.Where(x => x.IsReal).Count();
        }
    }
}
