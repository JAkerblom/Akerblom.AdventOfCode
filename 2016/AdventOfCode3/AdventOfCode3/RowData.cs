using FileHelpers;

namespace AdventOfCode3
{
    [FixedLengthRecord()]
    public class RowData
    {
        [FieldFixedLength(5)]
        [FieldTrim(TrimMode.Left)]
        public int nr1;

        [FieldFixedLength(5)]
        [FieldTrim(TrimMode.Left)]
        public int nr2;

        [FieldFixedLength(5)]
        [FieldTrim(TrimMode.Left)]
        public int nr3;
    }
}
