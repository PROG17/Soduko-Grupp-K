using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soduko
{
    class SudokuBoard
    {

        public int Row { get; set; }
        public int Col { get; set; }
        public int Box { get; set; }

        //Eller
        string[] rader = new string[9];
        string[] columner = new string[9];
        string[] boxar = new string[9];

        public char[] sudokuboard = new char[81];


        public void PutInNumbers()
        {
            string teststräng = "037060000205000800006908000000600024001503600650009000000302700009000402000050360";
            teststräng.ToCharArray();

            for (int i = 0; i < sudokuboard.Length; i++)
            {
                sudokuboard[i] = teststräng[i];
                Console.WriteLine(sudokuboard[i]);
            }


            //char[,] temp = new char[9,9];

            //for (int i = x; i < 9; i++)
            //{
            //    for (int q = y; q < 9; i++)
            //    {
            //        temp[i, y] = teststräng[count++];

            //        Console.WriteLine(sudokuboard[i, y]);


            //        //temp.Add(new SodokuCell(x + 1, i - (9 * x), gameplan[i - 1]));
            //    }
            //    //x++;
            //}
        }

        string tillfällig = "";

        public void Rows()
        {
            int counter = 0;
            int radcounter = 0;

            for (int i = 0; i < 9; i++)
            {
                tillfällig = sudokuboard[i].ToString();
                rader[counter] = tillfällig;
                counter += 9;

            }

        }

                //        while (counter< 9)
                //{
                //    tillfällig += rader[counter];
                //}


    //public void BoardAsText()
    //{

    //    Console.WriteLine("---------------------");


    //    foreach (var item in sudokuboard)
    //    {
    //        Console.Write(item.Number + " ");
    //        if ((item.Column % 3 == 0) && (item.Column != 9)) { Console.Write("| "); }
    //        if (item.Column % 9 == 0) { Console.WriteLine(); }

    //        if ((item.Row % 3 == 0) && (item.Column % 9 == 0)) { Console.WriteLine("---------------------"); }
    //    }



    //}



    ////Konstruktur 
    //public SudokuBoard(string gameplan)
    //{
    //    //Här ska vi göra 
    //}

    //public void TextToArray()
    //{
    //    string text = "037060000205000800006908000000600024001503600650009000000302700009000402000050360";
    //    textArray = text.ToCharArray();
    //}


    ////private int[,] numbers = new int[9, 9];





    //public void checkNumber(int row, int col)
    //{
    //    this.row = row;
    //    this.col = col;
    //}

    //private void checkRow()
    //{

    //}

    //private void checkCol()
    //{

    //}

    //private void checkBox()
    //{

    //}
}
}
