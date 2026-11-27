// ==================================================================
// PROYECTO 10. SISTEMA DE GESTION DE PEDIDOS DE UNA TIENDA EN LINEA
// Producto: ID, nombre, precio, existencias y categoria.
// Estructuras: lista enlazada de productos, cola de pedidos
// pendientes, cola de prioridad para urgentes y pila de historial.
// ==================================================================
using System;

namespace Proyecto10_Tienda
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Existencias { get; set; }
        public string Categoria { get; set; }

        public Producto(int id, string nombre, double precio, int existencias, string categoria)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            Existencias = existencias;
            Categoria = categoria;
        }

        public override string ToString()
        {
            return $"ID {Id} | {Nombre} | ${Precio:F2} | Existencias {Existencias} | {Categoria}";
        }
    }
}
