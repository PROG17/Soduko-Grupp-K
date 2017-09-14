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
        // Metod för att lösa Sodokut -Ej färdigt



        public void Solve()
        {
            foreach (var item in allCells)
            {
                if (item.Number != '0')
                {
                    ReducePossibleNumbers(item.Row, item.Column, item.Number);
                }
            }
        }

        //// Metod för att reducera möjliga siffror

        public void ReducePossibleNumbers(int row, int col, char num)
        {

            SodokuCell activeCell = allCells.Single(x => (x.Row == row) && (x.Column == col));

            //activeCell.Number = num;


            foreach (var item in allCells.Where(item => (item.Row == row))) // Reducera möjliga nummer för alla celler i samma rad
            {
                item.PossibleNumbers.Remove(num);

            }

            foreach (var item in allCells.Where(item => (item.Column == col))) // Reducera möjliga nummer för alla celler i samma kolumn
            {
                item.PossibleNumbers.Remove(num);

            }

            foreach (var item in allCells.Where(item => (item.Block == activeCell.Block))) // Reducera möjliga nummer för alla celler i samma block
            {
                item.PossibleNumbers.Remove(num);
               
            }


        }



    }
}
     

   

