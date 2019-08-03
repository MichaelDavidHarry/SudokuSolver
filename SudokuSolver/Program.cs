using System;
using System.Linq;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = SudokuReader.ReadSudokuPuzzle("easy.txt");
            var helper = new SudokuHelper(grid);

            while (!grid.IsSolved)
            {
                var lastUnsolvedSquares = grid.UnsolvedSquares;
                for (int row = 0; row < 9; row++)
                {
                    for (int column = 0; column < 9; column++)
                    {
                        if (grid[row, column].Status == SudokuSquare.SquareStatus.Unsolved)
                        {
                            var values = helper.GetPossibleSquareValues(row, column);
                            if (values.Count() == 1)
                            {
                                grid[row, column].Value = values.Single();
                                grid[row, column].Status = SudokuSquare.SquareStatus.Solved;
                            }
                        }
                    }
                }
                Console.WriteLine($"Unsolved squares: {grid.UnsolvedSquares}");
                if(grid.UnsolvedSquares == lastUnsolvedSquares)
                {
                    Console.WriteLine("Solver is stuck! Stopping...");
                    return;
                }
            }

            Console.WriteLine(grid);
        }
    }
}
