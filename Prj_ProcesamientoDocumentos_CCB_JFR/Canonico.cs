using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_ProcesamientoDocumentos_CCB_JFR
{
    public class Canonico
    {
        string tipo_documento;
        int id;
        string fecha;
        string carrera;
        string nombres;
        string apellidos;
        int identificacion;
        string modalidad;
        string semestre;
        string forma_pago;
        string periodo_academico;
        double total_pagar;
        double descuentos;
        double total_liquidado;
        string materia;
        string docentes;
        string horario;
        string tipo_graducacion;
        string historia_academica;
        string pago_derechos;
        int celular;
        string correo;
        string direccion;
        int edad;
        string carnet;
        string jornada;
        string sede;
        string motivo_cancelacion;

        public Canonico()
        {

        }

        public string Tipo_documento { get => tipo_documento; set => tipo_documento = value; }
        public int Id { get => id; set => id = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Carrera { get => carrera; set => carrera = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public int Identificacion { get => identificacion; set => identificacion = value; }
        public string Modalidad { get => modalidad; set => modalidad = value; }
        public string Semestre { get => semestre; set => semestre = value; }
        public string Forma_pago { get => forma_pago; set => forma_pago = value; }
        public string Periodo_academico { get => periodo_academico; set => periodo_academico = value; }
        public double Total_pagar { get => total_pagar; set => total_pagar = value; }
        public double Descuentos { get => descuentos; set => descuentos = value; }
        public double Total_liquidado { get => total_liquidado; set => total_liquidado = value; }
        public string Materia { get => materia; set => materia = value; }
        public string Docentes { get => docentes; set => docentes = value; }
        public string Horario { get => horario; set => horario = value; }
        public string Tipo_graducacion { get => tipo_graducacion; set => tipo_graducacion = value; }
        public string Historia_academica { get => historia_academica; set => historia_academica = value; }
        public string Pago_derechos { get => pago_derechos; set => pago_derechos = value; }
        public int Celular { get => celular; set => celular = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int Edad { get => edad; set => edad = value; }
        public string Carnet { get => carnet; set => carnet = value; }
        public string Jornada { get => jornada; set => jornada = value; }
        public string Sede { get => sede; set => sede = value; }
        public string Motivo_cancelacion { get => motivo_cancelacion; set => motivo_cancelacion = value; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
