// Cola de procesos: lista enlazada FIFO con sus funciones de
// administracion (crear, eliminar, ejecutar, bloquear, desbloquear,
// buscar y mostrar).
using System;

namespace Proyecto9_SO
{
    public class ColaProcesos
    {
        private Nodo frente;
        private Nodo fin;

        private class Nodo
        {
            public Proceso Datos;
            public Nodo Siguiente;

            public Nodo(Proceso proceso)
            {
                Datos = proceso;
            }
        }

        public bool Vacia()
        {
            return frente == null;
        }

        public void Crear(Proceso proceso)
        {
            Nodo nuevo = new Nodo(proceso);

            if (frente == null)
            {
                frente = nuevo;
                fin = nuevo;
                return;
            }

            fin.Siguiente = nuevo;
            fin = nuevo;
        }

        public Proceso Buscar(string pid)
        {
            Nodo actual = frente;

            while (actual != null)
            {
                if (actual.Datos.Pid == pid)
                    return actual.Datos;

                actual = actual.Siguiente;
            }

            return null;
        }

        public bool Eliminar(string pid)
        {
            if (frente == null)
                return false;

            if (frente.Datos.Pid == pid)
            {
                frente.Datos.Estado = "TERMINADO";
                frente = frente.Siguiente;
                if (frente == null)
                    fin = null;
                return true;
            }

            Nodo anterior = frente;

            while (anterior.Siguiente != null && anterior.Siguiente.Datos.Pid != pid)
                anterior = anterior.Siguiente;

            if (anterior.Siguiente == null)
                return false;

            anterior.Siguiente.Datos.Estado = "TERMINADO";

            if (anterior.Siguiente == fin)
                fin = anterior;

            anterior.Siguiente = anterior.Siguiente.Siguiente;
            return true;
        }

        public bool Ejecutar(string pid)
        {
            Proceso proceso = Buscar(pid);

            if (proceso == null)
                return false;

            proceso.Estado = "EJECUTANDO";
            return true;
        }

        public bool Bloquear(string pid)
        {
            Proceso proceso = Buscar(pid);

            if (proceso == null)
                return false;

            proceso.Estado = "BLOQUEADO";
            return true;
        }

        public bool Desbloquear(string pid)
        {
            Proceso proceso = Buscar(pid);

            if (proceso == null)
                return false;

            proceso.Estado = "LISTO";
            return true;
        }

        public void Mostrar()
        {
            if (frente == null)
            {
                Console.WriteLine("No hay procesos en la cola.");
                return;
            }

            Nodo actual = frente;

            while (actual != null)
            {
                Console.WriteLine(actual.Datos);
                actual = actual.Siguiente;
            }
        }

        public void MostrarCola()
        {
            if (frente == null)
            {
                Console.WriteLine("Cola de procesos: (vacia)");
                return;
            }

            string cola = "";
            Nodo actual = frente;

            while (actual != null)
            {
                cola += actual.Datos.Pid;

                if (actual.Siguiente != null)
                    cola += " -> ";

                actual = actual.Siguiente;
            }

            Console.WriteLine("Cola de procesos: " + cola);
        }
    }
}
