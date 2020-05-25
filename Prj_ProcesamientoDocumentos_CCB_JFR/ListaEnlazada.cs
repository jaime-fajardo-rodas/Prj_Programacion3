using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_ProcesamientoDocumentos_CCB_JFR
{
    public class Nodo
    {
        private Canonico valor;
        private Nodo siguiente, anterior;

        public Canonico Valor { get { return valor; } set { valor = value; } }
        public Nodo Siguiente { get { return siguiente; } set { siguiente = value; } }
        public Nodo Anterior { get { return anterior; } set { anterior = value; } }

    }
    public class ListaEnlazada
    {
        Nodo cabeza;
        private string v;

        public ListaEnlazada(string v)
        {
            this.v = v;
        }

        public bool ListaVacia()
        {
            if (cabeza == null)
                return true;
            else
                return false;
        }

        public void AgregarElementoAlInicio(Canonico value)
        {
            Nodo Nuevo = new Nodo();
            Nuevo.Valor = value;

            if (ListaVacia())
            {
                cabeza = Nuevo;
            }
            else
            {
                Nuevo.Siguiente = cabeza;
                cabeza = Nuevo;
            }
        }


        public void imprimir()
        {
            Nodo recorrido = cabeza;

            while (recorrido != null)
            {
                Console.Write(" ->" + recorrido.Valor.Tipo_documento);
                Console.Write(" ->" + recorrido.Valor.Id);
                Console.Write(" ->" + recorrido.Valor.Fecha);
                Console.Write(" ->" + recorrido.Valor.Carrera);
                Console.Write(" ->" + recorrido.Valor.Nombres);
                Console.Write(" ->" + recorrido.Valor.Apellidos);
                Console.Write(" ->" + recorrido.Valor.Identificacion);
                Console.Write(" ->" + recorrido.Valor.Modalidad);
                Console.Write(" ->" + recorrido.Valor.Semestre);
                Console.Write(" ->" + recorrido.Valor.Forma_pago);
                Console.Write(" ->" + recorrido.Valor.Periodo_academico);
                Console.Write(" ->" + recorrido.Valor.Total_pagar);
                Console.Write(" ->" + recorrido.Valor.Descuentos);
                Console.Write(" ->" + recorrido.Valor.Total_liquidado);
                Console.Write(" ->" + recorrido.Valor.Materia);
                Console.Write(" ->" + recorrido.Valor.Docentes);
                Console.Write(" ->" + recorrido.Valor.Horario);
                Console.Write(" ->" + recorrido.Valor.Tipo_graducacion);
                Console.Write(" ->" + recorrido.Valor.Historia_academica);
                Console.Write(" ->" + recorrido.Valor.Pago_derechos);
                Console.Write(" ->" + recorrido.Valor.Celular);
                Console.Write(" ->" + recorrido.Valor.Correo);
                Console.Write(" ->" + recorrido.Valor.Direccion);
                Console.Write(" ->" + recorrido.Valor.Edad);
                Console.Write(" ->" + recorrido.Valor.Carnet);
                Console.Write(" ->" + recorrido.Valor.Jornada);
                Console.Write(" ->" + recorrido.Valor.Sede);
                Console.Write(" ->" + recorrido.Valor.Motivo_cancelacion);
                Console.Write("\n");
                recorrido = recorrido.Siguiente;
            }
            Console.Write("*\n");
        }

        public Canonico consultarCabeza()
        {
            Nodo recorrido = cabeza;
            Canonico p = new Canonico();

            while (recorrido != null)
            {
                if (recorrido.Siguiente == null)
                {
                    p = recorrido.Valor;
                }

                if (recorrido.Siguiente != null)
                {
                    recorrido = recorrido.Siguiente;
                }

            }

            return p;
        }

        public Nodo EliminarElementoDesdeLaCabeza()
        {
            Nodo n = new Nodo();
            if (!ListaVacia())
            {
                n = cabeza;
                cabeza = cabeza.Siguiente;
            }
            return n;
        }

        public Canonico EliminarElementoDesdeElFinal()
        {
            int count = 0;
            Canonico p = new Canonico();
            if (!ListaVacia())
            {
                Nodo Recorrido = cabeza;
                Nodo Referencia = new Nodo();

                while (Recorrido != null)
                {
                    if (Recorrido.Siguiente != null)
                    {
                        Referencia = Recorrido;
                    }

                    Recorrido = Recorrido.Siguiente;
                    count++;
                }

                if (count == 1)
                {
                    p = cabeza.Valor;
                    cabeza = null;
                }
                else
                {
                    p = Referencia.Siguiente.Valor;
                    Referencia.Siguiente = null;
                    Recorrido = Referencia;
                }
            }
            return p;
        }
    }
}
