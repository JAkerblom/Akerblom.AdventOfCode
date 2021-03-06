﻿using System;
using System.Collections.Generic;

namespace AdventOfCode1
{
    public class InstructionCalc
    {
        private Direction _direction { get; set; }      // Keeps track of the current direction to walk in 
        private Tuple<int, int> _startPos;              
        private Tuple<int, int> _position;              // Keeps track of the current position
        private HashSet<Tuple<int, int>> _visiteds;     // Keeps track of the visited positions
        private Queue<Tuple<int, int>> _doubleVisiteds; // Keeps track of the double visited positions

        public InstructionCalc(Tuple<int, int> startPos, Direction startDir)
        {
            _startPos = startPos;
            _position = _startPos;
            _direction = startDir;
            _visiteds = new HashSet<Tuple<int, int>>();
            _doubleVisiteds = new Queue<Tuple<int, int>>();
            _visiteds.Add(_startPos);
        }

        /// <summary>
        ///     For each instruction of a list of instructions (from input.txt file)
        ///         Get the direction instruction and the number of block steps.
        ///         Set the new direction before walking and then walk and register that new position.
        ///         While you're at it, go and store all the coordinates you just walked past, as well
        ///         as the coordinates that you may have passed already (Assignment 2). 
        /// </summary>
        /// <param name="instructions">Insert a set of instructions as "direction" and "number of block steps".</param>
        public void ExecuteInstructions(List<string> instructions)
        {
            foreach (var instr in instructions)
            {
                Tuple<int, int> tmpPos = _position;
                char changeOfDirection = instr[0];
                string ints = instr.Substring(1);
                int nrOfBlocks = Int32.Parse(ints);

                SetNewDirection(changeOfDirection);
                SetNewPosition(nrOfBlocks);
                StoreVisitedCoordinates(tmpPos, _position, _direction);
            }
        }

        private void StoreVisitedCoordinates(Tuple<int, int> from, Tuple<int, int> to, Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    for (int i = from.Item2+1; i <= to.Item2; i++)
                    {
                        if (_visiteds.Contains(new Tuple<int, int>(from.Item1, i)))
                        {
                            _doubleVisiteds.Enqueue(new Tuple<int, int>(from.Item1, i));
                        }
                        else
                        {
                            _visiteds.Add(new Tuple<int, int>(from.Item1, i));
                        }
                    }
                    break;
                case Direction.East:
                    for (int i = from.Item1+1; i <= to.Item1; i++)
                    {
                        if (_visiteds.Contains(new Tuple<int, int>(i, from.Item2)))
                        {
                            _doubleVisiteds.Enqueue(new Tuple<int, int>(i, from.Item2));
                        }
                        else 
                        {
                            _visiteds.Add(new Tuple<int, int>(i, from.Item2));
                        }
                    }
                    break;
                case Direction.South:
                    for (int i = to.Item2; i < from.Item2; i++)
                    {
                        if (_visiteds.Contains(new Tuple<int, int>(from.Item1, i)))
                        {
                            _doubleVisiteds.Enqueue(new Tuple<int, int>(from.Item1, i));
                        }
                        else
                        {
                            _visiteds.Add(new Tuple<int, int>(from.Item1, i));
                        }
                    }
                    break;
                case Direction.West:
                    for (int i = to.Item1; i < from.Item1; i++)
                    {
                        if (_visiteds.Contains(new Tuple<int, int>(i, from.Item2)))
                        {
                            _doubleVisiteds.Enqueue(new Tuple<int, int>(i, from.Item2));
                        }
                        else
                        {
                            _visiteds.Add(new Tuple<int, int>(i, from.Item2));
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        public Tuple<int, int> FirstVisited()
        {
            if (_doubleVisiteds.Count > 0)
            {
                return _doubleVisiteds.Dequeue();
            }
            return null;
        }

        public int GetNrOfBlocksAway()
        {
            return Math.Abs(_position.Item1) + Math.Abs(_position.Item2);
        }

        public int GetNrOfBlocksAwayToLocation(Tuple<int, int> location)
        {
            int x1 = _startPos.Item1; int x2 = location.Item1;
            int y1 = _startPos.Item2; int y2 = location.Item2;
            
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }

        private void SetNewPosition(int nrOfBlocks)
        {
            switch (_direction)
            {
                case Direction.North:
                    _position = new Tuple<int, int> (_position.Item1, _position.Item2 + nrOfBlocks); 
                    break;
                case Direction.East:
                    _position = new Tuple<int, int>(_position.Item1 + nrOfBlocks, _position.Item2);
                    break;
                case Direction.South:
                    _position = new Tuple<int, int>(_position.Item1, _position.Item2 - nrOfBlocks);
                    break;
                case Direction.West:
                    _position = new Tuple<int, int>(_position.Item1 - nrOfBlocks, _position.Item2);
                    break;
                default:
                    break;
            }
        }

        public bool HasVisited(Tuple<int, int> coord)
        {
            foreach (var coordinate in _visiteds)
            {
                if (coordinate.Item1 == coord.Item1 &&
                    coordinate.Item2 == coord.Item2)
                {
                    return true;
                }
            }

            return false;
        }

        private void SetNewDirection(char changeOfDirection)
        {
            switch (changeOfDirection)
            {
                case 'R':
                    _direction += 1;
                    break;
                case 'L':
                    _direction -= 1;
                    break;
                default:
                    break;
            }

            // Ensuring a loop around the compass..
            if (_direction < 0) _direction = Direction.West;
            if (_direction > Direction.West) _direction = Direction.North;
            
        }

        public Tuple<int, int> CurrentPosition { get { return _position; } }
        public Direction CurrentDirection { get { return _direction; } }
    }

    /// <summary>
    ///     Using an enumeration for the possible directions.
    ///     Will get values like North = 0, East = 1, and so on.
    /// </summary>
    public enum Direction { North, East, South, West }
}