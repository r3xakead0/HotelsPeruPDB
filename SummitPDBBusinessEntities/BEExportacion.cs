using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SummitPDB.BusinessEntities
{
    public class BEExportacion
    {
        private String _Resultado;

        public string Resultado
        {
            set { _Resultado = value; }
            get { return _Resultado; }
        }
    }
}
