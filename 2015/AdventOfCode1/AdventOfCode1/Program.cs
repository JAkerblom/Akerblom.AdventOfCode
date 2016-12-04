using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCode1
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadAndCountSteps();
        }
        private static void ReadAndCountSteps()
        {
            String filename = "..\\..\\santasteps.txt";

            var path = Path.Combine(Directory.GetCurrentDirectory(), filename);
            StreamReader reader = new StreamReader(path);

            string line = reader.ReadLine();
            int stepCounter = 0;
            int indexOfBasement = 0;
            bool first = true;

            int i = 0;
            foreach (char ch in line)
            {
                i++;
                if (ch.Equals('('))
                {
                    stepCounter++;
                }
                else if (ch.Equals(')'))
                {
                    stepCounter--;
                }
                if (stepCounter == -1 && first == true)
                {
                    indexOfBasement = i;
                    first = false;
                }
            }
            Console.WriteLine("The level is now: " + stepCounter);
            Console.WriteLine("The position when first hitting basement is: " + indexOfBasement);
            Console.ReadLine();
        }
    }
}
