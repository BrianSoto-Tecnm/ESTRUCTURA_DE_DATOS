// Cola de pedidos: se usa como cola normal (pendientes) o como cola
// de prioridad (urgentes) segun el parametro porPrioridad.
using System;

namespace Proyecto10_Tienda
{
    public class ColaPedidos
    {
        private Nodo frente;
        private Nodo fin;
        private bool porPrioridad;

        public ColaPedidos(bool porPrioridad)
        {
            this.porPrioridad = porPrioridad;
        }

        private class Nodo
        {
            public Pedido Datos;
            public Nodo Siguiente;

            public Nodo(Pedido pedido)
            {
                Datos = pedido;
            }
        }

        public void Insertar(Pedido pedido)
        {
            Nodo nuevo = new Nodo(pedido);

            if (frente == null)
            {
                frente = nuevo;
                fin = nuevo;
                return;
            }

            // Cola normal: se inserta al final (FIFO)
            if (!porPrioridad)
            {
                fin.Siguiente = nuevo;
                fin = nuevo;
                return;
            }

            // Cola de prioridad: menor numero de prioridad primero
            if (pedido.Prioridad < frente.Datos.Prioridad)
            {
                nuevo.Siguiente = frente;
                frente = nuevo;
                return;
            }

            Nodo actual = frente;

            while (actual.Siguiente != null &&
                   actual.Siguiente.Datos.Prioridad <= pedido.Prioridad)
            {
                actual = actual.Siguiente;
            }

            nuevo.Siguiente = actual.Siguiente;
            actual.Siguiente = nuevo;

            if (nuevo.Siguiente == null)
                fin = nuevo;
        }

        public Pedido Atender()
        {
            if (frente == null)
                return null;

            Pedido pedido = frente.Datos;
            frente = frente.Siguiente;

            if (frente == null)
                fin = null;

            return pedido;
        }

        public Pedido Cancelar(int numero)
        {
            if (frente == null)
                return null;

            if (frente.Datos.Numero == numero)
            {
                Pedido pedido = frente.Datos;
                frente = frente.Siguiente;
                if (frente == null)
                    fin = null;
                return pedido;
            }

            Nodo anterior = frente;

            while (anterior.Siguiente != null && anterior.Siguiente.Datos.Numero != numero)
                anterior = anterior.Siguiente;

            if (anterior.Siguiente == null)
                return null;

            Pedido cancelado = anterior.Siguiente.Datos;

            if (anterior.Siguiente == fin)
                fin = anterior;

            anterior.Siguiente = anterior.Siguiente.Siguiente;
            return cancelado;
        }

        public void Mostrar()
        {
            if (frente == null)
            {
                Console.WriteLine("(sin pedidos)");
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
