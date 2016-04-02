using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace appWin_Copias
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> Errors = new List<string>();
            try
            {
                Properties.Settings props = new Properties.Settings();
                string[] AllfilePathsOrigen = Directory.GetFiles(@props.rutaOrigen, "l4*.txt");

                foreach (string strPath in AllfilePathsOrigen)
                {
                    try
                    {
                     //   throw new Exception("algo paso");
                        string fileName = strPath.Substring(@props.rutaOrigen.Length + 1);
                        string Extension = fileName.Substring(fileName.Length - 4);
                        string OnlyName = fileName.Substring(0, fileName.Length - 4);
                        string currName = fileName;

                        //-------------------------Por confirmar
                        //Int32 index = 0;
                        //Boolean exis = false;
                        //while (File.Exists(Path.Combine(@props.rutaDestino, fileName)))
                        //{
                        //    exis = true;
                        //    index++;
                        //    OnlyName = OnlyName.Replace(" (" + index.ToString() + ")", "");
                        //    fileName = OnlyName + " (" + index + ")" + Extension;
                        //}
                        //if (exis)
                        //    File.Move(Path.Combine(@props.rutaOrigen, currName), Path.Combine(@props.rutaOrigen, fileName));
                        //-----------------------
                        if (File.Exists(Path.Combine(@props.rutaDestino, fileName))) 
                            throw new Exception("Ya existe el archivo");
                        File.Copy(Path.Combine(@props.rutaOrigen, fileName), Path.Combine(@props.rutaDestino, fileName));
                    }
                    catch (Exception ex)
                    {                        
                        Errors.Add("  - archivo " + strPath.Substring(@props.rutaOrigen.Length + 1) + " : " + ex.Message);
                    }
                }
                if (Errors.Count > 0) {
                    Errors.Insert(0, "Error al copiar, ver detalle abajo");
                    throw new Exception(""); 
                }
            }
            catch (Exception ex)
            {
                if (Errors.Count == 0)
                    Console.WriteLine(ex.Message);
                else
                    foreach (string strerr in Errors)
                    {
                        Console.WriteLine(strerr);
                    }
                Console.ReadLine();
            }
        }
    }
}
