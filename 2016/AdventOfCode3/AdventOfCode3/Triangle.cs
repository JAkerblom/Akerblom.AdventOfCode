
namespace AdventOfCode3
{
    public class Triangle
    {
        public int Nr1 { get; internal set; }
        public int Nr2 { get; internal set; }
        public int Nr3 { get; internal set; }
        public bool IsPossible { get; internal set; }

        public Triangle(int nr1, int nr2, int nr3)
        {
            Nr1 = nr1;
            Nr2 = nr2;
            Nr3 = nr3;
            EvalTriangleCharacteristics();
        }

        private void EvalTriangleCharacteristics()
        {
            if (Nr1 + Nr2 > Nr3 &&
                Nr1 + Nr3 > Nr2 &&
                Nr2 + Nr3 > Nr1)
            {
                IsPossible = true;
            }
        }
    }
}