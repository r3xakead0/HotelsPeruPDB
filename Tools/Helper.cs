using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SummitPDB.Tools
{
    public class Helper
    {
        public static string CambiarPrimerasLetrasAMayuscula(string cadena)
        {
            if (cadena.Length == 0)
                return string.Empty;

            cadena = cadena.ToLower().Trim();
            string respuesta = "";

            #region Separacion de palabras
            string[] temporal = cadena.Split(' ');
            #endregion

            #region Upper de cada palabra
            for (int i = 0; i < temporal.Length; i++)
            {
                temporal[i] = char.ToUpper(temporal[i][0]) + temporal[i].Substring(1);
            }
            #endregion

            #region Concatenacion
            for (int i = 0; i < temporal.Length; i++)
            {
                respuesta = respuesta + temporal[i] + " ";
            }
            #endregion

            return respuesta.Trim();
        }
    }
}
