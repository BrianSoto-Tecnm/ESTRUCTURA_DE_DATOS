using System;

namespace Examen_Banco
{
    // Cola FIFO para clientes ordinarios: el primero en llegar es el primero en ser atendido.
    public class ColaNormal
    {
        private Nodo? frente;
        private Nodo? final;

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

            if (frente == null)
            {
                frente = nuevo;
                final = nuevo;
            }
            else
            {
                final!.Siguiente = nuevo;
                final = nuevo;
            }
        }

        public Cliente? Desencolar()
        {
            if (frente == null)
                return null;

            Cliente cliente = frente.Datos;
            frente = frente.Siguiente;

            if (frente == null)
                final = null;

            return cliente;
        }

        public void Mostrar()
        {
            if (frente == null)
            {
                Console.WriteLine("  (sin clientes ordinarios en espera)");
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
