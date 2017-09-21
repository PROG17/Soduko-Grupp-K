using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soduko
{
    class SudokuBoard
    {

        //public int Row { get; set; }
        //public int Col { get; set; }

        //Eller
        string[] rader = new string[9];
        string[] columner = new string[9];
        string[] boxar = new string[9];

        char[] testare = new char[81];
        string teststräng = "037060000205000800006908000000600024001503600650009000000302700009000402000050360";
        char[,] sudokuboard = new char[9, 9];
        int counter = 0;

        string tillfällig = "";


        //Sätter nummer i vår sudokuboard utifrån angivet pussel.
        public void PutInNumbers()
        {
            counter = 0;
            //teststräng = "037060000205000800006908000000600024001503600650009000000302700009000402000050360";
            teststräng.ToCharArray();
            char[] testare = teststräng.ToCharArray().Clone() as char[];

            while (counter < 81)
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        sudokuboard[i, j] = testare[counter];
                        //Console.Write(sudokuboard[i, j] + " ");//skrive ut brädan sen?
                        counter++;
                    }
                }
            }
        }

        //Skriver ut siffrorna på skärmen som ett sudokubräde
        public void PrintNumbers()
        {
            int counter = 0;
            string row = "";
            List<string> printRows = new List<string>();

            foreach (char c in teststräng)
            {
                row += c;
                counter++;
                if (counter == 3 && row.Length < 15)
                {
                    row += " | ";
                    counter = 0;
                }
                if (row.Length == 15)
                {
                    printRows.Add(row);
                    row = "";
                    counter = 0;
                }
            }
            int newRow = 0;
            foreach (var rad in printRows)
            {
                newRow++;
                Console.WriteLine(rad);
                if (newRow == 3)
                {
                    Console.WriteLine("---------------");
                    newRow = 0;
                }
            }

        }
        //Hittar siffror i varje rad och lägger i sträng
        public void Rows()
        {
            counter = 0;

            while (counter < 9)
            {
                for (int i = 0; i < 9; i++)
                {
                    tillfällig = " ";

                    for (int j = 0; j < 9; j++)
                    {
                        tillfällig += sudokuboard[i, j];

                        if (tillfällig.Length == 9)
                        {
                            rader[counter] = tillfällig;
                            counter++;
                        }
                    }
                }
            }
        }

        //Hittar siffror i varje column och lägger i sträng
        public void Columns()
        {
            counter = 0;
            while (counter < 9)
            {
                for (int i = 0; i < 9; i++)
                {
                    string tillfällig = "";

                    for (int j = 0; j < 9; j++)
                    {
                        tillfällig += sudokuboard[j, i];

                        if (tillfällig.Length == 9)
                        {
                            columner[counter] = tillfällig;
                            counter++;
                        }
                    }
                }
            }
        }

        //Hittar siffror från column och rad och skapar 3x3 boxar
        public void Box()
        {
            int x = 0;
            int y = 0;

            if (y < 3)
            {
                if (x < 3)
                {
                    tillfällig = "";
                    for (int i = 0; i < 3; i++)
                    {

                        for (int j = 0; j < 3; j++)
                        {
                            tillfällig += sudokuboard[i, j];
                            boxar[0] = tillfällig;
                        }
                        x++;
                    }
                }
                if (x < 6)
                {
                    tillfällig = "";
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 3; j < 6; j++)
                        {
                            tillfällig += sudokuboard[i, j];
                            boxar[1] = tillfällig;
                        }
                        x++;
                    }
                }
                if (x < 9)
                {
                    tillfällig = "";
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 6; j < 9; j++)
                        {
                            tillfällig += sudokuboard[i, j];
                            boxar[2] = tillfällig;
                        }
                        x++;
                        y++;
                    }
                }
            }
            if (y < 6)
            {
                x = 0;
                if (x < 3)
                {
                    tillfällig = "";
                    for (int i = 3; i < 6; i++)
                    {

                        for (int j = 0; j < 3; j++)
                        {
                            tillfällig += sudokuboard[i, j];
                            boxar[3] = tillfällig;
                        }
                        x++;
                    }
                }
                if (x < 6)
                {
                    tillfällig = "";
                    for (int i = 3; i < 6; i++)
                    {
                        for (int j = 3; j < 6; j++)
                        {
                            tillfällig += sudokuboard[i, j];
                            boxar[4] = tillfällig;
                        }
                        x++;
                    }
                }
                if (x < 9)
                {
                    tillfällig = "";
                    for (int i = 3; i < 6; i++)
                    {
                        for (int j = 6; j < 9; j++)
                        {
                            tillfällig += sudokuboard[i, j];
                            boxar[5] = tillfällig;
                        }
                        x++;
                        y++;
                    }
                }
            }
            if (y < 9)
            {
                x = 0;
                if (x < 3)
                {
                    tillfällig = "";
                    for (int i = 6; i < 9; i++)
                    {

                        for (int j = 0; j < 3; j++)
                        {
                            tillfällig += sudokuboard[i, j];
                            boxar[6] = tillfällig;
                        }
                        x++;
                    }
                }
                if (x < 6)
                {
                    tillfällig = "";
                    for (int i = 6; i < 9; i++)
                    {
                        for (int j = 3; j < 6; j++)
                        {
                            tillfällig += sudokuboard[i, j];
                            boxar[7] = tillfällig;
                        }
                        x++;
                    }
                }
                if (x < 9)
                {
                    tillfällig = "";
                    for (int i = 6; i < 9; i++)
                    {
                        for (int j = 6; j < 9; j++)
                        {
                            tillfällig += sudokuboard[i, j];
                            boxar[8] = tillfällig;
                        }
                        x++;
                        y++;
                    }
                }
            }
        }

        //Reducerar antal möjliga nummer i varje ruta
        //public void ReduceToPossibleNumbers()
        //{

        //}

        //public void Checker()
        //{
        //    string[,] temp = sudokuboard.Clone() as string[,];
        //    //Använd en utav dem
        //    string numberForCheckUp = "123456789";
        //    numberForCheckUp.ToCharArray();
        //    int möjligaNummerKvar;

        //    string[] reducera = new string[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };


        //    for (int i = 0; i < 9; i++)
        //    {
        //        for (int y = 0; y < 9; y++)
        //        {
        //            //Hittar alla celler utan värde
        //            if (temp[i, y] == "0")
        //            {

        //                for (int q = 0; q < 9; q++)
        //                {
        //                    string NummerTest = numberForCheckUp[q].ToString();
        //                    int testare = int.Parse(NummerTest);

        //                    if (NummerTest.Contains(rader[i]))
        //                    {
        //                        möjligaNummerKvar += testare;
        //                    }

        //                    if (NummerTest == boxar[i])
        //                    {
        //                        möjligaNummerKvar -= NummerTest;
        //                    }
        //                    if (NummerTest == columner[i])
        //                    {
        //                        möjligaNummerKvar += NummerTest;
        //                    }
        //                }
        //                if (möjligaNummerKvar.Length==1)
        //                {
        //                    sudokuboard[i, y] = möjligaNummerKvar;
        //                }
        //                //Vi kan komma att behöva denna sedan när vi ska gissa. 
        //                else
        //                {
        //                    temp[i, y] = möjligaNummerKvar;
        //                }

        //                //När man kollat rad, column och box och kunnat reducera till en siffra ändrar vi värdet i temp[i,y] till det som är kvar
        //                if (temp[i,y].Length==1)
        //                {
        //                    temp[i, y] = reducerad[i];

        //                }
        //            }
        //        }
        //    }



        //}


        ////Ska skriva ut lösningen till Consolen.
        //public void BoardAsText()
        //{
        //    Console.WriteLine("__________________________________________");

        //    //Rita ur brädspelet.

        //    Console.WriteLine("__________________________________________");

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
