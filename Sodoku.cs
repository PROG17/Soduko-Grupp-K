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

        public void PrintBoard()
        {

            for (int i = 1; i < 10; i++)
            {
                foreach (var item in allCells.FindAll(x => (x.Row == i))) { Console.Write(item.Number + " "); }
                Console.WriteLine();
            }

                   


        }
        // Metod för att lösa Sodokut



        //public void Solve ()
        //{
        //    foreach (var item in allCells)
        //    {
        //        ReducePossibleNumbers(item.Row, item.Column, item.Number);
        //    }
        //}

        //// Metod för att reducera möjliga siffror

        //public void ReducePossibleNumbers (int row, int col, char num)
        //{
        //    foreach (var item in allCells.Where(       //(x => (x.Row == i)))
        //    {
        //        Console.Write(item.Number + " ");
        //    }
        //}



    }
}
     

   

