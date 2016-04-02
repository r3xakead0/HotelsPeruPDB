using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SummitPDB.BusinessLogic;
using SummitPDB.BusinessEntities;

namespace SummitPDB.ServicesInterface
{
    public class IImportarArchivos
    {
        public string IHospedajeImportar(string pathHoteles, BEUser user)
        {
            ImportarArchivosBL BL = new ImportarArchivosBL();
            string delimitador = "|";
            return BL.HospedajeImportBL(pathHoteles, delimitador, user);
        }
        public string IVentasImportar(string pathHoteles,BEUser userLocal)
        {
            ImportarArchivosBL BL = new ImportarArchivosBL();
            string delimitador = "|";
            return BL.VentasImportBL(pathHoteles, delimitador,userLocal);
        }

        public string IComprasImportar(string pathHoteles, BEUser userLocal)
        {
            ImportarArchivosBL BL = new ImportarArchivosBL();
            string delimitador = "|";
            return BL.ComprasImportBL(pathHoteles, delimitador, userLocal);
        }
        public string ITipo_CambioImportar(string pathHoteles, BEUser userLocal)
        {
            ImportarArchivosBL BL = new ImportarArchivosBL();
            string delimitador = "|";
            return BL.Tipo_CambioImportBL(pathHoteles, delimitador, userLocal);
        }
        public List< BELog_Importar> IgetLog_Importar()
        {
            ImportarArchivosBL BL = new ImportarArchivosBL();
            return BL.GetLog_Importar();
        }
    }
}
