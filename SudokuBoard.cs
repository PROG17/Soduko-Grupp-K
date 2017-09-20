using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soduko
{
    class SudokuBoard
    {
        private int row;
        private int col;
        public char[] textArray;

        public void TextToArray()
        {
            string text = "037060000205000800006908000000600024001503600650009000000302700009000402000050360";
            textArray = text.ToCharArray();
        }


        //private int[,] numbers = new int[9, 9];





        public void checkNumber(int row, int col)
        {
            this.row = row;
            this.col = col;
        }

        private void checkRow()
        {

        }

        private void checkCol()
        {

        }

        private void checkBox()
        {

        }
    }
}
