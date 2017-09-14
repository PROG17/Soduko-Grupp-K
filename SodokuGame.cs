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

            //SodokuCell cell1 = new SodokuCell(1, 1, str[2]);

            //Console.WriteLine(game.AllCells[80].Row);
            //Console.WriteLine(game.AllCells.);

            //Console.WriteLine(game.AllCells.Exists(x => (x.Number == '6') && (x.Row == '1')));
            //Console.WriteLine(game.AllCells.
            game.PrintBoard();

            game.Solve();

            //game.ReducePossibleNumbers(1, 1, '0');

            foreach (var item in game.AllCells)
            {
                Console.WriteLine(item.PossibleNumbers.Count());
            }


            //game.AllCells[0].PossibleNumbers.RemoveAll;




            //Console.WriteLine(game.AllCells.FindAll(x => x.Row == 9).Number);



            //game.Solve();
            //Console.WriteLine(game.BoardAsText);


        }
    }
}
