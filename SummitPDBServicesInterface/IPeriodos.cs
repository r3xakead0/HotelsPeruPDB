using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SummitPDB.BusinessLogic;
using SummitPDB.BusinessEntities;

namespace SummitPDB.ServicesInterface
{
    public class IPeriodos
    {
        public List<BEPeriodoEmpresa> IGetPeriodos(BEUser user)
        {
            PeriodosBL getPeriodosBL = new PeriodosBL();

            return getPeriodosBL.GetPeriodosBL(user);
        }

        public List<BEPeriodo_Mant> IGetPeriodos(BEPeriodo_Mant user)
        {
            PeriodosBL getPeriodosBL = new PeriodosBL();

            return getPeriodosBL.GetPeriodosBL(user);
        }

        public string IValPeriodo()
        {
            PeriodosBL valPeriodo = new PeriodosBL();
            return valPeriodo.ValidateBL();
        }
        public string IUpdatePeriodoLocal(BEPeriodoEmpresa periodos)
        {
            PeriodosBL updPeriodo = new PeriodosBL();
            return updPeriodo.UpdatePeriodoLocalBL(periodos);
        }

        //
        //Modificaciones realizadas por renzo laureano 29/11/2012
        //
        public List<BEPeriodoEmpresa_Mant> IGetPeriodosEmpresa_Localanio(Int64 anio, Int64 Local)
        {
            PeriodosBL getPeriodosBL = new PeriodosBL();

            return getPeriodosBL.GetPeriodosEmpresaBL_Localanio(anio, Local);
        }
        public List<BEPeriodoEmpresa_Mant> IGetPeriodosEmpresa_MANT(Int64 anio, Int64 mes)
        {
            PeriodosBL getPeriodosBL = new PeriodosBL();

            return getPeriodosBL.GetPeriodosEmpresaBL_MANT(anio, mes);
        }
        public String IGetPeriodos_Actualizar_Estados(Int64 anio, Int64 mes, Int64 Est)
        {
            PeriodosBL getPeriodosBL = new PeriodosBL();

            return getPeriodosBL.IGetPeriodos_Actualizar_Estado(anio, mes, Est);
        }
        public String IGetPeriodosEmpresa_Actualizar_Estados(Int64 anio, Int64 mes, Int64 local, Int64 Est)
        {
            PeriodosBL getPeriodosBL = new PeriodosBL();

            return getPeriodosBL.IGetPeriodosEmpresa_Actualizar_Estado(anio, mes, local, Est);
        }
        public String IGetPeriodos_Creacion(Int64 anio)
        {
            PeriodosBL getPeriodosBL = new PeriodosBL();

            return getPeriodosBL.IGetPeriodos_Creacion(anio);
        }
        public List<BEPeriodo_Mant> IGetPeriodos_MANT(Int64 anio)
        {
            PeriodosBL getPeriodosBL = new PeriodosBL();

            return getPeriodosBL.GetPeriodosBL_MANT(anio);
        }
        //
        //Modificaciones realizadas por renzo laureano 29/11/2012
        //
    }
}