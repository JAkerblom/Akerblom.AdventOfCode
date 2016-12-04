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
    public class When_instruction_calculator_is_set_up // Isbat.. It should be able to..
    {
        private InstructionCalc _mapper;

        [SetUp]
        public void SetUpInput()
        {
            Tuple<int, int> startPos = new Tuple<int, int>(0, 0);
            _mapper = new InstructionCalc(startPos, Direction.North);
        }

        [Test]
        [TestCaseSource("CoordinateCases")]
        public void Isbat_take_a_step(List<string> steps, Tuple<int, int> result)
        {
            _mapper.ExecuteInstructions(steps);
            _mapper.CurrentPosition.Should().Be(result);
        }

        [Test]
        [TestCaseSource("CoordinateCases")]
        public void Isbat_take_multiple_steps(List<string> steps, Tuple<int, int> result)
        {
            _mapper.ExecuteInstructions(steps);
            _mapper.CurrentPosition.Should().Be(result);
        }

        [Test]
        [TestCaseSource("StepCases")]
        public void Isbat_calculate_blocks_away(List<string> steps, int result)
        {
            _mapper.ExecuteInstructions(steps);
            _mapper.GetNrOfBlocksAway().Should().Be(result);
        }

        [Test]
        public void Isbat_find_a_double_visited_location()
        {
            string[] steps = new string[] { "R8", "R4", "R4", "R8" };
            _mapper.ExecuteInstructions(steps.ToList());
            _mapper.HasVisited(new Tuple<int, int>(4, 0)).Should().Be(true);
        }

        [Test]
        public void Isbat_find_first_visited_location()
        {
            string[] steps = new string[] { "R8", "R4", "R4", "R8" };
            Tuple<int, int> res = new Tuple<int, int>(4, 0);
            _mapper.ExecuteInstructions(steps.ToList());
            Tuple<int, int> first = _mapper.FirstVisited();
            first.Item1.Should().Be(res.Item1);
            first.Item2.Should().Be(res.Item2);
        }

        static object[] CoordinateCases =
        {
            new object[] { new List<string> { "R2" }, new Tuple<int, int>(2, 0) },
            new object[] { new List<string> { "L3" }, new Tuple<int, int>(-3, 0) },
            new object[] { new List<string> { "R2", "R1", "L3" }, new Tuple<int, int>(5, -1) },
            new object[] { new List<string> { "L3", "R1", "R3", "R1" }, new Tuple<int, int>(0, 0) }
        };

        static object[] StepCases =
        {
            new object[] { new List<string> { "R2", "R1", "L3" }, 6 },
            new object[] { new List<string> { "L3", "R1", "R2", "L3" }, 5 },
            new object[] { new List<string> { "R3", "L1"}, 4 }
        };
    }
}
