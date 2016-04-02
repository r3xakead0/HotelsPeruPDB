using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SummitPDB.BusinessEntities;
using SummitPDB.DataAccess;
using System.Text.RegularExpressions;

namespace SummitPDB.BusinessLogic
{
    public class HotelBL
    {
        HotelsDA DA = new HotelsDA();
        /*Select*/
        public List<BEHotel> GetHotelsBL(BEHotel BEHotel)
        {
            return DA.GetHotels(BEHotel);
        }
        public string SetNotaCredito(string xSerieNC, string xCorrNC, string xSerieF, string xCorrF, string xfechaF)
        {
            return DA.SetNotaCredito(xSerieNC, xCorrNC, xSerieF, xCorrF, xfechaF);
        }
        public List<BEHotel> GetHotelsAll(string codLocal)
        {
            return DA.GetHotelsAll(codLocal);
        }
        public List<BEHotel> GetHotelsValidadosBL(BEHotel BEHotel)
        {
            return DA.GetHotelsValidados(BEHotel);
        }
        /*Insert*/
        public string InsHotels(BEHotel BEHotel)
        {
            return DA.InsHotels(BEHotel);
        }
        /*Update*/
        public string UpdHotels(BEHotel BEHotel)
        {
            return DA.UpdHotels(BEHotel);
        }
        /*Delete*/
        public string DelHotels(BEHotel BEHotel)
        {
            return DA.DelHotels(BEHotel);
        }
        /*Delete Group*/
        public string DelHotelsGroup(BEHotel BEHotel)
        {
            return DA.DelHotelsGroup(BEHotel);
        }
        public string ValUsuarioVentas(BEHotel BEHotel)
        {
            return DA.ValUsuarioVentas(BEHotel);
        }
        public string getImponible(BEHotel beHotel, string tipo)
        {
            return DA.GetImponible(beHotel, tipo);
        }
        public string getUnidad(BEHotel beHotel)
        {
            return DA.GetUnidad(beHotel);
        }
        public string getNumeroDocumento(BEHotel beHotel, string tipo)
        {
            return DA.GetNumeroDocumento(beHotel,tipo);
        }
        public string GetIGVVentas(BEHotel beHotel)
        {
            return DA.GetIGVVentas(beHotel);
        }
        public string GetIGVCompras(BEHotel beHotel)
        {
            return DA.GetIGVCompras(beHotel);
        }
        public List<BEHotel> GetporCorrelativo(BEHotel beHotel)
        {
            return DA.GetHotelsporCorrelativo(beHotel);
        }
        public List<BEHotel> GetHotelsAnteriores(BEHotel beHotel)
        {
            return DA.GetHotelsAnteriores(beHotel);
        }
        public string HotelsDuplicateINS(List<BEHotel> beHotel)
        {
            return DA.INSListHotelsDuplicate(beHotel);
        }
        /**/
        public List<string> validarCaracteres(List<BEHotel> lstRegistros)
        {
            List<string> lstErrores = new List<string>();
            List<BEReglas> lstReglas = new List<BEReglas>();
            List<BEReglas> lstCaracteres = new List<BEReglas>();
            ReglasDA DARegla = new ReglasDA();
            BEHotel valida = new BEHotel();
            string mensaje = string.Empty;
            int linea = 1;
            //lstReglas = DARegla.GetEspeciales();
            lstReglas = DARegla.GetCaracteresEspeciales();
            lstCaracteres = DARegla.GetNoEspeciales();
            int LineaAnte = 0;
            int Flag_val = 0;
            foreach (BEHotel beHotel in lstRegistros)
            {
                Flag_val = int.Parse(beHotel.flagValidacion);
                //LineaAnte = Convert.ToInt32(DARegla.VlidarHospedajeAnterior(beHotel.idHospedaje, beHotel.fechaDocumento));
                valida = DARegla.VlidarHospedajeAnterior(beHotel.idHospedaje, beHotel.fechaDocumento,beHotel.correlativo);
                if (valida != null)
                {
                    if (Convert.ToInt32(valida.respuesta) > 0 && Flag_val == 0)
                    {
                        mensaje = "Linea " + beHotel.idHospedaje + " - El usuario tiene un ingreso en un lapso de 15 dias en la linea: " + valida.idHospedaje + " correspondiente a la fecha: " + valida.fechaDocumento;
                        lstErrores.Add(mensaje);
                    }
                }


                if (beHotel.serie == null || beHotel.serie == string.Empty)
                {
                    mensaje = "Linea " + beHotel.idHospedaje + " - No encuentra el número de serie";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beHotel.serie.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beHotel.idHospedaje + " - El campo Serie tiene el caracter especial " + especiales.caracter;
                        lstErrores.Add(mensaje);
                    }
                }
                //foreach (BEReglas caracter in lstCaracteres)
                //{
                //    if (!beHotel.serie.Contains(caracter.caracter))
                //    {
                //        mensaje = "Linea " + beHotel.idHospedaje + " - El campo Serie no reconoce el caracter " + caracter.caracter;
                //        lstErrores.Add(mensaje);
                //    }
                //}

                if (beHotel.correlativo == null || beHotel.correlativo == string.Empty)
                {
                    mensaje = "Linea " + beHotel.idHospedaje + " - No encuentra el correlativo";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beHotel.correlativo.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beHotel.idHospedaje + " - El campo correlativo tiene el caracter especial " + especiales.caracter;
                        lstErrores.Add(mensaje);
                    }
                }

