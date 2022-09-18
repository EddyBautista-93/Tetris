using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
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
    }
}
