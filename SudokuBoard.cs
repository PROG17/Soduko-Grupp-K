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

        char[,] sudokuboard = new char[9, 9];
        int counter = 0;

        string tillfällig = "";


        //Sätter nummer i vår sudokuboard utifrån angivet pussel.
        public void PutInNumbers()
        {
            counter = 0;
            string teststräng = "037060000205000800006908000000600024001503600650009000000302700009000402000050360";
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
           

            
            //else if (x < 6)
            //{
            //    if (y < 3)
            //    {
            //        for (int i = 0; i < 3; i++)
            //        {
            //            for (int j = 0; j < 3; j++)
            //            {
            //                if (sudokuboard[i, j] == 0)
            //                    possible = false;
            //            }

            //        }
            //    }
            //    else if (y < 6)
            //    {
            //        for (int i = 3; i < 6; i++)
            //        {
            //            for (int j = 3; j < 6; j++)
            //            {
            //                if (sudokuboard[i, j] == 0)
            //                    possible = false;
            //            }

            //        }
            //    }
            //    else if (y < 9)
            //    {
            //        for (int i = 6; i < 9; i++)
            //        {
            //            for (int j = 6; j < 9; j++)
            //            {
            //                if (sudokuboard[i, j] == 0)
            //                    possible = false;
            //            }
            //        }
            //    }
            //}
            //else if (x < 9)
            //{
            //    if (y < 3)
            //    {
            //        for (int i = 0; i < 3; i++)
            //        {
            //            for (int j = 0; j < 3; j++)
            //            {
            //                if (sudokuboard[i, j] == 0)
            //                    possible = false;
            //            }

            //        }
            //    }
            //    else if (y < 6)
            //    {
            //        for (int i = 3; i < 6; i++)
            //        {
            //            for (int j = 3; i < 6; i++)
            //            {
            //                if (sudokuboard[i, j] == 0)
            //                    possible = false;
            //            }

            //        }
            //    }
            //    else if (y < 9)
            //    {
            //        for (int i = 6; i < 9; i++)
            //        {
            //            for (int j = 6; j < 9; j++)
            //            {
            //                if (sudokuboard[i, j] == 0)
            //                    possible = false;
            //            }
            //        }
            //    }

            //}
            //if (x < 3)
            //{
            //    if (y < 3)
            //    {
            //        for (int i = 0; i < 3; i++)
            //        {
            //            for (int q = 0; q < 3; q++)
            //            {
            //                if (numbers[i, q, 0] == target)
            //                    possible = false;
            //            }
            //        }
            //    }
            //    else if (y < 6)
            //    {

            //        for (int i = 3; i < 6; i++)
            //        {
            //            for (int q = 3; q < 6; q++)
            //            {
            //                if (numbers[i, q, 0] == target)
            //                    possible = false;
            //            }
            //        }
            //    }
            //    else if (y < 9)
            //    {
            //        for (int i = 6; i < 9; i++)
            //        {
            //            for (int q = 6; q < 9; q++)
            //            {
            //                if (numbers[i, q, 0] == target)
            //                    possible = false;
            //            }
            //        }
            //    }

            //}
            //counter = 0;
            //while (counter < 9)
            //{
            //    for (int i = 0; i < 9; i++)
            //    {
            //        string tillfällig = "";

            //        for (int j = 0; j < 9; j++)
            //        {
            //            if (x < 3)
            //                tillfällig += sudokuboard[x, y];
            //            boxar[counter] = tillfällig;

            //        }
            //    }
            //}
        }

        //public void Box()
        //{
        //    //boxar från vänster till höger
        //    //Hjälp med att göra boxar kanske?

        //    tillfällig = sudokuboard[0, 0] + sudokuboard[0, 1] + sudokuboard[0, 2] + sudokuboard[1, 0] + sudokuboard[1, 1] + sudokuboard[1, 2] + sudokuboard[2, 0] + sudokuboard[2, 1] + sudokuboard[2, 2];
        //    boxar[0] = tillfällig;
        //    tillfällig = "";

        //    tillfällig = sudokuboard[0, 3] + sudokuboard[0, 4] + sudokuboard[0, 5] + sudokuboard[1, 3] + sudokuboard[1, 4] + sudokuboard[1, 5] + sudokuboard[2, 3] + sudokuboard[2, 4] + sudokuboard[2, 5];
        //    boxar[1] = tillfällig;
        //    tillfällig = "";

        //    tillfällig = sudokuboard[0, 6] + sudokuboard[0, 7] + sudokuboard[0, 8] + sudokuboard[1, 6] + sudokuboard[1, 7] + sudokuboard[1, 8] + sudokuboard[2, 6] + sudokuboard[2, 7] + sudokuboard[2, 8];
        //    boxar[2] = tillfällig;
        //    tillfällig = "";

        //    tillfällig = sudokuboard[3, 0] + sudokuboard[3, 1] + sudokuboard[3, 2] + sudokuboard[4, 0] + sudokuboard[4, 1] + sudokuboard[4, 2] + sudokuboard[5, 0] + sudokuboard[5, 1] + sudokuboard[5, 2];
        //    boxar[3] = tillfällig;
        //    tillfällig = "";

        //    tillfällig = sudokuboard[3, 3] + sudokuboard[3, 4] + sudokuboard[3, 5] + sudokuboard[4, 3] + sudokuboard[4, 4] + sudokuboard[4, 5] + sudokuboard[5, 3] + sudokuboard[5, 4] + sudokuboard[5, 5];
        //    boxar[4] = tillfällig;
        //    tillfällig = "";

        //    tillfällig = sudokuboard[3, 6] + sudokuboard[3, 7] + sudokuboard[3, 8] + sudokuboard[4, 6] + sudokuboard[4, 7] + sudokuboard[4, 8] + sudokuboard[5, 6] + sudokuboard[5, 7] + sudokuboard[5, 8];
        //    boxar[5] = tillfällig;
        //    tillfällig = "";

        //    tillfällig = sudokuboard[6, 0] + sudokuboard[6, 1] + sudokuboard[6, 2] + sudokuboard[7, 0] + sudokuboard[7, 1] + sudokuboard[7, 2] + sudokuboard[8, 0] + sudokuboard[8, 1] + sudokuboard[8, 2];
        //    boxar[6] = tillfällig;
        //    tillfällig = "";

        //    tillfällig = sudokuboard[6, 3] + sudokuboard[6, 4] + sudokuboard[6, 5] + sudokuboard[7, 3] + sudokuboard[7, 4] + sudokuboard[7, 5] + sudokuboard[8, 3] + sudokuboard[8, 4] + sudokuboard[8, 5];
        //    boxar[7] = tillfällig;
        //    tillfällig = "";

        //    tillfällig = sudokuboard[6, 6] + sudokuboard[6, 7] + sudokuboard[6, 8] + sudokuboard[7, 6] + sudokuboard[7, 7] + sudokuboard[7, 8] + sudokuboard[8, 6] + sudokuboard[8, 7] + sudokuboard[8, 8];
        //    boxar[8] = tillfällig;
        //    tillfällig = "";
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
