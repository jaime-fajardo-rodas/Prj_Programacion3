using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Dosificador
{
    class Dosificador
    {
        static DirectoryInfo direcCSV = new DirectoryInfo("./../../../Prj_ProcesamientoDocumentos_CCB_JFR/Documentos/CarpetaComun/");
        static string rutaComun = direcCSV.FullName;

        private static Archivo objSOLI;
        private static Archivo objSOLMAFI;
        private static Archivo objSOLMAAC;
        private static Archivo objSOLGRA;
        private static Archivo objSOLCREES;
        private static Archivo objSOLCANMA;

        public static void generadorCSV()
        {
            int count = 0;
            while (true)
            {

                Random aleatorio = new Random();
                int fila = aleatorio.Next(1, 2);
                int solicitud = aleatorio.Next(1, 7);

                switch (solicitud)
                {
                    case 1:
                        crearCSV(objSOLI, "SOLI" + count);
                        break;
                    case 2:
                        crearCSV(objSOLMAFI, "SOLMAFI" + count);
                        break;
                    case 3:
                        crearCSV(objSOLMAAC, "SOLMAAC" + count);
                        break;
                    case 4:
                        crearCSV(objSOLGRA, "SOLGRA" + count);
                        break;
                    case 5:
                        crearCSV(objSOLCREES, "SOLCREES" + count);
                        break;
                    default:
                        crearCSV(objSOLCANMA, "SOLCANMA" + count);
                        break;
                }

                count++;

                var stopwatch = Stopwatch.StartNew();
                Thread.Sleep(1000);
                stopwatch.Stop();
            }
        }

        public static void crearCSV(Archivo objDocumento, string solicitud)
        {

            String nombreCSV = string.Format("{0}.csv", solicitud);
            String rutaCSV = string.Format("{0}{1}", rutaComun, nombreCSV);
            String[] datos = new string[2];

            datos[0] = objDocumento.Cabecera;
            datos[1] = objDocumento.Detalle; 

            if (!File.Exists(rutaCSV))
            {
                File.WriteAllLines(rutaCSV, datos);
            }

        }
        public static void datos()
        {
            objSOLI = new Archivo();
            objSOLI.Cabecera = "id;fecha;carrera;nombres;apellidos;identificación;modalidad_formación;semestre";
            objSOLI.Detalle = "00001;2019-06-06;ingenieria de sistemas;Juan;Marin;1444657485;presencial;7";

            objSOLMAFI = new Archivo();
            objSOLMAFI.Cabecera = "id;fecha;carrera;nombres;apellidos;identificación;forma_pago;periodo_académico;total_pagar;descuentos;total_liquidado";
            objSOLMAFI.Detalle = "00001;2019-06-06;ingenieria de sistemas;Juan;Marin;1444657485;efectivo;2020-01;3145000;100000;3045000";

            objSOLMAAC = new Archivo();
            objSOLMAAC.Cabecera = "id;fecha;carrera;nombres;apellidos;identificación;materias;docentes;horario";
            objSOLMAAC.Detalle = "00001;2019-06-06;ingenieria de sistemas;Juan;Marin;1444657485;programacion 3, ingles 3, fisica 2, ing. de software;Andres Triana,Monica Ponte, Luis Carlos Ospina;Lunes a sabado";

            objSOLGRA = new Archivo();
            objSOLGRA.Cabecera = "id;fecha;carrera;nombres;apellidos;identificación;tipo_graduación;historia_académica;histórico_notas;pago_derechos";
            objSOLGRA.Detalle = "00001;2019-06-06;ingenieria de sistemas;Juan;Marin;1444657485;ceremonia;Aprobado;Aprobado;Aprobado";

            objSOLCREES = new Archivo();
            objSOLCREES.Cabecera = "id;fecha;carrera;nombres;apellidos;identificación;celular;correo;dirección;edad;carnet;jornada;sede";
            objSOLCREES.Detalle = "00001;2019-06-06;ingenieria de sistemas;Juan;Marin;1444657485;3206548465;jmarin@misena.edu.co;calle 49 #3-43;24;si;nocturna;central";

            objSOLCANMA = new Archivo();
            objSOLCANMA.Cabecera = "id;fecha;carrera;nombres;apellidos;identificación;motivo_cancelación";
            objSOLCANMA.Detalle = "00001;2019-06-06;ingenieria de sistemas;Juan;Marin;1444657485;viaje";
        }
    }
}
