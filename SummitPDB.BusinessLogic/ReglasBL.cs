using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SummitPDB.BusinessEntities;
using SummitPDB.DataAccess;

namespace SummitPDB.BusinessLogic
{
    public class ReglasBL
    {

        public List<BEReglas> GetCaracteresBL()
        {
            ReglasDA reglasDAO = new ReglasDA();
            return reglasDAO.GetCaracteres();
        }

        public string CaractereInsBL(BEReglas reglas)
        {
            ReglasDA reglasDAO = new ReglasDA();
            return reglasDAO.CaracteresINS(reglas);
        }
        public string CaracteresDelBL(BEReglas reglas)
        {
            ReglasDA reglasDAO = new ReglasDA();
            return reglasDAO.CaracteresDEL(reglas);
        }
        public string ReglasInsBL(BEReglas reglas)
        {
            ReglasDA reglasDAO = new ReglasDA();
            return reglasDAO.ReglasIns(reglas);
        }
        public string ReglasDelBL(BEReglas reglas)
        {
            ReglasDA reglasDAO = new ReglasDA();
            return reglasDAO.ReglasDel(reglas);
        }
        public List<BEReglas> GetCaracteresEspecialesBL()
        {
            ReglasDA reglasDAO = new ReglasDA();
            return reglasDAO.GetCaracteresEspeciales();
        }
        /*Transaction*/
        public string ReglasLisInsBL(List<BEReglas> reglas)
        {
            ReglasDA reglasDAO = new ReglasDA();
            return reglasDAO.ReglasLisIns(reglas);
        }

        public List<BEReglas> GetEspecialesBL()
        {
            ReglasDA reglasDAO = new ReglasDA();
            return reglasDAO.GetEspeciales();
        }
    }
}