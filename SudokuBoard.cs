using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soduko
{
    class SudokuBoard
    {
        string[] rader = new string[9];
        string[] columner = new string[9];
        string[] boxar = new string[9];

        char[] testare = new char[81];
        string teststräng = "037060000205000800006908000000600024001503600650009000000302700009000402000050360";
        char[,] sudokuboard = new char[9, 9];
        int[,] tempSudokuBoard = new int[9, 9];
        int counter = 0;
        string tillfällig = "";

        //Sätter nummer i vår sudokuboard utifrån angivet pussel.
        public void PutInNumbers()
        {
            teststräng.ToCharArray();
            char[] testare = teststräng.ToCharArray().Clone() as char[];

            while (counter < 81)
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        sudokuboard[i, j] = testare[counter];
                        counter++;
                    }
                }
            }
        }

        //Skriver ut siffrorna på skärmen som ett sudokubräde
        public void PrintNumbers()
        {
            counter = 0;
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
                    tillfällig = "";

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

        public void ReduceToPossibleNumbers()
        {
            int[] numberChecker = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //Fyller tempSudokuBoard
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    string number = sudokuboard[i, j].ToString();
                    int numberint = int.Parse(number);
                    tempSudokuBoard[i, j] = numberint;
                }
            }

            //Ger möjliga värden till celler som har 0
            for (int i = 0; i < 9; i++)
            {
                for (int y = 0; y < 9; y++)
                {
                    //Hittar alla celler utan värde
                    if (tempSudokuBoard[i, y] == 0)
                    {
                        List<int> possibleNumbersLeft = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                        int numberTestAsInt = 0;

                        for (int k = 0; k < 9; k++)
                        {
                            numberTestAsInt = numberChecker[k];
                            string numberTestAsString = numberChecker[k].ToString();

                            if (rader[i].Contains(numberTestAsString))
                            {
                                possibleNumbersLeft.Remove(numberTestAsInt);//Läger till alla nummer som existerar i rad
                            }
                            else if (columner[y].Contains(numberTestAsString)) //Man behöver bara hitta numret en gång i rad, column eller box. Har man hittat den en gång behöver man inte fortsätta leta efter möjliga nummer som inte kan fungera
                            {
                                possibleNumbersLeft.Remove(numberTestAsInt);
                            }
                            //else if (boxar[i].Contains(numberTestAsString)) // Hur testa boxarna?
                            //{
                            //    possibleNumbersLeft.Remove(numberTestAsInt);
                            //}
                        }

                        if (possibleNumbersLeft.Count() == 1) //Om det bara finns ett möjligt kvar sätts värdet i cellen
                        {
                            tempSudokuBoard[i, y] = numberTestAsInt;
                        }
                        else
                        {
                            StringBuilder nummersträng = new StringBuilder();
                            string total = "";

                            foreach (var nr in possibleNumbersLeft)
                            {
                                nummersträng.Append(nr.ToString());
                            }

                            total = nummersträng.ToString();
                            int nummerint = Convert.ToInt32(total);
                            tempSudokuBoard[i, y] = nummerint;
                        }
                    }
                }
            }
        }

        public void Guesser()
        {
            // Ta cell för cell
            //Ta första siffran som är kvar i cellen och gör om den till en en siffra. 
            //Testa reduce numbers metoden med den siffran.<---
            //OM det inte finns några celler med fler än en siffra kvar, avbryt och . Kopiera över till vanliga sudokbräden.

            //Om inte testa nästa siffra i ruta tills alla siffror som är kvar är testade i alla celler.

            counter = 0;
            while (counter < 81)
            {
                counter++;

                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        string numbersToGuess = tempSudokuBoard[i, j].ToString();
                        numbersToGuess.ToCharArray();

                        for (int k = 0; k < numbersToGuess.Length; k++)
                        {
                            string guessingNumbersträng = numbersToGuess[k].ToString(); ;
                            int guesingNumberInt = Convert.ToInt32(guessingNumbersträng);
                            tempSudokuBoard[i, j] = guesingNumberInt;
                            ReduceToPossibleNumbers();
                        }
                        if (tempSudokuBoard.ToString().Length == 81)
                        {
                            break;
                        }
                    }
                }
            }
        }

        ////Konstruktur 
        //public SudokuBoard(string gameplan)
        //{
        //    //Här ska vi göra 
        //}
    }
}
