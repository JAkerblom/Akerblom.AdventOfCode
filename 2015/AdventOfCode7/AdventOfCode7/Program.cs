using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCode7
{
    class Program
    {
        static void Main(string[] args)
        {
            DoBitTest();
        }

        static void DoBitTest()
        {
            string filename = "..\\..\\bitwiseInstructions.txt";
            string path = Path.Combine(Directory.GetCurrentDirectory(), filename);
            string[] instructions = File.ReadAllLines(path);

            Dictionary<string, Node> collection = new Dictionary<string, Node>();
            //string instruction;

            foreach (string instruction in instructions)
            {
                instruction.Replace(" ", ",");
                string[] elements = instruction.Split(',');

                //LinkedList<>
                //LinkedListNode<Node> ls = ;

                collection.Add(elements.Last(), new Node());

                Node nodeInPlace;
                if (collection.TryGetValue(elements.Last(), out nodeInPlace))
                {

                }

                // If less than 5 elements, it is a "NOT 'xx' -> 'yy'"
                if (elements.Length < 5)
                {
                    
                }
                else
                {

                }
            }
            int var = 1;
            while (var < 100)
            {
                int x = 123;
                int y = 456;
                int expr = ~x;
                byte[] b = BitConverter.GetBytes(expr);
            }
            //Console.WriteLine(b);
            Console.ReadLine();
        }

        public class Node
        {
            public string Name { get; set; }
            public int BackwardValue { get; set; }
            public Node BackwardNode { get; set; }
            public Node ForwardNode { get; set; }

            public Node()
            {

            }
        }

        public class LinkedNodeBranch
        {
            //public Node head { }
        }
    }
}
