using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2.Tests
{
    [TestFixture]
    public class When_instructions_are_read // Isbat_ .. It should be able to..
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
            string stringRepo = Properties.Resources.input;
            string line;
            using (StringReader sr = new StringReader(stringRepo))
                while ((line = sr.ReadLine()) != null)
                    _digitInstructions.Add(line);
        }

        [Test]
        [TestCase(5)]
        public void Isbat_read_all_directions(int result)
        {
            _digitInstructions.Count.Should().Be(result);
        }

        [Test]
        [TestCase("45973")]
        public void Isbat_find_resulting_digits_ass1(string result)
        {
            _mapper1.ExecuteInstructions(_digitInstructions);
            _mapper1.GetResultingDigits.Should().Be(result);
        }

        [Test]
        [TestCase("27CA4")]
        public void Isbat_find_resulting_digits_ass2(string result)
        {
            _mapper2.ExecuteInstructions(_digitInstructions);
            _mapper2.GetResultingDigits.Should().Be(result);
        }
    }
}
