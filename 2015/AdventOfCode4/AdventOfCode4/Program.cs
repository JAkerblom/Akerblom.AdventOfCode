using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace AdventOfCode4
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "iwrupvqb";
            FindLowestHash(input);
        }

        static void FindLowestHash(string str)
        {
            string input;
            string hexString;
            int index = 0;

            using (MD5 hasher = MD5.Create())
            {
                do
                {
                    index++;
                    input = string.Concat(str, index.ToString());
                    byte[] data = hasher.ComputeHash(Encoding.UTF8.GetBytes(input));
                    StringBuilder sb = new StringBuilder();

                    for (int i = 0; i < data.Length; i++)
                    {
                        var hex = data[i].ToString("x2");
                        sb.Append(hex);
                    }
                    hexString = sb.ToString();
                    //} while (hexString.Substring(0, 5) != "00000");
                } while (hexString.Substring(0, 6) != "000000");
            }
            Console.WriteLine("The lowest number is: " + index);
            Console.ReadLine();
        }
    }
}
