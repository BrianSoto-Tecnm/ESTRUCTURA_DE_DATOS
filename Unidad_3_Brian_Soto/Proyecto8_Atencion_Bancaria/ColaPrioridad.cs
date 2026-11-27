// Cola de espera del banco: cola de prioridad enlazada.
// Inserta ordenado por prioridad (1 = alta, 4 = normal):
// PRIORIDAD (1) -> ADULTO MAYOR (2) -> PREFERENTE (3) -> NORMAL (4)
using System;

namespace Proyecto8_Banco
{
    public class ColaPrioridad
    {
        private Nodo frente;

        private class Nodo
        {
            public Cliente Datos;
            public Nodo Siguiente;

            public Nodo(Cliente cliente)
            {
                Datos = cliente;
            }
        }

        public bool Vacia()
        {
            return frente == null;
        }

        public void Insertar(Cliente cliente)
        {
            Nodo nuevo = new Nodo(cliente);

            if (frente == null ||
                cliente.Prioridad < frente.Datos.Prioridad)
            {
                nuevo.Siguiente = frente;
                frente = nuevo;
                return;
            }

            Nodo actual = frente;

            while (actual.Siguiente != null &&
                   actual.Siguiente.Datos.Prioridad
                   <= cliente.Prioridad)
            {
                actual = actual.Siguiente;
            }

            nuevo.Siguiente = actual.Siguiente;
            actual.Siguiente = nuevo;
        }

        public Cliente Atender()
        {
            if (frente == null)
                return null;

            Cliente cliente = frente.Datos;
            frente = frente.Siguiente;

            return cliente;
        }

        public Cliente Buscar(int turno)
        {
            Nodo actual = frente;

            while (actual != null)
            {
                if (actual.Datos.Turno == turno)
                    return actual.Datos;

                actual = actual.Siguiente;
            }

            return null;
        }

        public Cliente Cancelar(int turno)
        {
            if (frente == null)
                return null;

            if (frente.Datos.Turno == turno)
            {
                Cliente cliente = frente.Datos;
                frente = frente.Siguiente;
                return cliente;
            }

            Nodo anterior = frente;

            while (anterior.Siguiente != null &&
                   anterior.Siguiente.Datos.Turno != turno)
            {
                anterior = anterior.Siguiente;
            }

            if (anterior.Siguiente == null)
                return null;

            Cliente cancelado = anterior.Siguiente.Datos;
            anterior.Siguiente = anterior.Siguiente.Siguiente;

            return cancelado;
        }

        public void Mostrar()
        {
            if (frente == null)
            {
                Console.WriteLine("No hay clientes esperando.");
                return;
            }

            Nodo actual = frente;

            while (actual != null)
            {
                Console.WriteLine(actual.Datos);
                actual = actual.Siguiente;
            }
        }

        public int Contar()
        {
            int total = 0;
            Nodo actual = frente;

            while (actual != null)
            {
                total++;
                actual = actual.Siguiente;
            }

            return total;
        }
    }
}
