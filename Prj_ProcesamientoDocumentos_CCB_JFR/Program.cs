using System.Threading;


namespace Prj_ProcesamientoDocumentos_CCB_JFR
{
    class Program
    {
        static System.Timers.Timer procesoLectura;
        static System.Timers.Timer procesoProcesar;
        static void Main(string[] args)
        {

            Thread hiloLectura = new Thread(new ThreadStart(leerArchivos));
            hiloLectura.Start();
            Thread.Sleep(10000);

            Thread hiloProcesar = new Thread(new ThreadStart(procesarArchivos));
            hiloProcesar.Start();
            Thread.Sleep(10000);          

        }

        private static void leerArchivos()
        {
            while (true)
            {
                procesoLectura = new System.Timers.Timer();
                procesoLectura.Elapsed += ArchivosCSV.GenerarXML;
                procesoLectura.AutoReset = true;
                procesoLectura.Enabled = true;
            }
            
        }

        private static void procesarArchivos()
        {
            while (true)
            {
                procesoProcesar = new System.Timers.Timer();
                procesoProcesar.Elapsed += ProcesarColas.ProcesarColasPrioridades;
                procesoProcesar.AutoReset = true;
                procesoProcesar.Enabled = true;
            }

        }

    }
}
