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
            string easy = "003020600900305001001806400008102900700000008006708200002609500800203009005010300";
            string medium = "037060000205000800006908000000600024001503600650009000000302700009000402000050360";
            var impossible = "781543926006179500954628731695837214148265379327914800413752698002000400579486103";


            SudokuBoard game = new SudokuBoard(medium);
            game.Solve();

        }
    }
}
