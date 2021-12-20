/******************************************************************/
/* Archivo: Globals.cs                                            */
/* Programador: Raul Peredo Estudillo                             */
/* Fecha: 6/nov/2021                                              */
/* Fecha modificación: 6/nov/2021                                 */
/* Descripción: Clase que contiene la información de una partida  */
/******************************************************************/
using Contracts.match;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Match
    {
        public int idWhite { get; set; }
        public int idBlack { get; set; }

        public IMatchClient idWhiteConnection;
        public IMatchClient idBlackConnection;

        public Match(int idW, int idB)
        {
            idWhite = idW;
            idBlack = idB;
        }
    }
}
