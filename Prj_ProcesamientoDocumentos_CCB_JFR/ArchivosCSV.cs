using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Prj_ProcesamientoDocumentos_CCB_JFR
{
    public class ArchivosCSV
    {
        
        public static void GenerarXML()
        {

            int contador = 0;

            string line;

            DirectoryInfo direcCSV = new DirectoryInfo("./../../Documentos/CarpetaComun/");
            DirectoryInfo direcXML = new DirectoryInfo("./../../Documentos/CarpetaSeguimiento/");

            string etiqueta = "";

            int namefiles = 0;

            foreach (var fi in direcCSV.GetFiles())
            {
                List<string> array_cabecera = new List<string>();

                List<string> array_informacion = new List<string>();

                bool A1 = fi.Name.Contains("SOLI");
                bool A2 = fi.Name.Contains("SOLCANMA");
                bool A3 = fi.Name.Contains("SOLCREES");
                bool A4 = fi.Name.Contains("SOLGRA");
                bool A5 = fi.Name.Contains("SOLMAAC");
                bool A6 = fi.Name.Contains("SOLMAFI");

                if (A1)
                {
                    etiqueta = "SOLI";
                }
                    else if (A2)
                    {
                        etiqueta = "SOLCANMA";
                    }
                        else if (A3)
                        {
                            etiqueta = "SOLCREES";
                        }

                            else if (A4)
                            {
                                etiqueta = "SOLGRA";
                            }
                                else if (A5)
                                {
                                    etiqueta = "SOLMAAC";
                                }
                                    else if (A6)
                                    {
                                        etiqueta = "SOLMAFI";
                                    }

                string estructura = "<" + etiqueta + "> \n";



                System.IO.StreamReader file = new System.IO.StreamReader(direcCSV.FullName + fi.Name);
                Console.WriteLine(direcCSV.FullName + fi.Name);


                while ((line = file.ReadLine()) != null)
                {
                    contador++;

                    var archivo = line.Split(';');
                    if (contador == 1)
                    {
                        foreach (var cabecera in archivo)
                        {
                            array_cabecera.Add(cabecera);
                            Console.WriteLine(array_cabecera);
                        }
                    }
                    else
                    {
                        foreach (var contenido in archivo)
                        {
                            array_informacion.Add(contenido);
                            Console.WriteLine(array_informacion);
                        }
                    }


                }

                Console.WriteLine(String.Join(",", array_cabecera));
                Console.WriteLine(String.Join(",", array_informacion));
                Console.ReadLine();

                contador = 0;
                file.Close();
                string[] arryHead = array_cabecera.ToArray();
                string[] arryBody = array_informacion.ToArray();


                for (int xml = 0; xml < arryHead.Length; xml++)
                {
                    estructura += "\t<" + arryHead[xml] + ">" + arryBody[xml] + "</" + arryHead[xml] + "> \n";

                }


                estructura += "</" + etiqueta + "> ";
                Console.WriteLine(estructura);
                namefiles++;

                if (A1)
                {
                    System.IO.File.WriteAllText(direcXML.FullName + "XML_SOLI/" + etiqueta + ".xml", estructura);
                }
                    else if (A2)
                    {
                        System.IO.File.WriteAllText(direcXML.FullName + "XML_SOLCANMA/" + etiqueta + ".xml", estructura);
                    }
                        else if (A3)
                        {
                            System.IO.File.WriteAllText(direcXML.FullName + "XML_SOLCREES/" + etiqueta + ".xml", estructura);
                        }
                            else if (A4)
                            {
                                System.IO.File.WriteAllText(direcXML.FullName + "XML_SOLGRA/" + etiqueta + ".xml", estructura);
                            }
                                else if (A5)
                                {
                                    System.IO.File.WriteAllText(direcXML.FullName + "XML_SOLMAAC/" + etiqueta + ".xml", estructura);
                                }
                                    else if (A6)
                                    {
                                        System.IO.File.WriteAllText(direcXML.FullName + "XML_SOLMAFI/" + namefiles + ".xml", estructura);
                                    }
                estructura = null;

            }

        }
    }
}
