using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode3
{
    public class TriangleCalculator
    {
        private List<Triangle> _measurements;

        public TriangleCalculator()
        {
            _measurements = new List<Triangle>();
        }

        public void ParsePossibleTriangles(RowData[] parsedRows, string assignment)
        {
            if (assignment == "ass1")
            {
                foreach (RowData row in parsedRows)
                {
                    Triangle tr = new Triangle(row.nr1, row.nr2, row.nr3);
                    _measurements.Add(tr);
                }
            }
            else if (assignment == "ass2")
            {
                for (int i = 1; i <= parsedRows.Count(); i++)
                {
                    if (i % 3 == 0)
                    {
                        Triangle tr1 = new Triangle(parsedRows[i - 1].nr1, parsedRows[i - 2].nr1, parsedRows[i - 3].nr1);
                        Triangle tr2 = new Triangle(parsedRows[i - 1].nr2, parsedRows[i - 2].nr2, parsedRows[i - 3].nr2);
                        Triangle tr3 = new Triangle(parsedRows[i - 1].nr3, parsedRows[i - 2].nr3, parsedRows[i - 3].nr3);
                        _measurements.AddRange(new List<Triangle> { tr1, tr2, tr3 });
                    }
                }
            }
        }

        public int GetNumberOfPossibleTriangles()
        {
            return _measurements.Where(t => t.IsPossible).Count();
        }
    }
}
