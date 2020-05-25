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
        public static Cola colaAlta;
        public static Cola colaMedia;
        public static Cola colaBaja;
        static void Main(string[] args)
        {

            //ArchivosCSV.GenerarXML();

            colaAlta = new Cola();
            
            for (int i = 0; i < 5; i++)
            {
                Canonico cAlto = new Canonico();
                cAlto.Tipo_documento = "SOLGRA";
                cAlto.Edad = (29+i);
                cAlto.Forma_pago = "Efectivo";
                cAlto.Nombres = "Carlos_"+i;
                
                colaAlta.Encolar(cAlto);
            }

            colaMedia = new Cola();
            
            for (int i = 0; i < 5; i++)
            {
                Canonico cMedio = new Canonico();
                cMedio.Tipo_documento = "SOLI";
                cMedio.Edad = (35+i);
                cMedio.Forma_pago = "Efectivo";
                cMedio.Nombres = "Jaime_"+i;

                colaMedia.Encolar(cMedio);
            }

            colaBaja = new Cola();
            
            for (int i = 0; i < 5; i++)
            {
                Canonico cBajo = new Canonico();
                cBajo.Tipo_documento = "SOLMAAC";
                cBajo.Edad = (55+i);
                cBajo.Forma_pago = "Efectivo";
                cBajo.Nombres = "David_"+i;

                colaBaja.Encolar(cBajo);
            }

            
            exeProcesamiento();
        }


        public static void exeProcesamiento()
        {
            ProcesarPilas objProcesamiento = new ProcesarPilas(colaAlta,colaMedia,colaBaja);
            objProcesamiento.ProcesarPilasPrioridades();
        }
    }
}
