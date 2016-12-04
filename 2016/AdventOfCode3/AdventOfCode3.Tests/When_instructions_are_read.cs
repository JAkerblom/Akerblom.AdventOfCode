using FileHelpers;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode3.Tests
{
    [TestFixture]
    public class When_instructions_are_read // Isbat_ .. It should be able to..
    {
        private RowData[] _parsedRows;
        private TriangleCalculator _engine;

        [SetUp]
        public void SetUp()
        {
            _engine = new TriangleCalculator();
            string stringRepo = Properties.Resources.input;
            var rowReader = new FileHelperEngine<RowData>();
            _parsedRows = rowReader.ReadString(stringRepo);
        }

        [Test]
        [TestCase("ass1", 1050)]
        [TestCase("ass2", 1921)]
        public void Isbat_get_nr_of_possible_triangles(string assignment, int result)
        {
            _engine.ParsePossibleTriangles(_parsedRows, assignment);
            _engine.GetNumberOfPossibleTriangles().Should().Be(result);
        }
    }
}
