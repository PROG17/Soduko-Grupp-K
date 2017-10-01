using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading;

namespace Soduko
{
    class SudokuBoard
    {
        private string boardToSolve = "";
        int[,] sudokuBoard = new int[9, 9];
        int[,] tempSudoku = new int[9, 9];

        public SudokuBoard(string gameBoard)
        {
            boardToSolve = gameBoard;
        }

        public bool Play()
        {
            PutInNumbers(boardToSolve);
            PrintNumbers(sudokuBoard);

            if (Solver()) //kör och kollar sant/falskt
            {
                Console.WriteLine("Solved it for you!");
                PrintNumbers(sudokuBoard);
                Thread.Sleep(155515151);
                return true;
            }
            return false;
        }

        public void PutInNumbers(string spel)
        {
            int index = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    sudokuBoard[i, j] = (int)char.GetNumericValue(spel[index]);
                    index++;
                }
            }
        }

        //Skriver ut siffrorna på skärmen som ett sudokubräde
        public void PrintNumbers(int[,] brädet)
        {
            Console.SetCursorPosition(0, 1);
            for (var row = 0; row < 9; row++)
            {
                for (var col = 0; col < 9; col++)
                {
                    Console.Write(brädet[row, col]);
                    if (col == 2 || col == 5)
                        Console.Write(" | ");
                }
                Console.WriteLine();
                if (row == 2 || row == 5)
                    Console.WriteLine("---------------");
            }

            Console.WriteLine("Processing Solver. . .\n");
        }

        public bool CellHasChanged(int[,] spel)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if (spel[i, y] != sudokuBoard[i, y])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool Solver()
        {
            while (true)
            {
                tempSudoku = (int[,])sudokuBoard.Clone();//Behövs för att se om en cell har ändrats i CellHasChanged 
                bool hasUnSolvedCells = false;

                //Ger möjliga värden till celler som har 0
                for (int i = 0; i < 9; i++)
                {
                    for (int y = 0; y < 9; y++)
                    {
                        //Hittar en cell utan värde
                        if (sudokuBoard[i, y] == 0)
                        {
                            hasUnSolvedCells = true;
                            if (GetPossibleNumbers(i, y).Count == 1)
                            {
                                sudokuBoard[i, y] = GetPossibleNumbers(i, y)[0];
                            }
                            else if (GetPossibleNumbers(i, y).Count == 0)
                            {
                                Console.WriteLine("Impossible?");
                                return false;
                            }
                        }
                    }
                }

                if (!hasUnSolvedCells)
                {
                    return true; //Hoppar ur loopar när brädet är klart.
                }

                if (CellHasChanged(tempSudoku) == false)
                {
                    break;
                }
            }
            if (CellHasChanged(tempSudoku) == false && Guesser())
            {

                return true;
            }
            if (IsSolved(sudokuBoard))
            {
                return true;
            }
            return false;
        }


        public List<int> GetPossibleNumbers(int row, int col)
        {
            List<int> possibleNumbersLeft = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for (int y = 0; y < 9; y++)
            {
                if (sudokuBoard[row, y] != 0)
                {
                    possibleNumbersLeft.Remove(sudokuBoard[row, y]);
                }
            }
            for (int x = 0; x < 9; x++)
            {
                if (sudokuBoard[x, col] != 0)
                {
                    possibleNumbersLeft.Remove(sudokuBoard[x, col]);
                }
            }
            int rowX = (row / 3) * 3;
            int colY = (col / 3) * 3;

            for (int boxX = rowX; boxX < rowX + 3; boxX++)
            {
                for (int boxY = colY; boxY < colY + 3; boxY++)
                {
                    if (sudokuBoard[boxX, boxY] != 0)
                    {
                        possibleNumbersLeft.Remove(sudokuBoard[boxX, boxY]);
                    }
                }
            }
            return possibleNumbersLeft;
        }

        public bool IsSolved(int[,] game)
        {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if (game[x, y] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool Guesser()
        {
            while (true)
            {

                bool hasUnSolvedCells = false;

                for (int x = 0; x < 9; x++)
                {
                    for (int y = 0; y < 9; y++)
                    {
                        if (sudokuBoard[x, y] == 0)
                        {
                            hasUnSolvedCells = true;
                            foreach (var number in GetPossibleNumbers(x, y))
                            {
                                string newSudokuString = "";
                                foreach (var integer in sudokuBoard)
                                {
                                    newSudokuString += integer;
                                }
                                StringBuilder sb = new StringBuilder(newSudokuString);
                                var ch = (char)(48 + number);
                                sb[(x * 9) + y] = ch;
                                newSudokuString = sb.ToString();

                                var newBoard = new SudokuBoard(newSudokuString);
                                if (newBoard.Play())
                                {
                                    return true;
                                }
                            }
                        }
                        while (sudokuBoard[x, y] == 0 && GetPossibleNumbers(x, y).Count > 1)
                        {
                            for (int val = 0; val < GetPossibleNumbers(x, y).Count; val++)
                            {
                                sudokuBoard[x, y] = GetPossibleNumbers(x, y)[val];
                                if (sudokuBoard[x, y].ToString().Length > 1)
                                {
                                    sudokuBoard[x, y] = 0;
                                    Guesser();

                                    if (IsSolved(sudokuBoard))
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }

                return false;
            }

        }
    }
}
