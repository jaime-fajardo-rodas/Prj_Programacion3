using System;
using System.Threading;


namespace Prj_ProcesamientoDocumentos_CCB_JFR
{
    class Program
    {
        static System.Timers.Timer procesoLectura;
        static void Main(string[] args)
        {

            Dosificador.simular();

            Thread hiloLectura = new Thread(new ThreadStart(leerArchivos));
            hiloLectura.Start();

            Thread hiloProcesar = new Thread(ProcesarColas.ProcesarColasPrioridades);
            hiloProcesar.Start();

        }

        private static void leerArchivos()
        {
            procesoLectura = new System.Timers.Timer();
            procesoLectura.Elapsed += ArchivosCSV.GenerarXML;
            procesoLectura.AutoReset = true;
            procesoLectura.Enabled = true;
        }

    }
}
