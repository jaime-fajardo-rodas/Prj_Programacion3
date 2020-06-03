using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Timers;

namespace Prj_ProcesamientoDocumentos_CCB_JFR
{
    public class ArchivosCSV
    {
        public static Cola colaBaja = new Cola();
        public static Cola colaMedia = new Cola();
        public static Cola colaAlta = new Cola();
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

                ListaSimple.ListaEnlazadaSimple listCabecera = new ListaSimple.ListaEnlazadaSimple();

                ListaSimple.ListaEnlazadaSimple listContenido = new ListaSimple.ListaEnlazadaSimple();

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
                            listCabecera.AgregarElementoAlFinal(cabecera);
                        }
                    }
                    else
                    {
                        foreach (var contenido in archivo)
                        {
                            listContenido.AgregarElementoAlFinal(contenido);
                        }
                    }
                }

                listCabecera.imprimir();
                listContenido.imprimir();

                contador = 0;
                file.Close();

                for (int xml = 0; xml < listCabecera.CantidadElementos(); xml++)
                {
                    estructura += "\t<" + listCabecera.imprimirPosicion(xml) + ">" + listContenido.imprimirPosicion(xml) + "</" + listCabecera.imprimirPosicion(xml) + "> \n";
                }

                Canonico objetDocument = ObjetoCanonico(listCabecera.CantidadElementos(), listContenido, etiqueta);

                estructura += "</" + etiqueta + "> ";
                Console.WriteLine(estructura);

                namefiles++;
                String fechaCompleta = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
                if (A1)
                {
                    System.IO.File.WriteAllText(direcXML.FullName + "XML_SOLI/" + etiqueta + fechaCompleta + ".xml", estructura);
                }
                else if (A2)
                {
                    System.IO.File.WriteAllText(direcXML.FullName + "XML_SOLCANMA/" + etiqueta + fechaCompleta + ".xml", estructura);
                }
                else if (A3)
                {
                    System.IO.File.WriteAllText(direcXML.FullName + "XML_SOLCREES/" + etiqueta + fechaCompleta + ".xml", estructura);
                }
                else if (A4)
                {
                    System.IO.File.WriteAllText(direcXML.FullName + "XML_SOLGRA/" + etiqueta + fechaCompleta + ".xml", estructura);
                }
                else if (A5)
                {
                    System.IO.File.WriteAllText(direcXML.FullName + "XML_SOLMAAC/" + etiqueta + fechaCompleta + ".xml", estructura);
                }
                else if (A6)
                {
                    System.IO.File.WriteAllText(direcXML.FullName + "XML_SOLMAFI/" + namefiles + fechaCompleta + ".xml", estructura);
                }

                File.Delete(direcCSV.FullName + fi.Name);

                encolarPrioridad(objetDocument);

                estructura = null;

                var stopwatch = Stopwatch.StartNew();
                Thread.Sleep(3000);
                stopwatch.Stop();

            }
        }

        public static Canonico ObjetoCanonico(int columnas, ListaSimple.ListaEnlazadaSimple lista, string etiqueta)
        {
            Canonico canonico = new Canonico();

            canonico.Tipo_documento = etiqueta;
            canonico.Id = int.Parse(lista.imprimirPosicion(0));
            canonico.Fecha = lista.imprimirPosicion(1);
            canonico.Carrera = lista.imprimirPosicion(2);
            canonico.Nombres = lista.imprimirPosicion(3);
            canonico.Apellidos = lista.imprimirPosicion(4);
            canonico.Identificacion = int.Parse(lista.imprimirPosicion(5));

            if (etiqueta.Equals("SOLI"))
            {
                canonico.Modalidad = lista.imprimirPosicion(6);
                canonico.Semestre = lista.imprimirPosicion(7);
            }
            else if (etiqueta.Equals("SOLCANMA"))
            {
                canonico.Motivo_cancelacion = lista.imprimirPosicion(6);
            }
            else if (etiqueta.Equals("SOLCREES"))
            {
                canonico.Celular = long.Parse(lista.imprimirPosicion(6));
                canonico.Correo = lista.imprimirPosicion(7);
                canonico.Direccion = lista.imprimirPosicion(8);
                canonico.Edad = int.Parse(lista.imprimirPosicion(9));
                canonico.Carnet = lista.imprimirPosicion(10);
                canonico.Jornada = lista.imprimirPosicion(11);
                canonico.Sede = lista.imprimirPosicion(12);
            }
            else if (etiqueta.Equals("SOLGRA"))
            {
                canonico.Tipo_graducacion = lista.imprimirPosicion(6);
                canonico.Historia_academica = lista.imprimirPosicion(7);
                canonico.Historico_notas = lista.imprimirPosicion(8);
                canonico.Pago_derechos = lista.imprimirPosicion(9);
            }
            else if (etiqueta.Equals("SOLMAFI"))
            {
                canonico.Forma_pago = lista.imprimirPosicion(6);
                canonico.Periodo_academico = lista.imprimirPosicion(7);
                canonico.Total_pagar = int.Parse(lista.imprimirPosicion(8));
                canonico.Descuentos = int.Parse(lista.imprimirPosicion(9));
                canonico.Total_liquidado = int.Parse(lista.imprimirPosicion(10));
            }
            else if (etiqueta.Equals("SOLMAAC"))
            {
                canonico.Materias = lista.imprimirPosicion(6);
                canonico.Docentes = lista.imprimirPosicion(7);
                canonico.Horario = lista.imprimirPosicion(8);
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