using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCode2
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadAndCalculateArea();
        }

        private static void ReadAndCalculateArea()
        {
            String filename = "..\\..\\presentVolumes.txt";
            String path = Path.Combine(Directory.GetCurrentDirectory(), filename);
            string[] readText = File.ReadAllLines(path);

            string[] measurements;
            int x, y, z;
            int[] dims = new int[3];

            long totalArea = 0;
            int area;

            long totalRibbon = 0;
            int ribbon;

            foreach (string line in readText)
            {
                measurements = line.Split('x');
                x = Int32.Parse(measurements[0]);
                y = Int32.Parse(measurements[1]);
                z = Int32.Parse(measurements[2]);
                dims = new[] { x, y, z };
                Array.Sort(dims);
                //for (int i = 0; i < 3; i++)
                //{
                //    dims[i] = int.Parse(measurements[i]);
                //}
                area = CalculatePaper(dims);
                ribbon = CalculateRibbon(dims);
                dims = null;
                totalArea = totalArea + area;
                totalRibbon = totalRibbon + ribbon;
            }
            Console.WriteLine("The total area is: " + totalArea);
            Console.WriteLine("The total ribbon is: " + totalRibbon);
            Console.ReadLine();
        }

        private static int CalculatePaper(int[] arr)
        {
            //Array.Sort(arr);
            int surface = 2 * arr[0] * arr[1] + 2 * arr[1] * arr[2] + 2 * arr[0] * arr[2];
            int rest = arr[0] * arr[1];
            return surface + rest;    
        }

        private static int CalculateRibbon(int[] arr)
        {
            int around = 2 * arr[0] + 2 * arr[1];
            int bow = arr[0] * arr[1] * arr[2];
            return around + bow; 
        }
    }
}
