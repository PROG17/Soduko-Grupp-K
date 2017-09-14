using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soduko
{
    class SodokuGame
    {
        static void Main(string[] args)
        {
            Sodoku game = new Sodoku("619030040270061008000047621486302079000014580031009060005720806320106057160400030");
            //string str = "619030040270061008000047621486302079000014580031009060005720806320106057160400030";

            
            game.PrintBoard();

            game.Solve();

            game.PrintBoard();

            game.Solve();




            //game.ReducePossibleNumbers(1, 1, '0');


            foreach (var item in game.AllCells)
            {
                Console.Write(item.PossibleNumbers.Count());
            }

            



        }
    }
}
