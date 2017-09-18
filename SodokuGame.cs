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
            //"lätt" Soduku. svårighetsgrad som kan lösas helt endast med hjälp av sodukureglerna 
            //Sodoku game = new Sodoku("003020600900305001001806400008102900700000008006708200002609500800203009005010300");

            // "svårt". Man kommer inte fram till helt utan måste köra någon sorts gissningsvariant som inte finns i programmet än
            Sodoku game = new Sodoku("037060000205000800006908000" +
                                     "000600024001503600650009000" +
                                     "000302700009000402000050360");

            
            game.Solve();

            game.BoardAsText();

 
        }
    }
}
