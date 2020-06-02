using System;
using System.Collections.Generic;
using System.IO;
using System.Timers;

namespace Prj_ProcesamientoDocumentos_CCB_JFR
{
    public class ArchivosCSV
    {
        public static Cola colaBaja = new Cola();
        public static Cola colaMedia = new Cola();
        public static Cola colaAlta = new Cola();
        public static void GenerarXML(Object source, ElapsedEventArgs e)
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

                contador = 0;
                file.Close();
                string[] arryHead = array_cabecera.ToArray();
                string[] arryBody = array_informacion.ToArray();


                for (int xml = 0; xml < arryHead.Length; xml++)
                {
                    estructura += "\t<" + arryHead[xml] + ">" + arryBody[xml] + "</" + arryHead[xml] + "> \n";
                }

                Canonico objetDocument = objetoCanonico(arryHead.Length, arryBody,etiqueta);

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

                File.Delete(direcCSV.FullName + fi.Name);

                encolarPrioridad(objetDocument);

                estructura = null;
            }

        }

        public static Canonico objetoCanonico(int columnas, string[] lista, string etiqueta)
        {
            Canonico canonico = new Canonico();

            canonico.Tipo_documento = etiqueta;
            canonico.Id = int.Parse(lista[0]);
            canonico.Fecha = lista[1];
            canonico.Carrera = lista[2];
            canonico.Nombres = lista[3];
            canonico.Apellidos = lista[4];
            canonico.Identificacion = int.Parse(lista[5]);

            if (etiqueta.Equals("SOLI"))
            {
                canonico.Modalidad = lista[6];
                canonico.Semestre = lista[7];
            }
            else if (etiqueta.Equals("SOLCANMA"))
            {
                canonico.Motivo_cancelacion = lista[6];
            }
            else if (etiqueta.Equals("SOLCREES"))
            {
                canonico.Celular = long.Parse(lista[6]);
                canonico.Correo = lista[7];
                canonico.Direccion = lista[8];
                canonico.Edad = int.Parse(lista[9]);
                canonico.Carnet = lista[10];
                canonico.Jornada = lista[11];
                canonico.Sede = lista[12];
            }
            else if (etiqueta.Equals("SOLGRA"))
            {
                canonico.Tipo_graducacion = lista[6];
                canonico.Historia_academica = lista[7];
                canonico.Historico_notas = lista[8];
                canonico.Pago_derechos = lista[9];
            }
            else if (etiqueta.Equals("SOLMAFI"))
            {
                canonico.Forma_pago = lista[6];
                canonico.Periodo_academico = lista[7];
                canonico.Total_pagar = int.Parse(lista[8]);
                canonico.Descuentos = int.Parse(lista[9]);
                canonico.Total_liquidado = int.Parse(lista[10]);
            }
            else if (etiqueta.Equals("SOLMAAC"))
            {
                canonico.Materias = lista[6];
                canonico.Docentes = lista[7];
                canonico.Horario = lista[8];
            }
            
            return canonico;
        }

        public static void encolarPrioridad(Canonico canonico)
        {
            string tipo_codumento = canonico.Tipo_documento;

            if (tipo_codumento.Equals("SOLCANMA"))
            {
                colaBaja.Encolar(canonico);
            }
            else if (tipo_codumento.Equals("SOLGRA") || tipo_codumento.Equals("SOLCREES"))
            {
                colaMedia.Encolar(canonico);
            }
            else if (tipo_codumento.Equals("SOLI") || tipo_codumento.Equals("SOLMAFI") || tipo_codumento.Equals("SOLMAAC"))
            {
                colaAlta.Encolar(canonico);
            }

        }

    }
}
