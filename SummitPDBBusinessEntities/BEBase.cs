using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SummitPDB.BusinessEntities
{
    [Serializable]
    public class BEBase
    {
        private string _usuarioCreacion;
        private string _usuarioModificacion;

        private DateTime _fechaCreacion;
        private DateTime _fechaModificacion;

        public string usuarioCreacion
        {
            set { _usuarioCreacion = value; }
            get { return _usuarioCreacion; }
        }

        public string usuarioModificacion
        {
            set { _usuarioModificacion = value; }
            get { return _usuarioModificacion; }
        }

        public DateTime fechaCreacion
        {
            get { return _fechaCreacion; }
            set { _fechaCreacion = value; }
        }

        public DateTime fechaModificacion
        {
            get { return _fechaModificacion; }
            set { _fechaModificacion = value; }
        }

    }
}
