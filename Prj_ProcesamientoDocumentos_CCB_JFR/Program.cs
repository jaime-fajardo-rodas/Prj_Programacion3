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
            var stopwatch = Stopwatch.StartNew();
            Thread.Sleep(1000);
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
                ArchivosCSV.GenerarXML();
            }
        }
    }
}
