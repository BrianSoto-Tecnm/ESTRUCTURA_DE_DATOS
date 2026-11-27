// Pedido: numero, cliente, fecha, productos, total, prioridad y
// estado. Los productos se guardan como detalle (producto + cantidad).
using System;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto10_Tienda
{
    public class Pedido
    {
        public int Numero { get; set; }
        public string Cliente { get; set; }
        public string Fecha { get; set; }
        public int Prioridad { get; set; }
        public string Estado { get; set; }
        public double Total { get; set; }
        public List<Detalle> Detalles { get; set; }

        public class Detalle
        {
            public Producto Producto { get; set; }
            public int Cantidad { get; set; }

            public Detalle(Producto producto, int cantidad)
            {
                Producto = producto;
                Cantidad = cantidad;
            }
        }

        public Pedido(int numero, string cliente, string fecha, int prioridad)
        {
            Numero = numero;
            Cliente = cliente;
            Fecha = fecha;
            Prioridad = prioridad;
            Estado = "PENDIENTE";
            Total = 0;
            Detalles = new List<Detalle>();
        }

        public void AgregarDetalle(Producto producto, int cantidad)
        {
            Detalles.Add(new Detalle(producto, cantidad));
            Total += producto.Precio * cantidad;
        }

        public override string ToString()
        {
            string productos = string.Join(", ",
                Detalles.Select(d => d.Cantidad + "x " + d.Producto.Nombre));

            return $"Pedido #{Numero} | {Cliente} | {Fecha} | {productos} | " +
                   $"Total ${Total:F2} | Prioridad {Prioridad} | {Estado}";
        }
    }
}
