using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SummitPDB.ServicesInterface;
using SummitPDB.BusinessEntities;

namespace appWin_PDB
{
    class Program
    {
        protected static int origRow;
        protected static int origCol;

        protected static void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(origCol + x, origRow + y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }
        static void Main(string[] args)
        {

            Properties.Settings props = new Properties.Settings();
            List<string> Errors = new List<string>();
            int intVentas = 0, intCompras = 0, intHospedaje = 0, intTipoCambio = 0,
                intErrVentas = 0, intErrCompras = 0, intErrHospedaje = 0, intErrTipoCambio = 0;
            try
            {

                string[] AllfilePaths = Directory.GetFiles(@props.strRuta, "*.txt", SearchOption.AllDirectories);

                //crea el folder del bu
                string destinoBU = Path.Combine(@props.strRutaResults, "BUCargas", DateTime.Now.ToString("yyyy_MM_dd"));

                Int32 counExis = 0;

                if (!Directory.Exists(destinoBU)) Directory.CreateDirectory(destinoBU);
                else
                {
                    while (Directory.Exists(destinoBU))
                    {
                        //destinoBU = destinoBU.Substring(0, destinoBU.Length - counExis.ToString().Length - 1);
                        destinoBU = destinoBU.Replace("(" + counExis.ToString() + ")", "");
                        counExis++;
                        destinoBU = destinoBU + "(" + counExis.ToString() + ")";
                    }
                    Directory.CreateDirectory(destinoBU);
                }
                //
                BEUser user = new BEUser();
                user.UserName = props.strUsuario;
                user.UserPassword = props.strpw;
                IUsers iUsers = new IUsers();

                user = iUsers.IvalidateLoguinUser(user);

                Console.Write(string.Format("\r{0} archivos en total", AllfilePaths.Length.ToString()));
                int total = 0;
                int restante = AllfilePaths.Length;
                foreach (string strPath in AllfilePaths)
                {

                    total++;
                    restante--;
                    Console.Write(string.Format("\r Procesando {0} de {2} ({1}%)",
                                                total.ToString("0000"),
                                                ((int)(Convert.ToDecimal(AllfilePaths.Length - restante) / Convert.ToDecimal(AllfilePaths.Length) * 100)).ToString(),
                                                AllfilePaths.Length)
                                 );

                    string[] nombreArchivo = strPath.Split('\\');
                    int index = nombreArchivo.Length - 1;
                    IImportarArchivos IService = new IImportarArchivos();
                    string strRespuesta;

                    try
                    {
                        if (nombreArchivo[index].Substring(0, 1).ToUpper().Equals("C"))
                        {
                            strRespuesta = IService.IComprasImportar(strPath, user);
                            if (strRespuesta.Substring(0, 1) == "1")
                                intCompras++;
                            else
                            {
                                intErrCompras++;
                                throw new Exception(strRespuesta.Split('|')[1]);
                            }
                        }
                        else if (nombreArchivo[index].Substring(0, 1).ToUpper().Equals("V"))
                        {
                            strRespuesta = IService.IVentasImportar(strPath, user);
                            if (strRespuesta.Substring(0, 1) == "1")
                                intVentas++;
                            else
                            {
                                intErrVentas++;
                                throw new Exception(strRespuesta.Split('|')[1]);
                            }
                        }
                        else if (nombreArchivo[index].Substring(0, 1).ToUpper().Equals("T"))
                        {
                            strRespuesta = IService.ITipo_CambioImportar(strPath, user);
                            if (strRespuesta.Substring(0, 1) == "1")
                                intTipoCambio++;
                            else
                            {
                                intErrTipoCambio++;
                                throw new Exception(strRespuesta.Split('|')[1]);
                            }
                        }
                        else if (nombreArchivo[index].Substring(0, 1).ToUpper().Equals("L"))
                        {
                            strRespuesta = IService.IHospedajeImportar(strPath, user);
                            if (strRespuesta.Substring(0, 1) == "1")
                                intHospedaje++;
                            else
                            {
                                intErrHospedaje++;
                                throw new Exception(strRespuesta.Split('|')[1]);
                            }
                        }
                        else
                            throw new Exception("Archivo irreconocible");
                    }
                    catch (Exception ex)
                    {
                        Errors.Add("  - archivo " + nombreArchivo[index] + " : " + ex.Message);
                    }
                    finally
                    {
                        File.Move(strPath, Path.Combine(destinoBU, nombreArchivo[index]));
                    }
                }

                if (Errors.Count > 0) throw new Exception("");

                Console.WriteLine(" ---Carga satisfactoria, se cargaron: ");
            }
            catch (Exception ex)
            {
                string destinoBU = Path.Combine(@props.strRutaResults, "LogCargas");
                if (!Directory.Exists(destinoBU)) Directory.CreateDirectory(destinoBU);
                if (Errors.Count == 0)
                {
                    Console.WriteLine(" ---Carga fallida: ");

                    Console.WriteLine(ex.Message);
                    using (StreamWriter strLog = File.CreateText(Path.Combine(destinoBU, "log_" + DateTime.Now.ToString("yyyy_MM_dd") + ".txt")))
                    {

                        strLog.WriteLine(ex.Message);
                        
                    }
                }
                else
                {


                    Console.WriteLine(" ---Carga con errores, ver archivo log: ");

                    using (StreamWriter strLog = File.CreateText(Path.Combine(destinoBU, "log_" + DateTime.Now.ToString("yyyy_MM_dd") + ".txt")))
                    {
                        foreach (string strerr in Errors)
                        {
                            strLog.WriteLine(strerr);
                        }
                    }
                }
            }
            finally
            {
                WriteAt(string.Format("VENTAS      {0} correctos", intVentas.ToString()), 2, 1);
                WriteAt(string.Format("COMPRAS     {0} correctos", intCompras.ToString()), 2, 2);
                WriteAt(string.Format("HOSPEDAJES  {0} correctos", intHospedaje.ToString()), 2, 3);
                WriteAt(string.Format("TIPO CAMBIO {0} correctos", intTipoCambio.ToString()), 2, 4);

                WriteAt(string.Format("{0} con Errores", intErrVentas.ToString()), 50, 1);
                WriteAt(string.Format("{0} con Errores", intErrCompras.ToString()), 50, 2);
                WriteAt(string.Format("{0} con Errores", intErrHospedaje.ToString()), 50, 3);
                WriteAt(string.Format("{0} con Errores", intErrTipoCambio.ToString()), 50, 4);
                System.Threading.Thread.Sleep(10000);
            }
        }
    }
}
