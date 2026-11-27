// ==================================================================
// PROYECTO 8. SIMULADOR DE ATENCION BANCARIA
// Tipos de clientes: cliente normal, cliente preferente, adulto
// mayor y persona con prioridad.
// Funciones: generar turno, atender cliente, cancelar turno,
// mostrar clientes esperando, mostrar clientes atendidos, agregar
// prioridad, mostrar tiempo estimado y mostrar numero de clientes
// en espera.
// ==================================================================
using System;

namespace Proyecto8_Banco
{
    public class Cliente
    {
        public int Turno { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int Prioridad { get; set; }

        public Cliente(int turno, string nombre, string tipo, int prioridad)
        {
            Turno = turno;
            Nombre = nombre;
            Tipo = tipo;
            Prioridad = prioridad;
        }

        public override string ToString()
        {
            return $"Turno {Turno} | {Nombre} | {Tipo} | Prioridad {Prioridad}";
        }
    }
}
