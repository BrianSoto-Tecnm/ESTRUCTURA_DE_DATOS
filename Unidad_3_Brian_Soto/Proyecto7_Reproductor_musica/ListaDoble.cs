// Lista doblemente enlazada del repositorio musical:
// Cancion A <-> Cancion B <-> Cancion C <-> Cancion D
// Funciones: agregar, eliminar, buscar y mostrar canciones.
using System;
using System.Collections.Generic;

namespace Proyecto7_Musica
{
    public class ListaDoble
    {
        private Nodo inicio;

        private class Nodo
        {
            public Cancion Datos;
            public Nodo Anterior;
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
                return;
            }

            Nodo actual = inicio;

            while (actual.Siguiente != null)
                actual = actual.Siguiente;

            actual.Siguiente = nuevo;
            nuevo.Anterior = actual;
        }

        public Cancion Buscar(string nombre)
        {
            Nodo actual = inicio;

            while (actual != null)
            {
                if (string.Equals(actual.Datos.Nombre, nombre, StringComparison.OrdinalIgnoreCase))
                    return actual.Datos;

                actual = actual.Siguiente;
            }

            return null;
        }

        public bool Eliminar(string nombre)
        {
            if (inicio == null)
                return false;

            if (string.Equals(inicio.Datos.Nombre, nombre, StringComparison.OrdinalIgnoreCase))
            {
                inicio = inicio.Siguiente;

                if (inicio != null)
                    inicio.Anterior = null;

                return true;
            }

            Nodo actual = inicio;

            while (actual != null &&
                   !string.Equals(actual.Datos.Nombre, nombre, StringComparison.OrdinalIgnoreCase))
            {
                actual = actual.Siguiente;
            }

            if (actual == null)
                return false;

            actual.Anterior.Siguiente = actual.Siguiente;

            if (actual.Siguiente != null)
                actual.Siguiente.Anterior = actual.Anterior;

            return true;
        }

        public void Mostrar()
        {
            if (inicio == null)
            {
                Console.WriteLine("El repositorio esta vacio.");
                return;
            }

            string lista = "";
            Nodo actual = inicio;

            while (actual != null)
            {
                lista += actual.Datos.Nombre;

                if (actual.Siguiente != null)
                    lista += " <-> ";

                actual = actual.Siguiente;
            }

            Console.WriteLine("Repositorio: " + lista);

            actual = inicio;

            while (actual != null)
            {
                Console.WriteLine(actual.Datos);
                actual = actual.Siguiente;
            }
        }

        public List<Cancion> ObtenerCanciones()
        {
            List<Cancion> canciones = new List<Cancion>();
            Nodo actual = inicio;

            while (actual != null)
            {
                canciones.Add(actual.Datos);
                actual = actual.Siguiente;
            }

            return canciones;
        }
    }
}
