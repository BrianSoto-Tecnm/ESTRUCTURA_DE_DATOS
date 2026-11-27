// ==================================================================
// PROYECTO 9. SISTEMA DE CONTROL DE PROCESOS DE UN SISTEMA OPERATIVO
// Cada proceso tiene PID, nombre, prioridad, estado y tiempo de
// ejecucion. Estados: NUEVO, LISTO, EJECUTANDO, BLOQUEADO, TERMINADO.
// Utilizamos una cola de procesos (lista enlazada).
// ==================================================================
using System;

namespace Proyecto9_SO
{
    public class Proceso
    {
        public string Pid { get; set; }
        public string Nombre { get; set; }
        public int Prioridad { get; set; }
        public string Estado { get; set; }
        public int Tiempo { get; set; }

        public Proceso(string pid, string nombre, int prioridad, int tiempo)
        {
            Pid = pid;
            Nombre = nombre;
            Prioridad = prioridad;
            Tiempo = tiempo;
            Estado = "NUEVO";
        }

        public override string ToString()
        {
            return $"{Pid} | {Nombre} | Prioridad {Prioridad} | Estado {Estado} | Tiempo {Tiempo}s";
        }
    }
}
