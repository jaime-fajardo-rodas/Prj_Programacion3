using System;
using System.IO;


namespace Prj_ProcesamientoDocumentos_CCB_JFR
{
    class ProcesarPilas
    {
        public ProcesarPilas()
        {
            /*cantidad de documentos a procesar segun cada prioridad*/
            int DocPrioridadAlta = 3;
            int DocPrioridadMedia = 2;
            int cantidadDocumentos;

            /*va dentro del while para evaluar las pilas*/
            if (DocPrioridadAlta > 0)
            {
                /*hago un getlength para obtener cantidad de objetos en cola de priodidad alta.. 
                 * si no hay nada paso de una a la prioridad media*/
                cantidadDocumentos = 0;
                if (cantidadDocumentos > 0) {
                    guardarArchivos();
                    DocPrioridadAlta--;
                } else
                {
                    DocPrioridadAlta = 0;
                }

            }
            else if (DocPrioridadMedia > 0) {
                /*hago un getlength para obtener cantidad de objetos en cola de priodidad media.. 
                 * si no hay nada paso de una a la prioridad baja*/
                cantidadDocumentos = 0;
                if (cantidadDocumentos > 0)
                {
                    guardarArchivos();
                    DocPrioridadMedia--;
                }
                else
                {
                    DocPrioridadMedia = 0;
                }
            }
            else
            {
                /*hago un getlength para obtener cantidad de objetos en cola de priodidad baja.. 
                 * si no hay nada paso a restablecer valores para cantidad de documentos a procesar por cola de prioridad*/
                cantidadDocumentos = 0;
                if (cantidadDocumentos > 0)
                {
                    guardarArchivos();
                }

                DocPrioridadAlta = 3;
                DocPrioridadMedia = 2;
            }

        }

        public void guardarArchivos() {

            /*se debe obtener tipo documento desde el obj de la pila*/
            String tipoDocumento = "SOLI";

            /*se debe crear variable nombre archivo que deberia tomarse del obj que este en la pila
             y esta variable se utilizaria en donde se utiliza tipoDocumento para los nombres de los archivos*/
            String fechaCompleta = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");

            /*---- Destino----*/
            String rutaDestino = @"../../Documentos\CarpetaDestino\OUT_" + tipoDocumento;

            String nombreDocumento = @"\XML_" + tipoDocumento + "_" + fechaCompleta + ".xml";

            rutaDestino += nombreDocumento;

            String documento = generarXml();

            /*se guarda el documento en su carpeta correspondiente*/
            File.WriteAllText(rutaDestino, documento);
            File.SetAttributes(rutaDestino, FileAttributes.Normal);


            /*-----LOG-----*/

            String rutaLog = @"../../Documentos\CarpetaDestino\OUT_LOG";

            String nombreDocumentoLog = @"\XML_" + tipoDocumento + "_" + fechaCompleta + ".txt";
            rutaLog += nombreDocumentoLog;

            String peso = pesoArchivo(rutaDestino);
            String documentoLog = generarLog(tipoDocumento,fechaCompleta,peso);
            

            /*se guarda el log del documento en carpeta log*/
            File.WriteAllText(rutaLog, documentoLog);
            File.SetAttributes(rutaLog, FileAttributes.Normal);

        }

        public String generarXml()
        {
            String tipoDocumento = "";
            String id = "";
            String fecha = "";
            String carrera = "";
            String nombres = "";
            String apellidos = "";
            String identificacion = "";
            String modalidadFormacion = "";
            String semestre = "";
            String formaDePago = "";
            String periodoAcademico = "";
            String totalPagar = "";
            String descuentos = "";
            String totalLiquidado = "";
            String materias = "";
            String docentes = "";
            String horario = "";
            String tipoGraduacion = "";
            String historiaAcademica = "";
            String historicoDeNotas = "";
            String pagoDerechos = "";
            String celular = "";
            String correo = "";
            String direccion = "";
            String edad = "";
            String carnet = "";
            String jornada = "";
            String sede = "";
            String motivocancelacion = "";


            String texto =
                "<canonico>\n" +
                "   <tipo_documento>"+tipoDocumento+"</tipo_documento>\n" +
                "   <id>"+id+"</id>\n" +
                "   <fecha>"+fecha+"</fecha>\n" +
                "   <carrera>"+carrera+ "</carrera>\n" +
                "   <nombres>"+nombres+ "</nombres>\n" +
                "   <apellidos>"+apellidos+ "</apellidos>\n" +
                "   <identificación>"+identificacion+ "</identificación>\n" +
                "   <modalidad_formación>"+modalidadFormacion+ "</modalidad_formación>\n" +
                "   <semestre>"+semestre+ "</semestre>\n" +
                "   <forma_de_pago>"+formaDePago+ "</forma_de_pago>\n" +
                "   <periodo_académico>"+periodoAcademico+ "</periodo_académico>\n" +
                "   <total_pagar>"+totalPagar+ "</total_pagar>\n" +
                "   <descuentos>"+descuentos+ "</descuentos>\n" +
                "   <total_liquidado>"+totalLiquidado+ "</total_liquidado>\n" +
                "   <materias>"+materias+ "</materias>\n" +
                "   <docentes>"+docentes+ "</docentes>\n" +
                "   <horario>"+horario+ "</horario>\n" +
                "   <tipo_graduación>"+tipoGraduacion+ "</tipo_graduación>\n" +
                "   <historia_académica>"+historiaAcademica+ "</historia_académica>\n" +
                "   <histórico_de_notas>"+historicoDeNotas+ "</histórico_de_notas>\n" +
                "   <pago_derechos>"+pagoDerechos+ "</pago_derechos>\n" +
                "   <celular>"+celular+ "</celular>\n" +
                "   <correo>"+correo+ "</correo>\n" +
                "   <dirección>"+direccion+ "</dirección>\n" +
                "   <edad>"+edad+ "</edad>\n" +
                "   <carnet>"+carnet+ "</carnet>\n" +
                "   <jornada>"+jornada+ "</jornada>\n" +
                "   <sede>"+sede+ "</sede>\n" +
                "   <motivo_cancelación>"+motivocancelacion+ "</motivo_cancelación>\n" +
                "</canonico>";

            return texto;
        }

        public String generarLog(String tipoDocumento,String fecha,String peso)
        {
            String texto = "El tipo de documento del archivo es: "+ tipoDocumento+"\n" +
                "Se proceso en la fecha: "+fecha+ "\n" +
                "Su peso es de: "+peso;

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
