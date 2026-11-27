using System;

namespace Examen_Banco
{
    // Cola de prioridad para clientes preferentes.
    // Se inserta de forma ordenada: prioridad 1 (alta) sale antes que 2 y 3.
    // Si dos clientes tienen la misma prioridad, se respeta el orden de llegada (FIFO).
    public class ColaPrioridad
    {
        private Nodo? frente;

        public bool Vacia()
        {
            return frente == null;
        }

        public int Contar()
        {
            int cantidad = 0;
            Nodo? actual = frente;

            while (actual != null)
            {
                cantidad++;
                actual = actual.Siguiente;
            }

            return cantidad;
        }

        public void Encolar(Cliente cliente)
        {
            Nodo nuevo = new Nodo(cliente);

            if (frente == null || cliente.Prioridad < frente.Datos.Prioridad)
            {
                nuevo.Siguiente = frente;
                frente = nuevo;
                return;
            }

            Nodo actual = frente;

            while (actual.Siguiente != null &&
                   actual.Siguiente.Datos.Prioridad <= cliente.Prioridad)
            {
                actual = actual.Siguiente;
            }

            nuevo.Siguiente = actual.Siguiente;
            actual.Siguiente = nuevo;
        }

        public Cliente? Desencolar()
        {
            if (frente == null)
                return null;

            Cliente cliente = frente.Datos;
            frente = frente.Siguiente;

            return cliente;
        }

        public void Mostrar()
        {
            if (frente == null)
            {
                Console.WriteLine("  (sin clientes preferentes en espera)");
                return;
            }

            int posicion = 1;
            Nodo? actual = frente;

            while (actual != null)
            {
                Console.WriteLine($"  {posicion}. {actual.Datos}");
                posicion++;
                actual = actual.Siguiente;
            }
        }
    }
}
