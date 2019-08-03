using System;
using System.Collections.Generic;

namespace SudokuSolver
{
    public class SudokuSquare
    {
        public SquareStatus Status { get; set; }
        private int? _value;
        public int? Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (value.HasValue && (value < 1 || value > 9))
                {
                    throw new ArgumentOutOfRangeException("value must be between 1 and 9, inclusive, or null.");
                }
                _value = value;
            }
        }

        public IList<int> PossibleValues { get; } = new List<int>();

        public enum SquareStatus
        {
            Unsolved,
            Solved,
            Given
        }

        public override string ToString()
        {
            //return $"[{Status.ToString()[0]}{Value.ToString().PadRight(1)}]";
            return $"[{Value.ToString().PadRight(1)}]";
        }
    }
}
