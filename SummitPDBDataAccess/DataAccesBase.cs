using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SummitPDB.BusinessEntities;
using System.Configuration;
using SummitPDB.Tools;

namespace SummitPDB.DataAccess
{

     public abstract class DataAccesBase
    {
        private Database _connectionStringSQL;


        public Database ConnectionStringSQL
        {
            set { _connectionStringSQL = value; }
            get
            {
                return DatabaseFactory.CreateDatabase(TipoConnection.ConeccionSQL.ToString());                
            }

        }

        public virtual int Add(BEBase objEntidad)
        { throw new Exception("");}

        public virtual int Delete(BEBase objEntidad)
        { throw new Exception(""); }

        public virtual int Edit(BEBase objEntidad)
        { throw new Exception(""); }

        public virtual BEBase Get(BEBase objEntidad)
        { throw new Exception(""); }       

    }
}
