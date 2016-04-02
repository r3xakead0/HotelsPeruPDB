using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SummitPDB.BusinessEntities;
using SummitPDB.DataAccess;

namespace SummitPDB.BusinessLogic
{
    public class PeriodosBL
    {
        public List<BEPeriodoEmpresa> GetPeriodosBL(BEUser user)
        {
            PeriodosDA getPeriodos = new PeriodosDA();
            return getPeriodos.GetPeriodosEmpresa(user);
        }

        public List<BEPeriodo_Mant> GetPeriodosBL(BEPeriodo_Mant objPer)
        {
            PeriodosDA getPeriodos = new PeriodosDA();
            return getPeriodos.GetPeriodos(objPer);
        }

        public string ValidateBL()
        {
            PeriodosDA validatePeriodo = new PeriodosDA();
            return validatePeriodo.validatePeriodo();
        }
        public string UpdatePeriodoLocalBL(BEPeriodoEmpresa periodos)
        {
            PeriodosDA validatePeriodo = new PeriodosDA();
            return validatePeriodo.UpdatePeriodoLocal(periodos);
        }
        //renzo luareano miura 30/01/2012


        public String IGetPeriodosEmpresa_Actualizar_Estado(Int64 anio, Int64 mes, Int64 Local, Int64 Est)
        {
            PeriodosDA getPeriodosBL = new PeriodosDA();

            return getPeriodosBL.PERIODOEMPRESA_ACTUALIZAR_ESTADOS(anio, mes, Local, Est);
        }
        public String IGetPeriodos_Actualizar_Estado(Int64 anio, Int64 mes, Int64 Est)
        {
            PeriodosDA getPeriodosBL = new PeriodosDA();

            return getPeriodosBL.PERIODO_ACTUALIZAR_ESTADOS(anio, mes, Est);
        }

        public String IGetPeriodos_Creacion(Int64 anio)
        {
            PeriodosDA getPeriodosBL = new PeriodosDA();

            return getPeriodosBL.CREAR_PERIODOS(anio);
        }
        public List<BEPeriodoEmpresa_Mant> GetPeriodosEmpresaBL_Localanio(Int64 anio, Int64 Local)
        {
            PeriodosDA getPeriodos = new PeriodosDA();
            return getPeriodos.GET_PERIODOSEMPRESA_LOCALANIO(anio, Local);
        }
        public List<BEPeriodoEmpresa_Mant> GetPeriodosEmpresaBL_MANT(Int64 anio, Int64 mes)
        {
            PeriodosDA getPeriodos = new PeriodosDA();
            return getPeriodos.GET_PERIODOSEMPRESA_MANT(anio, mes);
        }
        public List<BEPeriodo_Mant> GetPeriodosBL_MANT(Int64 anio)
        {
            PeriodosDA getPeriodos = new PeriodosDA();
            return getPeriodos.GET_PERIODOS_MANT(anio);
        }
        //renzo luareano miura 30/01/2012
    }
}