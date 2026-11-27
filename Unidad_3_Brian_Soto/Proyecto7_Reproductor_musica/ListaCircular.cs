// Lista circular de la playlist: la reproduccion es circular
// (la ultima cancion regresa a la primera y viceversa).
// Funciones: reproducir, siguiente, anterior, pausar, buscar,
// eliminar, mostrar y limpiar la playlist.
using System;

namespace Proyecto7_Musica
{
    public class ListaCircular
    {
        private Nodo inicio;
        private Nodo actual;

        private class Nodo
        {
            public Cancion Datos;
            public Nodo Siguiente;

            public Nodo(Cancion cancion)
            {
                Datos = cancion;
            }
        }

        public bool Vacia()
        {
            return inicio == null;
        }

        public void Agregar(Cancion cancion)
        {
            Nodo nuevo = new Nodo(cancion);

            if (inicio == null)
            {
                inicio = nuevo;
                actual = nuevo;
                nuevo.Siguiente = nuevo;
                return;
            }

            Nodo auxiliar = inicio;

            while (auxiliar.Siguiente != inicio)
                auxiliar = auxiliar.Siguiente;

            auxiliar.Siguiente = nuevo;
            nuevo.Siguiente = inicio;
        }

        public Cancion Buscar(string nombre)
        {
            if (inicio == null)
                return null;

            Nodo auxiliar = inicio;

            do
            {
                if (string.Equals(auxiliar.Datos.Nombre, nombre, StringComparison.OrdinalIgnoreCase))
                    return auxiliar.Datos;

                auxiliar = auxiliar.Siguiente;
            } while (auxiliar != inicio);

            return null;
        }

        public bool Eliminar(string nombre)
        {
            if (inicio == null)
                return false;

            Nodo auxiliar = inicio;
            Nodo anterior = null;

            do
            {
                if (string.Equals(auxiliar.Datos.Nombre, nombre, StringComparison.OrdinalIgnoreCase))
                    break;

                anterior = auxiliar;
                auxiliar = auxiliar.Siguiente;
            } while (auxiliar != inicio);

            if (!string.Equals(auxiliar.Datos.Nombre, nombre, StringComparison.OrdinalIgnoreCase))
                return false;

            // Unico nodo de la lista
            if (auxiliar.Siguiente == auxiliar)
            {
                inicio = null;
                actual = null;
                return true;
            }

            if (auxiliar == inicio)
            {
                Nodo ultimo = inicio;

                while (ultimo.Siguiente != inicio)
                    ultimo = ultimo.Siguiente;

                inicio = inicio.Siguiente;
                ultimo.Siguiente = inicio;
            }
            else
            {
                anterior.Siguiente = auxiliar.Siguiente;
            }

            if (actual == auxiliar)
                actual = inicio;

            return true;
        }

        public void Reproducir()
        {
            if (inicio == null)
            {
                Console.WriteLine("No hay canciones en la playlist.");
                return;
            }

            actual = inicio;
            Console.WriteLine($"Reproduciendo: {actual.Datos}");
        }

        public void Siguiente()
        {
            if (actual == null)
            {
                Console.WriteLine("No hay ninguna cancion reproduciendose.");
                return;
            }

            actual = actual.Siguiente;
            Console.WriteLine($"Reproduciendo: {actual.Datos}");
        }

        public void Anterior()
        {
            if (actual == null)
            {
                Console.WriteLine("No hay ninguna cancion reproduciendose.");
                return;
            }

            Nodo auxiliar = inicio;

            while (auxiliar.Siguiente != actual)
                auxiliar = auxiliar.Siguiente;

            actual = auxiliar;
            Console.WriteLine($"Reproduciendo: {actual.Datos}");
        }

        public void Pausar()
        {
            if (actual == null)
            {
                Console.WriteLine("No hay ninguna cancion reproduciendose.");
                return;
            }

            Console.WriteLine($"En pausa: {actual.Datos}");
        }

        public void Mostrar()
        {
            if (inicio == null)
            {
                Console.WriteLine("La playlist esta vacia.");
                return;
            }

            Nodo auxiliar = inicio;

            do
            {
                if (auxiliar == actual)
                    Console.WriteLine($"-> {auxiliar.Datos} (sonando)");
                else
                    Console.WriteLine($"   {auxiliar.Datos}");

                auxiliar = auxiliar.Siguiente;
            } while (auxiliar != inicio);
        }

        public void Limpiar()
        {
            inicio = null;
            actual = null;
        }

        public int Contar()
        {
            if (inicio == null)
                return 0;

            int total = 0;
            Nodo auxiliar = inicio;

            do
            {
                total++;
                auxiliar = auxiliar.Siguiente;
            } while (auxiliar != inicio);

            return total;
        }
    }
}
