// ==================================================================
// PROYECTO 10. SISTEMA DE GESTION DE PEDIDOS DE UNA TIENDA EN LINEA
// Menu con las funciones principales: registrar, buscar y eliminar
// producto; registrar, cancelar, procesar y atender pedidos; mostrar
// pendientes, historial, cliente y estadisticas.
// ==================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using Proyecto10_Tienda;

namespace Proyecto10_Gestion_Tienda
{
    internal class Program
    {
        static ListaProductos inventario = new ListaProductos();
        static ColaPedidos pendientes = new ColaPedidos(false);   // cola normal
        static ColaPedidos urgentes = new ColaPedidos(true);      // cola de prioridad
        static PilaHistorial historial = new PilaHistorial();
        static List<Pedido> registro = new List<Pedido>();
        static int contadorPedidos = 0;

        static void Main()
        {
            int opcion;

            do
            {
                Console.Clear();

                Console.WriteLine("---Tienda en linea---");
                Console.WriteLine("1. Registrar producto");
                Console.WriteLine("2. Buscar producto");
                Console.WriteLine("3. Eliminar producto");
                Console.WriteLine("4. Consultar inventario");
                Console.WriteLine("5. Registrar pedido");
                Console.WriteLine("6. Cancelar pedido");
                Console.WriteLine("7. Procesar pedido");
                Console.WriteLine("8. Atender pedido urgente");
                Console.WriteLine("9. Mostrar pedidos pendientes");
                Console.WriteLine("10. Buscar cliente");
                Console.WriteLine("11. Mostrar historial");
                Console.WriteLine("12. Mostrar estadisticas");
                Console.WriteLine("0. Salir");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Id: ");
                        int id = int.Parse(Console.ReadLine());

                        if (inventario.Buscar(id) != null)
                        {
                            Console.WriteLine("Ya existe un producto con ese Id.");
                            break;
                        }

                        Console.Write("Nombre: ");
                        string nombre = Console.ReadLine();

                        Console.Write("Precio: ");
                        double precio = double.Parse(Console.ReadLine());

                        Console.Write("Existencias: ");
                        int existencias = int.Parse(Console.ReadLine());

                        Console.Write("Categoria: ");
                        string categoria = Console.ReadLine();

                        inventario.Registrar(new Producto(id, nombre, precio, existencias, categoria));
                        historial.Push($"Producto {nombre} registrado");
                        Console.WriteLine("Producto registrado.");
                        break;

                    case 2:
                        Console.Write("Id del producto: ");
                        int idBuscar = int.Parse(Console.ReadLine());

                        Producto producto = inventario.Buscar(idBuscar);

                        if (producto != null)
                            Console.WriteLine(producto);
                        else
                            Console.WriteLine("No se encontro el producto.");
                        break;

                    case 3:
                        Console.Write("Id del producto a eliminar: ");
                        int idEliminar = int.Parse(Console.ReadLine());

                        Producto productoEliminar = inventario.Buscar(idEliminar);

                        if (productoEliminar != null && inventario.Eliminar(idEliminar))
                        {
                            historial.Push($"Producto {productoEliminar.Nombre} eliminado");
                            Console.WriteLine("Producto eliminado.");
                        }
                        else
                            Console.WriteLine("No se encontro el producto.");
                        break;

                    case 4:
                        inventario.Mostrar();
                        Console.WriteLine($"Valor total del inventario: ${inventario.ValorTotal():F2}");
                        break;

                    case 5:
                        RegistrarPedido();
                        break;

                    case 6:
                        Console.Write("Numero de pedido a cancelar: ");
                        int numCancelar = int.Parse(Console.ReadLine());

                        Pedido cancelado = pendientes.Cancelar(numCancelar);

                        if (cancelado == null)
                            cancelado = urgentes.Cancelar(numCancelar);

                        if (cancelado != null)
                        {
                            cancelado.Estado = "CANCELADO";
                            historial.Push($"Pedido #{cancelado.Numero} cancelado");
                            Console.WriteLine("Pedido cancelado: " + cancelado);
                        }
                        else
                            Console.WriteLine("No se encontro el pedido.");
                        break;

                    case 7:
                        Pedido pendiente = pendientes.Atender();

                        if (pendiente != null)
                        {
                            pendiente.Estado = "PROCESADO";
                            DescontarExistencias(pendiente);
                            historial.Push($"Pedido #{pendiente.Numero} procesado");
                            Console.WriteLine("Pedido procesado: " + pendiente);
                        }
                        else
                            Console.WriteLine("No hay pedidos pendientes.");
                        break;

                    case 8:
                        Pedido urgente = urgentes.Atender();

                        if (urgente != null)
                        {
                            urgente.Estado = "PROCESADO";
                            DescontarExistencias(urgente);
                            historial.Push($"Pedido urgente #{urgente.Numero} atendido");
                            Console.WriteLine("Pedido urgente atendido: " + urgente);
                        }
                        else
                            Console.WriteLine("No hay pedidos urgentes.");
                        break;

                    case 9:
                        Console.WriteLine("Pedidos pendientes:");
                        pendientes.Mostrar();

                        Console.WriteLine("Pedidos urgentes:");
                        urgentes.Mostrar();
                        break;

                    case 10:
                        Console.Write("Nombre del cliente: ");
                        string clienteBuscar = Console.ReadLine();

                        List<Pedido> delCliente = registro
                            .Where(p => p.Cliente.Equals(clienteBuscar, StringComparison.OrdinalIgnoreCase))
                            .ToList();

                        if (delCliente.Count > 0)
                        {
                            foreach (Pedido p in delCliente)
                                Console.WriteLine(p);
                        }
                        else
                            Console.WriteLine("No se encontro ningun pedido de ese cliente.");
                        break;

                    case 11:
                        historial.Mostrar();
                        break;

                    case 12:
                        Console.WriteLine($"Productos en inventario: {inventario.Contar()}");
                        Console.WriteLine($"Valor del inventario: ${inventario.ValorTotal():F2}");
                        Console.WriteLine($"Pedidos registrados: {registro.Count}");
                        Console.WriteLine($"Pendientes: {pendientes.Contar()}");
                        Console.WriteLine($"Urgentes: {urgentes.Contar()}");
                        Console.WriteLine($"Procesados: {registro.Count(p => p.Estado == "PROCESADO")}");
                        Console.WriteLine($"Cancelados: {registro.Count(p => p.Estado == "CANCELADO")}");
                        Console.WriteLine($"Operaciones en historial: {historial.Contar()}");
                        break;
                }

                if (opcion != 0)
                {
                    Console.WriteLine("\nPresiona una tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 0);
        }

        static void RegistrarPedido()
        {
            contadorPedidos++;

            Console.Write("Cliente: ");
            string cliente = Console.ReadLine();

            Console.Write("Fecha (dd/mm/aaaa): ");
            string fecha = Console.ReadLine();

            Pedido nuevo = new Pedido(contadorPedidos, cliente, fecha, 0);

            Console.WriteLine("Agregar productos (Id 0 para terminar):");

            while (true)
            {
                Console.Write("  Id del producto: ");
                int idProducto = int.Parse(Console.ReadLine());

                if (idProducto == 0)
                    break;

                Producto producto = inventario.Buscar(idProducto);

                if (producto == null)
                {
                    Console.WriteLine("  No existe ese producto.");
                    continue;
                }

                Console.Write("  Cantidad: ");
                int cantidad = int.Parse(Console.ReadLine());

                if (cantidad <= 0 || cantidad > producto.Existencias)
                {
                    Console.WriteLine("  Existencias insuficientes.");
                    continue;
                }

                nuevo.AgregarDetalle(producto, cantidad);
                Console.WriteLine("  Agregado. Total parcial: $" + nuevo.Total.ToString("F2"));
            }

            if (nuevo.Detalles.Count == 0)
            {
                contadorPedidos--;
                Console.WriteLine("El pedido no tiene productos, no se registro.");
                return;
            }

            Console.Write("¿Es urgente? (s/n): ");
            string urgente = Console.ReadLine();

            if (urgente == "s" || urgente == "S")
            {
                Console.Write("Prioridad (1 = alta, 2 = media, 3 = baja): ");
                nuevo.Prioridad = int.Parse(Console.ReadLine());
                urgentes.Insertar(nuevo);
            }
            else
            {
                nuevo.Prioridad = 3;
                pendientes.Insertar(nuevo);
            }

            registro.Add(nuevo);
            historial.Push($"Pedido #{nuevo.Numero} registrado para {cliente}");

            Console.WriteLine($"Pedido #{nuevo.Numero} registrado. Total ${nuevo.Total:F2}");
        }

        static void DescontarExistencias(Pedido pedido)
        {
            foreach (Pedido.Detalle detalle in pedido.Detalles)
                detalle.Producto.Existencias -= detalle.Cantidad;
        }
    }
}