                //foreach (BEReglas caracter in lstCaracteres)
                //{
                //    if (!beHotel.correlativo.Contains(caracter.caracter))
                //    {
                //        mensaje = "Linea " + beHotel.idHospedaje + " - El campo correlativo no reconoce el caracter " + caracter.caracter;
                //        lstErrores.Add(mensaje);
                //    }
                //}
                
                //if ((beHotel.ruc != null || beHotel.ruc.Trim() != string.Empty))
                if (!string.IsNullOrEmpty(beHotel.ruc.Trim()))
                {
                    if ((beHotel.agencia == null || beHotel.agencia.Trim() == string.Empty))
                    {
                        mensaje = "Linea " + beHotel.idHospedaje + " - Existe el numero de ruc pero no existe la agencia.";
                        lstErrores.Add(mensaje);
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(beHotel.agencia.Trim()))
                    {
                        mensaje = "Linea " + beHotel.idHospedaje + " - Existe la agencia pero no existe el numero de ruc.";
                        lstErrores.Add(mensaje);
                    }
                }
                //foreach (BEReglas especiales in lstReglas)
                //{
                //    if (beHotel.ruc.Contains(especiales.equivalence))
                //    {
                //        mensaje = "Linea " + beHotel.idHospedaje + " - El campo RUC tiene el caracter especial " + especiales.equivalence;
                //        lstErrores.Add(mensaje);
                //    }
                //}

                //if (beHotel.agencia == null || beHotel.agencia == string.Empty)
                //{
                //    mensaje = "Linea " + beHotel.idHospedaje + " - No encuentra la agencia";
                //    lstErrores.Add(mensaje);
                //}
                //foreach (BEReglas especiales in lstReglas)
                //{
                //    if (beHotel.agencia.Contains(especiales.caracter))
                //    {
                //        mensaje = "Linea " + beHotel.idHospedaje + " - El campo Agencia tiene el caracter especial " + especiales.caracter;
                //        lstErrores.Add(mensaje);
                //    }
                //}
                //foreach (BEReglas caracter in lstCaracteres)
                //{
                //    if (!beHotel.agencia.Contains(caracter.caracter))
                //    {
                //        mensaje = "Linea " + beHotel.idHospedaje + " - El campo agencia no reconoce el caracter " + caracter.caracter;
                //        lstErrores.Add(mensaje);
                //    }
                //}

                if (beHotel.pasaporte == null || beHotel.pasaporte == string.Empty)
                {
                    mensaje = "Linea " + beHotel.idHospedaje + " - No encuentra el pasaporte";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beHotel.pasaporte.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beHotel.idHospedaje + " - El campo Pasaporte tiene el caracter especial " + especiales.caracter;
                        lstErrores.Add(mensaje);
                    }
                }

