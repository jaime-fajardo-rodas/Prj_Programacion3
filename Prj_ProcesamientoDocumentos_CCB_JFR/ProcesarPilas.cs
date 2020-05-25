using System;
using System.IO;


namespace Prj_ProcesamientoDocumentos_CCB_JFR
{
    public class ProcesarPilas
    {
        private Cola pilaAlta;
        private Cola pilaMedia;
        private Cola pilaBaja;
        public ProcesarPilas(Cola pilaAlta, Cola pilaMedia, Cola pilaBaja)
        {
            this.pilaAlta = pilaAlta;
            this.pilaMedia = pilaMedia;
            this.pilaBaja = pilaBaja;
        }
        public void ProcesarPilasPrioridades()
        {
            /*cantidad de documentos a procesar segun cada prioridad*/
            int DocPrioridadAlta = 3;
            int DocPrioridadMedia = 2;

            while (true)
            {
                
                if (DocPrioridadAlta > 0)
                {
                    /*se valida si la pilaAlta no esta vacia para procesar, si no se pasa a la siguiente prioridad*/
                    if (!pilaAlta.ColaVacia())
                    {
                        guardarArchivos(pilaAlta.Descolar());
                        Console.WriteLine("proceso documento prioridad alta");
                        DocPrioridadAlta--;
                    }
                    else
                    {
                        DocPrioridadAlta = 0;
                    }

                }
                else if (DocPrioridadMedia > 0)
                {
                    /*se valida si la pilaMedia no esta vacia para procesar, si no se pasa a la siguiente prioridad*/
                    if (!pilaMedia.ColaVacia())
                    {
                        guardarArchivos(pilaMedia.Descolar());
                        Console.WriteLine("proceso documento prioridad media");
                        DocPrioridadMedia--;
                    }
                    else
                    {
                        DocPrioridadMedia = 0;
                    }
                }
                else
                {
                    /*se valida si la pilaBaja no esta vacia para procesar, si no se pasa a la siguiente prioridad*/
                    if (!pilaBaja.ColaVacia())
                    {
                        guardarArchivos(pilaBaja.Descolar());
                        Console.WriteLine("proceso documento prioridad baja");
                    }

                    DocPrioridadAlta = 3;
                    DocPrioridadMedia = 2;
                }
            }

        }

        public void guardarArchivos(Canonico can)
        {

            String tipoDocumento = can.Tipo_documento;

            /*se debe crear variable nombre archivo que deberia tomarse del obj que este en la pila
             y esta variable se utilizaria en donde se utiliza tipoDocumento para los nombres de los archivos*/
            String fechaCompleta = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");

            /*---- Destino----*/
            String rutaDestino = @"../../Documentos\CarpetaDestino\OUT_" + tipoDocumento;

            //String nombreDocumento = @"\XML_" + tipoDocumento + "_" + fechaCompleta + ".xml";

            /*se debe incluir en el canonico el nombre del archivo original csv...
             para prueba se agrega nombres...*/
            String nombreDocumento = @"\XML_" + tipoDocumento+"_"+can.Nombres + "_" + fechaCompleta + ".xml";

            rutaDestino += nombreDocumento;

            String documento = generarXml(can);

            /*se guarda el documento en su carpeta correspondiente*/
            File.WriteAllText(rutaDestino, documento);
            File.SetAttributes(rutaDestino, FileAttributes.Normal);


            /*-----LOG-----*/

            String rutaLog = @"../../Documentos\CarpetaDestino\OUT_LOG";

            //String nombreDocumentoLog = @"\XML_" + tipoDocumento + "_" + fechaCompleta + ".txt";
            /*se debe incluir en el canonico el nombre del archivo original csv...
             para prueba se agrega nombres...*/
            String nombreDocumentoLog = @"\XML_" + tipoDocumento +"_"+can.Nombres+ "_" + fechaCompleta + ".txt";
            rutaLog += nombreDocumentoLog;

            String peso = pesoArchivo(rutaDestino);
            String documentoLog = generarLog(tipoDocumento, fechaCompleta, peso);


            /*se guarda el log del documento en carpeta log*/
            File.WriteAllText(rutaLog, documentoLog);
            File.SetAttributes(rutaLog, FileAttributes.Normal);

        }

        public String generarXml(Canonico can)
        {

            String texto =
                "<canonico>\n" +
                "   <tipo_documento>" + can.Tipo_documento + "</tipo_documento>\n" +
                "   <id>" + can.Id + "</id>\n" +
                "   <fecha>" + can.Fecha + "</fecha>\n" +
                "   <carrera>" + can.Carrera + "</carrera>\n" +
                "   <nombres>" + can.Nombres + "</nombres>\n" +
                "   <apellidos>" + can.Apellidos + "</apellidos>\n" +
                "   <identificación>" + can.Identificacion + "</identificación>\n" +
                "   <modalidad_formación>" + can.Modalidad + "</modalidad_formación>\n" +
                "   <semestre>" + can.Semestre + "</semestre>\n" +
                "   <forma_de_pago>" + can.Forma_pago + "</forma_de_pago>\n" +
                "   <periodo_académico>" + can.Periodo_academico + "</periodo_académico>\n" +
                "   <total_pagar>" + can.Total_pagar + "</total_pagar>\n" +
                "   <descuentos>" + can.Descuentos + "</descuentos>\n" +
                "   <total_liquidado>" + can.Total_liquidado + "</total_liquidado>\n" +
                "   <materias>" + can.Materias + "</materias>\n" +
                "   <docentes>" + can.Docentes + "</docentes>\n" +
                "   <horario>" + can.Horario + "</horario>\n" +
                "   <tipo_graduación>" + can.Tipo_graducacion + "</tipo_graduación>\n" +
                "   <historia_académica>" + can.Historia_academica + "</historia_académica>\n" +
                "   <histórico_de_notas>" + can.Historico_notas + "</histórico_de_notas>\n" +
                "   <pago_derechos>" + can.Pago_derechos + "</pago_derechos>\n" +
                "   <celular>" + can.Celular + "</celular>\n" +
                "   <correo>" + can.Correo + "</correo>\n" +
                "   <dirección>" + can.Direccion + "</dirección>\n" +
                "   <edad>" + can.Edad + "</edad>\n" +
                "   <carnet>" + can.Carnet + "</carnet>\n" +
                "   <jornada>" + can.Jornada + "</jornada>\n" +
                "   <sede>" + can.Sede + "</sede>\n" +
                "   <motivo_cancelación>" + can.Motivo_cancelacion + "</motivo_cancelación>\n" +
                "</canonico>";

            return texto;
        }

        public String generarLog(String tipoDocumento, String fecha, String peso)
        {
            String texto = "El tipo de documento del archivo es: " + tipoDocumento + "\n" +
                "Se proceso en la fecha: " + fecha + "\n" +
                "Su peso es de: " + peso;

            return texto;

        }

        public String pesoArchivo(String rutaDestino)
        {
            long peso = new FileInfo(rutaDestino).Length;
            String pesoArchivo = "";
            if (peso > 0 && peso < 1024)
            {
                /*Bytes*/
                pesoArchivo = peso + " Bytes";
            }
            else if (peso > 1024)
            {
                peso /= 1024; /*Kb*/
                pesoArchivo = peso + " KB";
            }
            else if (peso > 1048576)
            {
                peso /= 1024 / 1024; /*Mb*/
                pesoArchivo = peso + " MB";

            }

            return pesoArchivo;
        }

    }


}
