using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SummitPDB.BusinessEntities;
using SummitPDB.BusinessLogic;

namespace SummitPDB.ServicesInterface
{
    public class IReglas
    {
        public List<BEReglas> IGetCaracteres()
        {
            ReglasBL BL = new ReglasBL();
            return BL.GetCaracteresBL();
        }
        public string IGetCaracteres(BEReglas regla)
        {
            ReglasBL BL = new ReglasBL();
            return BL.CaractereInsBL(regla);
        }
        public string ICaracteresDel(BEReglas regla)
        {
            ReglasBL BL = new ReglasBL();
            return BL.CaracteresDelBL(regla);
        }
        public string ICaracteresIns(BEReglas regla)
        {
            ReglasBL BL = new ReglasBL();
            return BL.CaractereInsBL(regla);
        }
        public string IReglasIns(BEReglas regla)
        {
            ReglasBL BL = new ReglasBL();
            return BL.ReglasInsBL(regla);
        }
        public string IReglasDel(BEReglas regla)
        {
            ReglasBL BL = new ReglasBL();
            return BL.ReglasDelBL(regla);
        }
        public List<BEReglas> IGetCaracteresEspecialesBL()
        {
            ReglasBL BL = new ReglasBL();
            return BL.GetCaracteresEspecialesBL();
        }
        /*Transaction*/
        public string IReglasLisIns(List<BEReglas> regla)
        {
            ReglasBL BL = new ReglasBL();
            return BL.ReglasLisInsBL(regla);
        }
        public List<BEReglas> IGetEspeciales()
        {
            ReglasBL BL = new ReglasBL();
            return BL.GetEspecialesBL();
        }
    }
}