using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{

    // Game Logic
    class GameGrid
    {
        // Two Dimensional Rectangular Array  / Matrices
        // - Declared using comma within the brackets
        // - Data is stored in tabular form which is also known as a matrix.
        // - Each dimension is separated by a comma.
        // - Use the nested for loops to iterate through the rows and columns.
        private readonly int[,] grid;
        public int Rows { get; }
        public int Columns { get; }

        // Indexer to allowe easy access to the array

        public int this[int r, int c]
        {
            get => grid[r, c];
            set => grid[r, c] = value;
        }

        public GameGrid(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
            grid = new int[rows, columns];
        }

        // convience methods 

        public bool IsInside(int r, int c)
        {
            return r >= 0 && r < Rows && c >= 0 && c < Columns;
        }

        public bool IsEmpty(int r, int c)
        {
            return IsInside(r, c) && grid[r, c] == 0;
        }

        public bool IsRowFull(int r)
        {
            for(int c = 0; c < Columns; c++)
            {
                if(grid[r, c] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsRowEmpty(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r, c] != 0)
                {
                    return false;
                }
            }
            return true;
        }


        // Clearing the rows.
        private void ClearRow(int r)
        {
            for(int c = 0; c < Columns; c++)
            {
                grid[r, c] = 0;
            }
        }

        // Moves rows down after clearing 
        private void MoveRowDown(int r, int numRows)
        {
            for(int c = 0; c < Columns; c++)
            {
                grid[r + numRows, c] = grid[r, c];
                grid[r, c] = 0;
            }
        }

        public int ClearFullRows()
        {
            int cleared = 0;
            
            // Start from the bottom of the rows
            for (int r = Rows - 1; r < 0; r--)
            {
                if(IsRowFull(r))
                {
                    ClearRow(r);
                    cleared++;
                } 
                else if(cleared > 0)
                {
                    MoveRowDown(r, cleared);
                }

            }
            return cleared;
        }
    }
}
