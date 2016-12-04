using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCode3
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadAndCalculateDeliveries();
        }

        static void ReadAndCalculateDeliveries()
        {
            String filename = "..\\..\\santaDeliveries.txt";
            String path = Path.Combine(Directory.GetCurrentDirectory(), filename);
            string[] readLine = File.ReadAllLines(path);

            // For just santa
            HashSet<Point> visited = new HashSet<Point>(new PointEqualityComparer<Point>());
            Point lastPoint = new Point(0, 0);
            visited.Add(lastPoint);

            // For santa and robot
            HashSet<Point> visitedBoth = new HashSet<Point>(new PointEqualityComparer<Point>());
            Point lastPointSanta = new Point(0, 0);
            Point lastPointRobot = new Point(0, 0);
            Point lastPointBoth = new Point(0, 0);
            visitedBoth.Add(lastPointSanta); // Only need to add one.

            string line = readLine[0];
            int i = 0;
            bool isSanta;
            foreach (char ch in line)
            {
                i++;
                isSanta = (i % 2 == 1) ? true : false;
                switch (ch)
                {
                    case '^':
                        lastPoint.Y = lastPoint.Y + 1;
                        if (isSanta)
                            lastPointSanta.Y = lastPointSanta.Y + 1;
                        else
                            lastPointRobot.Y = lastPointRobot.Y + 1;
                        break;
                    case '>':
                        lastPoint.X = lastPoint.X + 1;
                        if (isSanta)
                            lastPointSanta.X = lastPointSanta.X + 1;
                        else
                            lastPointRobot.X = lastPointRobot.X + 1;
                        break;
                    case 'v':
                        lastPoint.Y = lastPoint.Y - 1;
                        if (isSanta)
                            lastPointSanta.Y = lastPointSanta.Y - 1;
                        else
                            lastPointRobot.Y = lastPointRobot.Y - 1;
                        break;
                    case '<':
                        lastPoint.X = lastPoint.X - 1;
                        if (isSanta)
                            lastPointSanta.X = lastPointSanta.X - 1;
                        else
                            lastPointRobot.X = lastPointRobot.X - 1;
                        break;
                    default:
                        Console.WriteLine("An unexpected sign was cross upon.");
                        break;
                }

                lastPointBoth = (isSanta) ? lastPointSanta : lastPointRobot;
                visited.Add(lastPoint);
                visitedBoth.Add(lastPointBoth);
            }

            int nrVisited = visited.Count();
            int nrVisitedBoth = visitedBoth.Count();
            Console.WriteLine("Number of visited locations are: " + nrVisited);
            Console.WriteLine("Number of visited for both are: " + nrVisitedBoth);
            Console.ReadLine();
        }

        private class PointEqualityComparer<T> : IEqualityComparer<Point>
        {
            public bool Equals(Point a, Point b)
            {
                if (a.X == b.X && a.Y == b.Y)
                    return true;
                else
                    return false;
            }

            public int GetHashCode(Point p)
            {
                int hash = 269;
                hash = (hash * 47) + p.X.GetHashCode();
                hash = (hash * 47) + p.Y.GetHashCode();
                return hash;
            }
        }

        public struct Point
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        };
    }
}
