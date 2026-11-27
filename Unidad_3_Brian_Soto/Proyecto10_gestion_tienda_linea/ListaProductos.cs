// Lista enlazada de productos: registrar, buscar, eliminar,
// consultar inventario, contar y valor total.
using System;

namespace Proyecto10_Tienda
{
    public class ListaProductos
    {
        private Nodo inicio;

        private class Nodo
        {
            public Producto Datos;
            public Nodo Siguiente;

            public Nodo(Producto producto)
            {
                Datos = producto;
            }
        }

        public void Registrar(Producto producto)
        {
            Nodo nuevo = new Nodo(producto);

            if (inicio == null)
            {
                inicio = nuevo;
                return;
            }

            Nodo actual = inicio;

            while (actual.Siguiente != null)
                actual = actual.Siguiente;

            actual.Siguiente = nuevo;
        }

        public Producto Buscar(int id)
        {
            Nodo actual = inicio;

            while (actual != null)
            {
                if (actual.Datos.Id == id)
                    return actual.Datos;

                actual = actual.Siguiente;
            }

            return null;
        }

        public bool Eliminar(int id)
        {
            if (inicio == null)
                return false;

            if (inicio.Datos.Id == id)
            {
                inicio = inicio.Siguiente;
                return true;
            }

            Nodo anterior = inicio;

            while (anterior.Siguiente != null && anterior.Siguiente.Datos.Id != id)
                anterior = anterior.Siguiente;

            if (anterior.Siguiente == null)
                return false;

            anterior.Siguiente = anterior.Siguiente.Siguiente;
            return true;
        }

        public void Mostrar()
        {
            if (inicio == null)
            {
                Console.WriteLine("El inventario esta vacio.");
                return;
            }

            Nodo actual = inicio;

            while (actual != null)
            {
                Console.WriteLine(actual.Datos);
                actual = actual.Siguiente;
            }
        }

        public int Contar()
        {
            int total = 0;
            Nodo actual = inicio;

            while (actual != null)
            {
                total++;
                actual = actual.Siguiente;
            }

            return total;
        }

        public double ValorTotal()
        {
            double total = 0;
            Nodo actual = inicio;

            while (actual != null)
            {
                total += actual.Datos.Precio * actual.Datos.Existencias;
                actual = actual.Siguiente;
            }

            return total;
        }
    }
}
