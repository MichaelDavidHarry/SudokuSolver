using System.IO;

namespace SudokuSolver
{
    public static class SudokuReader
    {
        public static SudokuGrid ReadSudokuPuzzle(string puzzlePath)
        {
            var puzzleValueRows = File.ReadAllLines(puzzlePath);
            var puzzleValues = new int?[9, 9];
            for (int row = 0; row < 9; row++)
            {
                var puzzleValuesRow = puzzleValueRows[row];
                for (int column = 0; column < 9; column++)
                {
                    var puzzleValue = puzzleValuesRow[column];
                    puzzleValues[row, column] = puzzleValue == '-' ? null : (int?)int.Parse(puzzleValue.ToString());
                }
            }
            return new SudokuGrid(puzzleValues);
        }
    }
}
