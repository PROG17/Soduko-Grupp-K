using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soduko
{
    class Sodoku
    {
        // Fields

        private List<SodokuCell> allCells;
        

        // Properties

        public List<SodokuCell> AllCells { get => allCells; set => allCells = value; }
        

        // Constructor

        public Sodoku (string gameplan)
        {
            this.AllCells = InitializeGame(gameplan);
        }

        
        // Metod för att skapa brädet
        
        
        public List<SodokuCell> InitializeGame(string gameplan)
        
        {
            int y = 1;
            int x = 0;
            
            List<SodokuCell> temp = new List<SodokuCell>();
            
            while (x < 9)
            {
                for (int i = y; i < y + 9; i++)
                {
                    temp.Add(new SodokuCell(x + 1, i - (9 * x), gameplan[i - 1]));
                    

                }
                x++;
                y += 9;
            }
            return temp;
        }
        // Metod för att skriva ut brädet

        public void BoardAsText()
        {

           Console.WriteLine("---------------------");      
            

            foreach (var item in AllCells)
            {
                Console.Write(item.Number + " ");
                if ((item.Column % 3 == 0) && (item.Column != 9)) { Console.Write("| "); }
                if (item.Column % 9 == 0) { Console.WriteLine(); }

                if ((item.Row % 3 == 0) && (item.Column % 9 == 0)) { Console.WriteLine("---------------------"); }
            }
            
            

        }
        // Metod för att lösa Sodokut



        public void Solve()
        {
            int count = 0;
            int prevcount = 0;
            bool test = true;

            while ((count < 81) && test == true)
            {
                count = 0;
                foreach (var item in allCells)
                {

                    ReducePossibleNumbers(item.Row, item.Column, item.Number);
                    if (item.PossibleNumbers.Count == 1)
                    {
                        count++;
                    }

                }
                if (prevcount == count)
                {
                    test = false;
                    Console.WriteLine("Unsolvable!");
                }
                prevcount = count;
                
                
            }
            
        }

        //// Metod för att reducera möjliga siffror

        public void ReducePossibleNumbers(int row, int col, char num)
        {

            SodokuCell activeCell = allCells.Single(x => (x.Row == row) && (x.Column == col));

            //activeCell.Number = num;


            foreach (var item in allCells.Where(item => (item.Row == row) && (item.Solved == false))) // Reducera möjliga nummer för alla celler i samma rad
            {
                item.PossibleNumbers.Remove(num);
                    if (item.PossibleNumbers.Count == 1)
                    {
                        item.Number = item.PossibleNumbers[0];
                    }

            }

            foreach (var item in allCells.Where(item => (item.Column == col) && (item.Solved == false))) // Reducera möjliga nummer för alla celler i samma kolumn
            {
                item.PossibleNumbers.Remove(num);
                    if (item.PossibleNumbers.Count == 1)
                    {
                        item.Number = item.PossibleNumbers[0];
                    }

            }

            foreach (var item in allCells.Where(item => (item.Block == activeCell.Block) && (item.Solved == false))) // Reducera möjliga nummer för alla celler i samma block
            {
                item.PossibleNumbers.Remove(num);
                    if (item.PossibleNumbers.Count == 1)
                     {
                        item.Number = item.PossibleNumbers[0];
                     }

            }


        }



    }
}
     

   