                //foreach (BEReglas caracter in lstCaracteres)
                //{
                //    if (!beHotel.pasaporte.Contains(caracter.caracter))
                //    {
                //        mensaje = "Linea " + beHotel.idHospedaje + " - El campo pasaporte no reconoce el caracter " + caracter.caracter;
                //        lstErrores.Add(mensaje);
                //    }
                //}
                if (beHotel.apellidoPaterno == null || beHotel.apellidoPaterno == string.Empty)
                {
                    mensaje = "Linea " + beHotel.idHospedaje + " - No encuentra el apellido paterno";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beHotel.apellidoPaterno.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beHotel.idHospedaje + " - El campo apellido paterno tiene el caracter especial " + especiales.caracter;
                        lstErrores.Add(mensaje);
                    }
                }

                //foreach (BEReglas caracter in lstCaracteres)
                //{
                //    if (!beHotel.apellidoPaterno.Contains(caracter.caracter))
                //    {
                //        mensaje = "Linea " + beHotel.idHospedaje + " - El campo apellido paterno no reconoce el caracter " + caracter.caracter;
                //        lstErrores.Add(mensaje);
                //    }
                //}
                if (beHotel.nombre == null || beHotel.nombre == string.Empty)
                {
                    mensaje = "Linea " + beHotel.idHospedaje + " - No encuentra el nombre";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beHotel.nombre.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beHotel.idHospedaje + " - El campo nombre tiene el caracter especial " + especiales.caracter;
                        lstErrores.Add(mensaje);
                    }
                }

                //foreach (BEReglas caracter in lstCaracteres)
                //{
                //    if (!beHotel.nombre.Contains(caracter.caracter))
                //    {
                //        mensaje = "Linea " + beHotel.idHospedaje + " - El campo nombre no reconoce el caracter " + caracter.caracter;
                //        lstErrores.Add(mensaje);
                //    }
                //}

                if (beHotel.paisPasaporte == null || beHotel.paisPasaporte == string.Empty)
                {
                    mensaje = "Linea " + beHotel.idHospedaje + " - No encuentra el pais pasaporte";
                    lstErrores.Add(mensaje);
                }
                else if (!Regex.IsMatch(beHotel.paisPasaporte, "^[a-zA-Z]+$"))
                {
                    mensaje = "Linea " + beHotel.idHospedaje + " - El campo pais pasaporte contiene números. ";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beHotel.paisPasaporte.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beHotel.idHospedaje + " - El campo pais pasaporte tiene el caracter especial " + especiales.caracter;
                        lstErrores.Add(mensaje);
                    }
                }
                //foreach (BEReglas caracter in lstCaracteres)
                //{
                //    if (!beHotel.paisPasaporte.Contains(caracter.caracter))
                //    {
                //        mensaje = "Linea " + beHotel.idHospedaje + " - El campo pais pasaporte no reconoce el caracter " + caracter.caracter;
                //        lstErrores.Add(mensaje);
                //    }
                //}

                if (beHotel.paisProcedencia == null || beHotel.paisProcedencia == string.Empty)
                {
                    mensaje = "Linea " + beHotel.idHospedaje + " - No encuentra el pais de procedencia";
                    lstErrores.Add(mensaje);
                }
                else if (!Regex.IsMatch(beHotel.paisProcedencia, "^[a-zA-Z]+$"))
                {
                    mensaje = "Linea " + beHotel.idHospedaje + " - El campo pais procedencia contiene números. ";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beHotel.paisProcedencia.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beHotel.idHospedaje + " - El campo pais procedencia tiene el caracter especial " + especiales.caracter;
                        lstErrores.Add(mensaje);
                    }
                }
                //foreach (BEReglas caracter in lstCaracteres)
                //{
                //    if (!beHotel.paisProcedencia.Contains(caracter.caracter))
                //    {
                //        mensaje = "Linea " + beHotel.idHospedaje + " - El campo pais procedencia no reconoce el caracter " + caracter.caracter;
                //        lstErrores.Add(mensaje);
                //    }
                //}
                if (beHotel.fechaIngresoHotel == null || beHotel.fechaIngresoHotel == string.Empty)
                {
                    mensaje = "Linea " + beHotel.idHospedaje + " - No encuentra la fecha de ingreso al hotel";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beHotel.fechaIngresoHotel.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beHotel.idHospedaje + " - El campo fecha ingreso a hotel tiene el caracter especial " + especiales.caracter;
                        lstErrores.Add(mensaje);
                    }
                }
                //foreach (BEReglas caracter in lstCaracteres)
                //{
                //    if (!beHotel.fechaIngresoHotel.Contains(caracter.caracter))
                //    {
                //        mensaje = "Linea " + beHotel.idHospedaje + " - El campo fecha ingreso a hotel no reconoce el caracter " + caracter.caracter;
                //        lstErrores.Add(mensaje);
                //    }
                //}
                if (beHotel.fechaSalidaHotel == null || beHotel.fechaSalidaHotel == string.Empty)
                {
                    mensaje = "Linea " + beHotel.idHospedaje + " - No encuentra la fecha de salida del hotel";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beHotel.fechaSalidaHotel.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beHotel.idHospedaje + " - El campo fecha de salida de hotel iene el caracter especial " + especiales.caracter;
                        lstErrores.Add(mensaje);
                    }
                }
                //foreach (BEReglas caracter in lstCaracteres)
                //{
                //    if (!beHotel.fechaSalidaHotel.Contains(caracter.caracter))
                //    {
                //        mensaje = "Linea " + beHotel.idHospedaje + " - El campo fecha salida hotel no reconoce el caracter " + caracter.caracter;
                //        lstErrores.Add(mensaje);
                //    }
                //}
                if (beHotel.nroFicha == null || beHotel.nroFicha == string.Empty)
                {
                    mensaje = "Linea " + beHotel.idHospedaje + " - No encuentra el número de ficha";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beHotel.nroFicha.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beHotel.idHospedaje + " - El campo número de ficha iene el caracter especial " + especiales.caracter;
                        lstErrores.Add(mensaje);
                    }
                }
                //foreach (BEReglas caracter in lstCaracteres)
                //{
                //    if (!beHotel.nroFicha.Contains(caracter.caracter))
                //    {
                //        mensaje = "Linea " + beHotel.idHospedaje + " - El campo numero de ficha no reconoce el caracter " + caracter.caracter;
                //        lstErrores.Add(mensaje);
                //    }
                //}
                //if (beHotel.x == null || beHotel.y == string.Empty)
                //{
                //    mensaje = "Linea " + beHotel.idHospedaje + " - No encuentra x";
                //    lstErrores.Add(mensaje);
                //}
                //foreach (BEReglas especiales in lstReglas)
                //{
                //    if (beHotel.x.Contains(especiales.caracter))
                //    {
                //        mensaje = "Linea " + beHotel.idHospedaje + " - El campo x tiene el caracter especial " + especiales.caracter;
                //        lstErrores.Add(mensaje);
                //    }
                //}
                //foreach (BEReglas caracter in lstCaracteres)
                //{
                //    if (!beHotel.x.Contains(caracter.caracter))
                //    {
                //        mensaje = "Linea " + beHotel.idHospedaje + " - El campo x no reconoce el caracter " + caracter.caracter;
                //        lstErrores.Add(mensaje);
                //    }
                //}


                //if (beHotel.unidad == null || beHotel.unidad == string.Empty)
                //{
                //    mensaje = "Linea " + beHotel.idHospedaje + " - No encuentra la unidad";
                //    lstErrores.Add(mensaje);
                //}
                //foreach (BEReglas especiales in lstReglas)
                //{
                //    if (beHotel.unidad.Contains(especiales.caracter))
                //    {
                //        mensaje = "Linea " + beHotel.idHospedaje + " - El campo unidad tiene el caracter especial " + especiales.caracter;
                //        lstErrores.Add(mensaje);
                //    }
                //}


                //foreach (BEReglas caracter in lstCaracteres)
                //{
                //    if (!beHotel.unidad.Contains(caracter.caracter))
                //    {
                //        mensaje = "Linea " + beHotel.idHospedaje + " - El campo unidad no reconoce el caracter " + caracter.caracter;
                //        lstErrores.Add(mensaje);
                //    }
                //}
                //if (beHotel.y == null || beHotel.y == string.Empty)
                //{
                //    mensaje = "Linea " + beHotel.idHospedaje + " - No encuentra la y";
                //    lstErrores.Add(mensaje);
                //}
                //foreach (BEReglas especiales in lstReglas)
                //{
                //    if (beHotel.y.Contains(especiales.caracter))
                //    {
                //        mensaje = "Linea " + beHotel.idHospedaje + " - El campo y tiene el caracter especial " + especiales.caracter;
                //        lstErrores.Add(mensaje);
                //    }
                //}

                //foreach (BEReglas caracter in lstCaracteres)
                //{
                //    if (!beHotel.y.Contains(caracter.caracter))
                //    {
                //        mensaje = "Linea " + beHotel.idHospedaje + " - El campo y no reconoce el caracter " + caracter.caracter;
                //        lstErrores.Add(mensaje);
                //    }
                //}
                if (beHotel.ingresoPais == null || beHotel.ingresoPais == string.Empty)
                {
                    mensaje = "Linea " + beHotel.idHospedaje + " - No encuentra la fecha ingreso a pais";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beHotel.ingresoPais.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beHotel.idHospedaje + " - El campo fecha ingreso a pais tiene el caracter especial " + especiales.caracter;
                        lstErrores.Add(mensaje);
                    }
                }
                //foreach (BEReglas caracter in lstCaracteres)
                //{
                //    if (!beHotel.ingresoPais.Contains(caracter.caracter))
                //    {
                //        mensaje = "Linea " + beHotel.idHospedaje + " - El campo ingreso pais no reconoce el caracter " + caracter.caracter;
                //        lstErrores.Add(mensaje);
                //    }
                //}

                linea++;
            }

            return lstErrores;
        }
        public List<BEHotel> aplicarReglas(List<BEHotel> lstRegistros)
        {
            List<BEHotel> lstListaActualizada = new List<BEHotel>();
            List<BEReglas> lstReglas = new List<BEReglas>();
            ReglasDA DARegla = new ReglasDA();

            lstReglas = DARegla.GetCaracteresEspeciales();

            foreach (BEHotel beHotel in lstRegistros)
            {
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beHotel.serie.Contains(especiales.caracter))
                    {
                        beHotel.serie = beHotel.serie.Replace(especiales.caracter, especiales.equivalence);
                    }
                }

                foreach (BEReglas especiales in lstReglas)
                {
                    if (beHotel.correlativo.Contains(especiales.caracter))
                    {
                        beHotel.correlativo = beHotel.correlativo.Replace(especiales.caracter, especiales.equivalence);
                    }
                }

                foreach (BEReglas especiales in lstReglas)
                {
                    if (beHotel.ruc.Contains(especiales.caracter))
                    {
                        beHotel.ruc = beHotel.ruc.Replace(especiales.equivalence, especiales.caracter);
                    }
                }

                foreach (BEReglas especiales in lstReglas)
                {
                    if (beHotel.agencia.Contains(especiales.caracter))
                    {
                        beHotel.agencia = beHotel.agencia.Replace(especiales.caracter, especiales.equivalence);
                    }
                }

                foreach (BEReglas especiales in lstReglas)
                {
                    if (beHotel.pasaporte.Contains(especiales.caracter))
                    {
                        beHotel.pasaporte = beHotel.pasaporte.Replace(especiales.caracter, especiales.equivalence);
                    }
                }

                foreach (BEReglas especiales in lstReglas)
                {
                    if (beHotel.apellidoPaterno.Contains(especiales.caracter))
                    {
                        beHotel.apellidoPaterno = beHotel.apellidoPaterno.Replace(especiales.caracter, especiales.equivalence);
                    }
                }

                foreach (BEReglas especiales in lstReglas)
                {
                    if (beHotel.nombre.Contains(especiales.caracter))
                    {
                        beHotel.nombre = beHotel.nombre.Replace(especiales.caracter, especiales.equivalence);
                    }
                }

                foreach (BEReglas especiales in lstReglas)
                {
                    if (beHotel.segundoNombre.Contains(especiales.caracter))
                    {
                        beHotel.segundoNombre = beHotel.segundoNombre.Replace(especiales.caracter, especiales.equivalence);
                    }
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beHotel.apellidoMaterno.Contains(especiales.caracter))
                    {
                        beHotel.apellidoMaterno = beHotel.apellidoMaterno.Replace(especiales.caracter, especiales.equivalence);
                    }
                }

                foreach (BEReglas especiales in lstReglas)
                {
                    if (beHotel.paisPasaporte.Contains(especiales.caracter))
                    {
                        beHotel.paisPasaporte = beHotel.paisPasaporte.Replace(especiales.caracter, especiales.equivalence);
                    }
                }

                foreach (BEReglas especiales in lstReglas)
                {
                    if (beHotel.paisProcedencia.Contains(especiales.caracter))
                    {
                        beHotel.paisProcedencia = beHotel.paisProcedencia.Replace(especiales.caracter, especiales.equivalence);
                    }
                }

                foreach (BEReglas especiales in lstReglas)
                {
                    if (beHotel.fechaIngresoHotel.Contains(especiales.caracter))
                    {
                        beHotel.fechaIngresoHotel = beHotel.fechaIngresoHotel.Replace(especiales.caracter, especiales.equivalence);
                    }
                }

                foreach (BEReglas especiales in lstReglas)
                {
                    if (beHotel.fechaIngresoHotel.Contains(especiales.caracter))
                    {
                        beHotel.fechaSalidaHotel = beHotel.fechaSalidaHotel.Replace(especiales.caracter, especiales.equivalence);
                    }
                }

                foreach (BEReglas especiales in lstReglas)
                {
                    if (beHotel.nroFicha.Contains(especiales.caracter))
                    {
                        beHotel.nroFicha = beHotel.nroFicha.Replace(especiales.caracter, especiales.equivalence);
                    }
                }

                foreach (BEReglas especiales in lstReglas)
                {
                    if (beHotel.x.Contains(especiales.caracter))
                    {
                        beHotel.x = beHotel.x.Replace(especiales.caracter, especiales.equivalence);
                    }
                }

                foreach (BEReglas especiales in lstReglas)
                {
                    if (beHotel.unidad.Contains(especiales.caracter))
                    {
                        beHotel.unidad = beHotel.unidad.Replace(especiales.caracter, especiales.equivalence);
                    }
                }

                foreach (BEReglas especiales in lstReglas)
                {
                    if (beHotel.y.Contains(especiales.caracter))
                    {
                        beHotel.y = beHotel.y.Replace(especiales.caracter, especiales.equivalence);
                    }
                }

                foreach (BEReglas especiales in lstReglas)
                {
                    if (beHotel.ingresoPais.Contains(especiales.caracter))
                    {
                        beHotel.ingresoPais = beHotel.ingresoPais.Replace(especiales.caracter, especiales.equivalence);
                    }
                }

                lstListaActualizada.Add(beHotel);
            }

            return lstListaActualizada;
        }

        public string UpdListHotels(List<BEHotel> lstHotels)
        {
            return DA.UpdListHotels(lstHotels);
        }
        public List<BEPais> GetPaises()
        {
            return DA.GetPaises();
        }

        public List<BEHotel> GetDocDistintos(BEHotel objBE)
        {
            return DA.GetDocDistintos(objBE);
        }

        public List<BEHotel> GetDocDistintosVentas(BEHotel objBE)
        {
            return DA.GetDocDistintosVentas(objBE);
        }
    }
}