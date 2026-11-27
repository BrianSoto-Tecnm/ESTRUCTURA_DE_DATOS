// Pila (LIFO) del historial de operaciones: push y mostrar de
// arriba hacia abajo.
using System;

namespace Proyecto10_Tienda
{
    public class PilaHistorial
    {
        private Nodo tope;

        private class Nodo
        {
            public string Dato;
            public Nodo Siguiente;

            public Nodo(string dato)
            {
                Dato = dato;
            }
        }

        public void Push(string operacion)
        {
            Nodo nuevo = new Nodo(operacion);
            nuevo.Siguiente = tope;
            tope = nuevo;
        }

        public void Mostrar()
        {
            if (tope == null)
            {
                Console.WriteLine("El historial esta vacio.");
                return;
            }

            Nodo actual = tope;
            int posicion = 1;

            while (actual != null)
            {
                Console.WriteLine($"{posicion}. {actual.Dato}");
                actual = actual.Siguiente;
                posicion++;
            }
        }

        public int Contar()
        {
            int total = 0;
            Nodo actual = tope;

            while (actual != null)
            {
                total++;
                actual = actual.Siguiente;
            }

            return total;
        }
    }
}
