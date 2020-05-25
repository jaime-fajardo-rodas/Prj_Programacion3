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

            //ArchivosCSV.GenerarXML();

            Canonico c = new Canonico();

            c.Tipo_documento = "Soli";
            c.Edad = 29;
            c.Forma_pago = "Efectivo";
            c.Nombres = "Carlos";

            Cola cola = new Cola();

            cola.Encolar(c);

            cola.imprimir();
            Console.ReadLine();

        }
    }
}
