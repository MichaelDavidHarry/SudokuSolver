using System.Collections.Generic;
using System.Linq;

namespace SudokuSolver
{
    public class SudokuHelper
    {
        private SudokuGrid Grid { get; set; }
        public SudokuHelper(SudokuGrid grid)
        {
            Grid = grid;

        }

        private IEnumerable<int?> PossibleSudokuNumbers { get; } = Enumerable.Range(1, 9).Cast<int?>();

        public IEnumerable<int?> GetPossibleSquareValues(int rowIndex, int columnIndex)
        {
            return GetPossibleValuesForRow(rowIndex).Intersect(GetPossibleValuesForColumn(columnIndex)).Intersect(GetPossibleValuesForSubgrid(rowIndex, columnIndex));
        }

        public IEnumerable<int?> GetPossibleValuesForRow(int rowIndex)
        {
            return PossibleSudokuNumbers.Except(GetRowValues(rowIndex));
        }

        public IEnumerable<int?> GetPossibleValuesForColumn(int columnIndex)
        {
            return PossibleSudokuNumbers.Except(GetColumnValues(columnIndex));
        }

        public IEnumerable<int?> GetPossibleValuesForSubgrid(int rowIndex, int columnIndex)
        {
            return PossibleSudokuNumbers.Except(GetSubgridValues(rowIndex, columnIndex));
        }

        private IEnumerable<int?> GetRowValues(int rowIndex)
        {
            var values = new List<int?>();
            for(int i = 0; i < 9; i++)
            {

                values.Add(Grid[rowIndex, i].Value);
            }
            return values;
        }

        private IEnumerable<int?> GetColumnValues(int columnIndex)
        {
            var values = new List<int?>();
            for (int i = 0; i < 9; i++)
            {
                values.Add(Grid[i, columnIndex].Value);  
            }
            return values;
        }

        private IEnumerable<int?> GetSubgridValues(int rowIndex, int columnIndex)
        {
            var subgridRowIndex = GetSubgridIndex(rowIndex);
            var subgridColumnIndex = GetSubgridIndex(columnIndex);

            var values = new List<int?>();

            for(int i = subgridRowIndex * 3; i < (subgridRowIndex + 1) * 3; i++)
            {
                for(int j = subgridColumnIndex * 3; j < (subgridColumnIndex + 1) * 3; j++)
                {
                    values.Add(Grid[i, j].Value);
                }
            }

            return values;
        }

        private int GetSubgridIndex(int rowOrColumnIndex)
        {
            return rowOrColumnIndex / 3;
        }
    }
}
