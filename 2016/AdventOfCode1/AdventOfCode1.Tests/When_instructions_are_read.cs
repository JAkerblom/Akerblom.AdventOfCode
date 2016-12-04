using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FluentAssertions;

namespace AdventOfCode1.Tests
{
    [TestFixture]
    public class When_instructions_are_read // Isbat.. It should be able to..
    {
        private List<string> _directions;
        private InstructionCalc _mapper;

        [SetUp]
        public void SetUpInput()
        {
            Tuple<int, int> startPos = new Tuple<int, int>(0, 0);
            _mapper = new InstructionCalc(startPos, Direction.North);

            string stringRepo = Properties.Resources.input;
            string line;
            StringReader sr = new StringReader(stringRepo);
            line = sr.ReadLine();
            _directions = line.Split(',')
                .Select(x => x.Trim())
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToList();
        }

        [Test]
        public void Isbat_read_all_directions()
        {
            _directions.Count().Should().Be(147);
        }

        [Test]
        [TestCase(231)]
        public void Isbat_calculate_blocks_away_to_end_of_instructions(int result)
        {
            _mapper.ExecuteInstructions(_directions);
            _mapper.GetNrOfBlocksAway().Should().Be(result);
        }

        [Test]
        [TestCase(-10, -137)]
        public void Isbat_find_first_double_visited_location(int x, int y)
        {
            _mapper.ExecuteInstructions(_directions);
            Tuple<int, int> first = _mapper.FirstVisited();
            first.Item1.Should().Be(x);
            first.Item2.Should().Be(y);
        }

        [Test]
        [TestCase(147)]
        public void Isbat_calculate_blocks_away_to_first_double_visited_location(int result)
        {
            _mapper.ExecuteInstructions(_directions);
            _mapper.GetNrOfBlocksAwayToLocation(_mapper.FirstVisited()).Should().Be(result);
        }
    }
}
