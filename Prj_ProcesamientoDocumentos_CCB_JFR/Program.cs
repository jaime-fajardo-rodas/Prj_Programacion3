using System;
using System.Diagnostics;
using System.Threading;


namespace Prj_ProcesamientoDocumentos_CCB_JFR
{
    class Program
    {
        static System.Timers.Timer procesoLectura;
        static System.Timers.Timer tSimulador;
        static void Main(string[] args)
        {

            Thread hiloSimular = new Thread(new ThreadStart(simular));
            hiloSimular.Start();

            var stopwatch = Stopwatch.StartNew();
            Thread.Sleep(15000);
            stopwatch.Stop();

            Thread hiloLectura = new Thread(new ThreadStart(leerArchivos));
            hiloLectura.Start();

            Thread hiloProcesar = new Thread(ProcesarColas.ProcesarColasPrioridades);
            hiloProcesar.Start();

        }

        private static void leerArchivos()
        {
            while (true)
            {
                //procesoLectura = new System.Timers.Timer();
                //procesoLectura.Elapsed += 
                ArchivosCSV.GenerarXML();
                //procesoLectura.AutoReset = true;
                //procesoLectura.Enabled = true;
            }
        }


        public static void simular()
        {
            
            Dosificador.datos();

            // Temporizador con intervalo de 1 segundo
            //tSimulador = new System.Timers.Timer(5000);
            //tSimulador.Elapsed += 
                Dosificador.generadorCSV();
            //tSimulador.AutoReset = true;
            //tSimulador.Enabled = true;
        }
    }
}
