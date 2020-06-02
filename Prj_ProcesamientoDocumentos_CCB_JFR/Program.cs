using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prj_ProcesamientoDocumentos_CCB_JFR;


namespace Prj_ProcesamientoDocumentos_CCB_JFR
{
    class Program
    {
        static void Main(string[] args)
        {
            ArchivosCSV archivosCSV = new ArchivosCSV();

            archivosCSV.GenerarXML();

            Console.ReadLine();

            while (true)
            {
                Dosificador.simular();
            }

        }
    }
}
