using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;

namespace Soduko
{
    class SudokuBoard
    {
        //To-Do
        //villkoret för att komma till guesser
        //Backtrackingen i guesser.
        //Eventuellt en isSolved metod som kontrollera nollor


        int counter = 0;
        string tempValueString = "";
        private string boardToSolve = "";

        int[,] sudokuBoard = new int[9, 9];
        int[,] tempSudoku = new int[9, 9];

        public SudokuBoard(string gameBoard)
        {
            boardToSolve = gameBoard;
        }

        public void Solve()
        {
            Console.WriteLine("Unsolved Sudoku:\n");
            PutInNumbers(boardToSolve);
            PrintNumbers(sudokuBoard);
            Console.WriteLine("\nPress any key for Solution");
            Console.ReadKey();
            //Console.Clear();
            if (Solver()) //kör och kollar sant/falskt
            {
                Console.WriteLine("Solution:\n");
                PrintNumbers(sudokuBoard);
                Console.ReadLine();
                return;
            }
            else
            {
                Console.WriteLine("Unsolvable");
                return;
            }
            //Console.ReadLine();

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
            int[,] tempSudoku = sudokuBoard;//Behövs för att se om en cell har ändrats i CellHasChanged metoden


            bool hasUnSolvedCells = true;

            while (hasUnSolvedCells)
            {
                tempSudoku = sudokuBoard;
                hasUnSolvedCells = false;

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
                                Console.WriteLine("Unsolvable");
                                return false;
                            }

                        }
                    }
                }


                if (CellHasChanged(tempSudoku) == false)
                {
                    Guesser();
                }
                else if (!hasUnSolvedCells)
                {
                    return true;
                }
            }


            return false;
        }


        public List<int> GetPossibleNumbers(int row, int col)
        {
            List<int> possibleNumbersLeft = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }; ;

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
        //Fixa detta
        public bool Guesser()
        {
            
            Console.WriteLine("I GUESSERN: ");
            string newSudokuString = "";
            int value = 0;
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if (sudokuBoard[x, y] == 0)
                    {

                        foreach (var number in GetPossibleNumbers(x, y))
                        {
                            foreach (var integer in sudokuBoard)
                            {
                                newSudokuString += integer;
                            }
                            StringBuilder sb = new StringBuilder(newSudokuString);
                            var ch = (char) (48 + number);
                            sb[(x * 9) + y] = ch;
                            newSudokuString = sb.ToString();

                            var newBoard = new SudokuBoard(newSudokuString);

                            newBoard.Solver();
                            return false;
                        }
                    }

                }
            }
            return false;
        }
    }
}
