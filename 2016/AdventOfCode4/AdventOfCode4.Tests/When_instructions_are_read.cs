using FileHelpers;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode4.Tests
{
    [TestFixture]
    public class When_instructions_are_read // Isbat_ .. It should be able to..
    {
        private List<string> _roomCodes;
        private RoomCalc _engine;

        [SetUp]
        public void SetUp()
        {
            //string pattern = @"([a-z\-]+)(\d+)\[([a-z]+)\]";
            string pattern = @"([a-z-]+)(\d+)\[(.+)\]";
            String stringRepo = Properties.Resources.input;
            _roomCodes = new List<string>();
            _engine = new RoomCalc(pattern);
            string line;
            using (StringReader sr = new StringReader(stringRepo))
                while ((line = sr.ReadLine()) != null)
                    _roomCodes.Add(line);
        }

        [Test]
        [TestCaseSource("RoomNames_Ass1")]
        public void Isbat_evaluate_a_room_name(string roomName, bool result)
        {
            _engine.ExecuteRoomNameParser(new List<string> { roomName });
            _engine.GetNumberOfRealRooms().Should().Be(result ? 1 : 0);
        }

        [Test]
        [TestCase(245102)]
        public void Isbat_evaluate_multiple_room_names(int result)
        {
            _engine.ExecuteRoomNameParser(_roomCodes);
            _engine.GetSumOfRealRooms().Should().Be(result);
        }

        [Test]
        [TestCase("pole", 324)]
        public void Isbat_find_index_of_matching_string(string match, int result)
        {
            _engine.ExecuteRoomNameParser(_roomCodes);
            _engine.GetIndexOfMatchingString(match).Should().Be(result);
        }

        static object[] RoomNames_Ass1 =
        {
            new object[] { "aaaaa-bbb-z-y-x-123[abxyz]", true },
            new object[] { "a-b-c-d-e-f-g-h-987[abcde]", true },
            new object[] { "not-a-real-room-404[oarel]", true },
            new object[] { "totally-real-room-200[decoy]", false },
        };
    }
}
