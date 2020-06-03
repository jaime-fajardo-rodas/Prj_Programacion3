using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_ProcesamientoDocumentos_CCB_JFR
{
    public class ListaSimple
    {
        public class Nodo
        {
            private string valor;

            public string Valor { get { return valor; } set { valor = value; } }

            private Nodo siguiente;

            public Nodo Siguiente { get { return siguiente; } set { siguiente = value; } }

        }

        public class ListaEnlazadaSimple
        {
            Nodo cabeza;

            public bool ListaVacia()
            {
                if (cabeza == null)
                    return true;
                else
                    return false;
            }

            public void AgregarElementoAlInicio(string value)
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
                    Console.Write(recorrido.Valor + ",");
                    recorrido = recorrido.Siguiente;
                }
                Console.Write("*\n");
            }

            public string imprimirPosicion(int p)
            {
                Nodo recorrido = cabeza;

                for(int i = 0; i < p; i++)
                {
                    recorrido = recorrido.Siguiente;
                }

                return recorrido.Valor;

            }

            public void AgregarElementoAlFinal(string value)
            {
                Nodo Nuevo = new Nodo();
                Nuevo.Valor = value;

                if (ListaVacia())
                {
                    cabeza = Nuevo;
                }
                else
                {
                    Nodo Recorrido = cabeza;

                    while (Recorrido.Siguiente != null)
                    {
                        Recorrido = Recorrido.Siguiente;
                    }
                    Recorrido.Siguiente = Nuevo;
                }
            }

            public void EliminarElementoDesdeLaCabeza()
            {
                if (!ListaVacia())
                {
                    cabeza = cabeza.Siguiente;
                }
            }

            public void EliminarElementoDesdeElFinal()
            {
                int count = 0;
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
                        cabeza = null;
                    }
                    else
                    {
                        Referencia.Siguiente = null;
                        Recorrido = Referencia;
                    }
                }
            }

            public void LimpiarLista()
            {
                cabeza = null;
            }

            public int CantidadElementos()
            {
                int cant = 1;
                if (!ListaVacia())
                {
                    Nodo reco = cabeza;
                    Nodo cabezaP = cabeza;
                    do
                    {
                        if (reco.Siguiente != null)
                        {
                            cant++;
                            reco = reco.Siguiente;

                        } else
                        {
                            break;
                        }
                    } while (true);
                        
                }
                return cant;
            }
        }
    }
}
