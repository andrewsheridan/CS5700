using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class Puzzle
    {
        int Size;
        
        List<char> Symbols;
        List<List<Cell>> Cells;
        //List<Row> Rows;
        //List<Column> Columns;
        //List<Block> Blocks;
        
        public Puzzle(int size, List<char> symbols)
        {
            Symbols = symbols;
            Size = size;
            Cells = new List<List<Cell>>();
            //Rows = new List<Row>();
            //Blocks = new List<Block>();
            //Columns = new List<Column>();
            //for(int i = 0; i < Size; i++)
            //{
            //    //Row newRow = new Row(Symbols);
            //    //Rows.Add(newRow);
            //    //Column newCol = new SudokuSolver.Column(Symbols);
            //    //Columns.Add(newCol);
            //    //Block newBlock = new Block(Symbols);
            //    //Blocks.Add(newBlock);
            //}
            for(int i = 0; i < Size; i++)
            {
                Cells.Add(new List<Cell>());
                for (int j = 0; j < Size; j++)
                {
                    Cells[i].Add(new Cell(symbols));
                    //Rows[i].Add(Cells[i][j]);
                    //Columns[j].Add(Cells[i][j]);
                    //int blockId = (i * size) / size + (j / size);
                    //Blocks[blockId].Add(Cells[i][j]);
                }
            }
        
        }

        public bool UpdateCell(int row, int col, char symbol)
        {
            Cells[row][col].SetValue(symbol);
            //Todo: Update the row and column and block

            return true;
        }

        public override string ToString()
        {
            string output = "";
            for(int i = 0; i < Size; i++)
            {
                for(int j = 0; j < Size; j++)
                {
                    output += Cells[i][j].SolvedValue != '0' ? Cells[i][j].SolvedValue : '-';
                }
                output += Environment.NewLine;
            }

            return output;
        }
    }
}
