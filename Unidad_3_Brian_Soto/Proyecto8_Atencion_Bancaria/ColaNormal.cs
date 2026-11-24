using System;

namespace Proyecto8_Banco
{
    public class ColaNormal
    {
        private Nodo frente;
        private Nodo fin;

        private class Nodo
        {
            public Cliente Datos;
            public Nodo Siguiente;

            public Nodo(Cliente cliente)
            {
                Datos = cliente;
            }
        }

        public void Insertar(Cliente cliente)
        {
            Nodo nuevo = new Nodo(cliente);

            if (frente == null)
            {
                frente = nuevo;
                fin = nuevo;
                return;
            }

            fin.Siguiente = nuevo;
            fin = nuevo;
        }

        public Cliente Atender()
        {
            if (frente == null)
                return null;

            Cliente cliente = frente.Datos;
            frente = frente.Siguiente;

            if (frente == null)
                fin = null;

            return cliente;
        }

        public void Mostrar()
        {
            Nodo actual = frente;

            while (actual != null)
            {
                Console.WriteLine(actual.Datos);
                actual = actual.Siguiente;
            }
        }
    }
}
