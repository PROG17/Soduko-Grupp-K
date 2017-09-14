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
        private List<char> possibleNumbers = new List<char> () { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private char number;
        public enum Blocks { A, B , C , D, E, F, G, H, I}


        
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
                if (Row < 7 )
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

        public List<char> PossibleNumbers
        {
            get { return possibleNumbers; }
        }
        
        public int Row { get => row; set => row = value; }
        public int Column { get => column; set => column = value; }
        public char Number { get => number; set => number = value; }


        // Constructor

        public SodokuCell(int row, int column, char value)
        {
            this.Column = column;
            this.Row = row;
            this.Number = value;
        }

        // Method for printing possiblNumbers

        public void PrintPossibleNumbers ()
        {
            foreach (var item in possibleNumbers)
            {
                Console.WriteLine(item);
            }
        }

    }
}
