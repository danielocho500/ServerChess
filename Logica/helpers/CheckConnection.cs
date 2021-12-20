using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.helpers
{
    public class CheckConnection
    {
        public static bool isConnected()
        {
            bool status = false;
            try
            {
                using (var context = new SuperChess())
                {
                    var pieceExist = from Piece in context.Pieces
                                     where Piece.id_piece == 1
                                     select Piece;
                    if (pieceExist.Count() > 0)
                        status = true;
                }
            }
            catch(Exception e)
            {
                status = false;
                Console.WriteLine("Error in the helper of CheckConnection: \n"+e);
            }
            
            return status;
        }
    }
}
