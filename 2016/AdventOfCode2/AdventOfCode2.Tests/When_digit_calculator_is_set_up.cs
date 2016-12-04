using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2.Tests
{
    class When_digit_calculator_is_set_up
    {
        private List<string> _digitInstructions;
        private DigitCalc_Ass1 _mapper1;
        private DigitCalc_Ass2 _mapper2;

        [SetUp]
        public void SetUp()
        {
            _mapper1 = new DigitCalc_Ass1();
            _mapper2 = new DigitCalc_Ass2();
            _digitInstructions = new List<string>();
        }

        [Test]
        [TestCaseSource("DigitCoordinateCases1")]
        public void Isbat_return_correct_digit_from_coordinate(Tuple<int, int> input, string result)
        {
            _mapper1.GetDigitFromPosition(input).Should().Be(result);
        }

        [Test]
        [TestCase("ULL", "1")]
        public void Isbat_find_resulting_digit_from_one_row_of_instructions(string input, string result)
        {
            _digitInstructions.Add(input);
            _mapper1.ExecuteInstructions(_digitInstructions);
            _mapper1.GetResultingDigits.Should().Be(result);
        }

        [Test]
        [TestCaseSource("CaseFromWebsite1")]
        public void Isbat_find_resulting_digits_from_multiple_rows_of_instructions_ass1(List<string> instructions, string result)
        {
            _mapper1.ExecuteInstructions(instructions);
            _mapper1.GetResultingDigits.Should().Be(result);
        }

        //[Test]
        //[TestCaseSource("CaseFromWebsite2")]
        //public void Isbat_find_resulting_digits_from_multiple_rows_of_instructions_ass2(List<string> instructions, string result)
        //{
        //    _mapper2.ExecuteInstructions(instructions);
        //    _mapper2.GetResultingDigits.Should().Be(result);
        //}

        static object[] CaseFromWebsite1 =
        {
            new object[] { new List<string> { "ULL", "RRDDD", "LURDL", "UUUUD" }, "1985" },
        };

        static object[] DigitCoordinateCases1 =
        {
            new object[] { new Tuple<int, int>(0, 0), "5" },
            new object[] { new Tuple<int, int>(1, 0), "6" },
            new object[] { new Tuple<int, int>(-1, -1), "7" },
            new object[] { new Tuple<int, int>(0, 1), "2" }
        };
    }
}
