using System;
using System.Collections.Generic;
using System.IO; //File
using System.Timers; //ElapsedEventArgs, Timer

namespace Prj_ProcesamientoDocumentos_CCB_JFR
{
    public class Dosificador
    {
        static DirectoryInfo direcCSV = new DirectoryInfo("./../../Documentos/CarpetaComun/");
        static string rutaComun = direcCSV.FullName;
        
        static List<string> lsSOLI = new List<string>();
        static List<string> lsSOLMAFI = new List<string>();
        static List<string> lsSOLMAAC = new List<string>();
        static List<string> lsSOLGRA = new List<string>();
        static List<string> lsSOLCREES = new List<string>();
        static List<string> lsSOLCANMA = new List<string>();
        static System.Timers.Timer tSimulador;
        public static void simular()
        {
            datos();

            Console.WriteLine("Ruta: " + rutaComun);
            Console.ReadLine();

            // Temporizador con intervalo de 1 segundo
            tSimulador = new System.Timers.Timer(5000);
            tSimulador.Elapsed += generadorCSV;
            tSimulador.AutoReset = true;
            tSimulador.Enabled = true;
        }

        private static void generadorCSV(Object source, ElapsedEventArgs e)
        {
            Random aleatorio = new Random();
            int fila = aleatorio.Next(1, 2);
            int solicitud = aleatorio.Next(1, 7);

            switch (solicitud)
            {
                case 1:
                    crearCSV(lsSOLI[0], lsSOLI[fila], "SOLI");
                    break;
                case 2:
                    crearCSV(lsSOLMAFI[0], lsSOLMAFI[fila], "SOLMAFI");
                    break;
                case 3:
                    crearCSV(lsSOLMAAC[0], lsSOLMAAC[fila], "SOLMAAC");
                    break;
                case 4:
                    crearCSV(lsSOLGRA[0], lsSOLGRA[fila], "SOLGRA");
                    break;
                case 5:
                    crearCSV(lsSOLCREES[0], lsSOLCREES[fila], "SOLCREES");
                    break;
                default:
                    crearCSV(lsSOLCANMA[0], lsSOLCANMA[fila], "SOLCANMA");
                    break;
            }
        }

        private static void crearCSV(string cabecera, string detalle, string solicitud)
        {
            List<string> contenido = new List<string>();
            string nombreCSV;
            string rutaCSV;

            contenido.Add(cabecera);
            contenido.Add(detalle);
            nombreCSV = string.Format("{0}.csv", solicitud);
            rutaCSV = string.Format("{0}{1}", rutaComun, nombreCSV);

            if (!File.Exists(rutaCSV))
            {
                File.WriteAllLines(rutaCSV, contenido);
            }

        }
        private static void datos()
        {
            lsSOLI.Add("id;fecha;carrera;nombres;apellidos;identificación;modalidad_formación;semestre");
            lsSOLI.Add("00001;2019-06-06;ingenieria de sistemas;Juan;Marin;1444657485;presencial;7");

            lsSOLMAFI.Add("id;fecha;carrera;nombres;apellidos;identificación;forma_pago;periodo_académico;total_pagar;descuentos;total_liquidado");
            lsSOLMAFI.Add("00001;2019-06-06;ingenieria de sistemas;Juan;Marin;1444657485;efectivo;2020-01;3145000;100000;3045000");

            lsSOLMAAC.Add("id;fecha;carrera;nombres;apellidos;identificación;materias;docentes;horario");
            lsSOLMAAC.Add("00001;2019-06-06;ingenieria de sistemas;Juan;Marin;1444657485;programacion 3, ingles 3, fisica 2, ing. de software;Andres Triana,Monica Ponte, Luis Carlos Ospina;Lunes a sabado");

            lsSOLGRA.Add("id;fecha;carrera;nombres;apellidos;identificación;tipo_graduación;historia_académica;histórico_notas;pago_derechos");
            lsSOLGRA.Add("00001;2019-06-06;ingenieria de sistemas;Juan;Marin;1444657485;ceremonia;Aprobado;Aprobado;Aprobado");

            lsSOLCREES.Add("id;fecha;carrera;nombres;apellidos;identificación;celular;correo;dirección;edad;carnet;jornada;sede");
            lsSOLCREES.Add("00001;2019-06-06;ingenieria de sistemas;Juan;Marin;1444657485;3206548465;jmarin@misena.edu.co;calle 49 #3-43;24;si;nocturna;central");

            lsSOLCANMA.Add("id;fecha;carrera;nombres;apellidos;identificación;motivo_cancelación");
            lsSOLCANMA.Add("00001;2019-06-06;ingenieria de sistemas;Juan;Marin;1444657485;viaje");
        }
    }
}
