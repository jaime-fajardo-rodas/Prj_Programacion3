using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_ProcesamientoDocumentos_CCB_JFR
{
    public class Cola : ListaEnlazada
    {
        public Cola() : base("Cola") { }

        public void Encolar(Canonico Obj)
        {
            base.AgregarElementoAlInicio(Obj);
        }

        public Canonico Descolar()
        {
            return base.EliminarElementoDesdeElFinal();
        }

        public Boolean ColaVacia()
        {
            return base.ListaVacia();
        }
    }


}
