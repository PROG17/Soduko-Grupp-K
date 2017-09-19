using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soduko
{
    public class SodokuCell
    {
        // Fields

        private int row;
        private int column;
        private List<char> possibleNumbers;
        private char number;
        private bool solved;

        public enum Blocks { A, B, C, D, E, F, G, H, I }


        // Properties


        public Blocks Block
        {
            get
            {
                if (Row < 4)
                {
                    if (Column < 4)
                    {
                        return Blocks.A;
                    }
                    return Column < 7 ? Blocks.B : Blocks.C;

                }
                if (Row < 7)
                {
                    if (Column < 4)
                    {
                        return Blocks.D;
                    }
                    return Column < 7 ? Blocks.E : Blocks.F;
                }
                if (Column < 4)
                {
                    return Blocks.G;
                }
                return Column < 7 ? Blocks.H : Blocks.I;
            }
        }


        //public List<char> PossibleNumbers { get => possibleNumbers; set => possibleNumbers = value; }
        public int Row { get => row; set => row = value; }
        public int Column { get => column; set => column = value; }
        public char Number { get => number; set => number = value; }

        public bool Solved
        {
            get
            {
                if (Number != '0')
                {
                    return solved = true;
                }
                return solved = false;
            }
            set { this.solved = value; }

        }
        public List<char> PossibleNumbers
        {
            get
            {
                if (Number != '0')
                {
                    return possibleNumbers = new List<char>() { Number };
                }
                else
                {
                    return possibleNumbers;

                }
            }
        }
        // Constructor

        public SodokuCell(int row, int column, char value)
        {
            this.Column = column;
            this.Row = row;
            this.Number = value;
                if (value == '0')
                {
                    this.possibleNumbers = new List<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                }
            else
            {
                this.possibleNumbers = new List<char>() { value };
            }

        }

        // Method for printing possiblNumbers

        public void PrintPossibleNumbers ()
        {
            foreach (var item in possibleNumbers)
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }

    }
}
