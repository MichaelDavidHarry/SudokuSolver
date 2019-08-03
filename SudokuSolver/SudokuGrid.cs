using System;
using System.Text;

namespace SudokuSolver
{
    public class SudokuGrid
    {
        public SudokuGrid()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    squares[i, j] = new SudokuSquare();
                }
            }
        }

        public SudokuGrid(int?[,] givenNumbers)
        {
            if (givenNumbers.GetLength(0) != 9 || givenNumbers.GetLength(1) != 9)
            {
                throw new ArgumentOutOfRangeException("givenNumbers must have 9 rows and 9 columns.");
            }
            for (int row = 0; row < 9; row++)
            {
                for (int column = 0; column < 9; column++)
                {
                    squares[row, column] = new SudokuSquare() { Status = givenNumbers[row, column].HasValue ? SudokuSquare.SquareStatus.Given : SudokuSquare.SquareStatus.Unsolved, Value = givenNumbers[row, column] };
                }
            }
        }

        public SudokuSquare this[int row, int column]
        {
            get
            {
                return squares[row, column];
            }
        }

        public bool IsSolved
        {
            get
            {
                for (int row = 0; row < 9; row++)
                {
                    for (int column = 0; column < 9; column++)
                    {
                        if (squares[row, column].Status == SudokuSquare.SquareStatus.Unsolved)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }

        public int UnsolvedSquares
        {
            get
            {
                var unsolvedSquares = 0;
                for (int row = 0; row < 9; row++)
                {
                    for (int column = 0; column < 9; column++)
                    {
                        if (squares[row, column].Status == SudokuSquare.SquareStatus.Unsolved)
                        {
                            unsolvedSquares++;
                        }
                    }
                }
                return unsolvedSquares;
            }
        }

        private SudokuSquare[,] squares { get; } = new SudokuSquare[9, 9];

        public override string ToString()
        {
            var builder = new StringBuilder();
            for (int row = 0; row < 9; row++)
            {
                for (int column = 0; column < 9; column++)
                {
                    builder.Append(squares[row, column]);
                }
                builder.AppendLine();
            }
            return builder.ToString();
        }
    }
}
