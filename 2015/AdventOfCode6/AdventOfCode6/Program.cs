using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode6
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadAndCalculateNumberOfTurnedOnLights();
        }

        static void ReadAndCalculateNumberOfTurnedOnLights()
        {
            String filename = "..\\..\\decorationActions.txt";
            String path = Path.Combine(Directory.GetCurrentDirectory(), filename);
            string[] lines = File.ReadAllLines(path);

            bool[,] lightsOne = new bool[1000,1000];
            int[,] lightsTwo = new int[1000,1000];
            for (int i = 0; i < 999; i++)
                for (int j = 0; j < 999; j++)
                    lightsTwo[i, j] = 0;
            
            string[] patterns = new string[3]; // Container for the 3 different patterns.

            patterns[0] = @"toggle"; // Matching if action is "toggle"
            patterns[1] = @"on"; // Matching if action is "turn on"
            patterns[2] = @"off"; // Matching if action is "turn off"

            int actionNumber = -1;
            string coordinateStr = "";
            string[] coordinates = new string[4];
            int numberOfTurnedOnLights = 0;
            int totalLightStrength = 0;

            foreach (string line in lines)
            {
                // Decide the action
                bool[] actionBools = new bool[3] {
                    Regex.Match(line, patterns[0]).Success,
                    Regex.Match(line, patterns[1]).Success,
                    Regex.Match(line, patterns[2]).Success};
                for (int i = 0; i < 3; i++) if (actionBools[i]) actionNumber = i;

                // Remove "through" and replace with a comma
                coordinateStr = line.Replace(" through ", ",");

                //  Switch case on action
                switch (actionNumber)
                {
                    case 0: // Toggle
                        // Remove action
                        coordinateStr = coordinateStr.Remove(0, 7);
                        // Split on comma for what is left of string. Will give 4 numbers
                        coordinates = coordinateStr.Split(',');
                        // Nestled loop through lights defined by limits of the 4 numbers
                        for (int i = Int32.Parse(coordinates[0]); i <= Int32.Parse(coordinates[2]); i++)
                            for (int j = Int32.Parse(coordinates[1]); j <= Int32.Parse(coordinates[3]); j++)
                            {
                                lightsOne[i, j] = !lightsOne[i, j];
                                lightsTwo[i, j] = lightsTwo[i, j] + 2;
                                //if (lightsTwo[i, j] > 10) lightsTwo[i, j] = 10;
                            }
                        break;
                    case 1: // On
                        // Remove action
                        coordinateStr = coordinateStr.Remove(0, 8);
                        // Split on comma for what is left of string. Will give 4 numbers
                        coordinates = coordinateStr.Split(',');
                        // Nestled loop through lights defined by limits of the 4 numbers
                        for (int i = Int32.Parse(coordinates[0]); i <= Int32.Parse(coordinates[2]); i++)
                            for (int j = Int32.Parse(coordinates[1]); j <= Int32.Parse(coordinates[3]); j++)
                            {
                                lightsOne[i, j] = true;
                                lightsTwo[i, j] = lightsTwo[i, j] + 1;
                                //if (lightsTwo[i, j] > 10) lightsTwo[i, j] = 10;
                            }   
                                break;
                    case 2: // Off
                        // Remove action
                        coordinateStr = coordinateStr.Remove(0, 9);
                        // Split on comma for what is left of string. Will give 4 numbers
                        coordinates = coordinateStr.Split(',');
                        // Nestled loop through lights defined by limits of the 4 numbers
                        for (int i = Int32.Parse(coordinates[0]); i <= Int32.Parse(coordinates[2]); i++)
                            for (int j = Int32.Parse(coordinates[1]); j <= Int32.Parse(coordinates[3]); j++)
                            {
                                lightsOne[i, j] = false;
                                lightsTwo[i, j] = lightsTwo[i, j] - 1;
                                if (lightsTwo[i, j] < 0) lightsTwo[i, j] = 0;

                            }
                        break;
                }
            }
            for (int i = 0; i < 999; i++)
                for (int j = 0; j < 999; j++)
                {
                    if (lightsOne[i, j]) numberOfTurnedOnLights++;
                    totalLightStrength += lightsTwo[i, j];
                }
            Console.WriteLine(numberOfTurnedOnLights);
            Console.WriteLine(totalLightStrength);
            Console.ReadLine();
        }
    }
}
