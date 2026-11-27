// ==================================================================
// EXAMEN UNIDAD 3 - OPCION A: BANCO
// Implementa una cola FIFO para clientes ordinarios y una cola de
// prioridad para clientes con atencion preferente.
// Operaciones: agregar cliente, atender y mostrar pendientes.
// Validaciones: nombre no vacio, prioridad entre 1 y 3, opciones
// numericas y control de colas vacias.
// ==================================================================
using System;

namespace Examen_Banco
{
    internal class Program
    {
        static readonly ColaNormal ordinarios = new ColaNormal();
        static readonly ColaPrioridad preferentes = new ColaPrioridad();
        static int siguienteTurno = 1;

        static void Main()
        {
            int opcion;

            do
            {
                Limpiar();

                Console.WriteLine("===== BANCO: ATENCION DE CLIENTES =====");
                Console.WriteLine($"Pendientes: {preferentes.Contar() + ordinarios.Contar()} " +
                                  $"(preferentes: {preferentes.Contar()}, ordinarios: {ordinarios.Contar()})");
                Console.WriteLine("1. Agregar cliente ordinario");
                Console.WriteLine("2. Agregar cliente preferente");
                Console.WriteLine("3. Atender siguiente (preferentes primero)");
                Console.WriteLine("4. Atender cliente ordinario");
                Console.WriteLine("5. Atender cliente preferente");
                Console.WriteLine("6. Mostrar clientes pendientes");
                Console.WriteLine("0. Salir");
                Console.Write("Opcion: ");

                opcion = LeerEntero();

                switch (opcion)
                {
                    case 1:
                        AgregarOrdinario();
                        break;

                    case 2:
                        AgregarPreferente();
                        break;

                    case 3:
                        AtenderSiguiente();
                        break;

                    case 4:
                        AtenderOrdinario();
                        break;

                    case 5:
                        AtenderPreferente();
                        break;

                    case 6:
                        MostrarPendientes();
                        break;

                    case 0:
                        Console.WriteLine("Fin del programa.");
                        break;

                    default:
                        Console.WriteLine("Opcion invalida. Use una opcion del menu.");
                        Pausar();
                        break;
                }

            } while (opcion != 0);
        }

        static void AgregarOrdinario()
        {
            string nombre = LeerTexto("Nombre del cliente: ");

            Cliente cliente = new Cliente(siguienteTurno, nombre, 0);
            siguienteTurno++;

            ordinarios.Encolar(cliente);

            Console.WriteLine($"Cliente agregado a la cola ordinaria: {cliente}");
            Pausar();
        }

        static void AgregarPreferente()
        {
            string nombre = LeerTexto("Nombre del cliente: ");
            int prioridad = LeerPrioridad();

            Cliente cliente = new Cliente(siguienteTurno, nombre, prioridad);
            siguienteTurno++;

            preferentes.Encolar(cliente);

            Console.WriteLine($"Cliente agregado a la cola preferente: {cliente}");
            Pausar();
        }

        static void AtenderSiguiente()
        {
            Cliente? cliente;

            // Primero se atiende a los preferentes; si no hay, a los ordinarios.
            if (!preferentes.Vacia())
                cliente = preferentes.Desencolar();
            else
                cliente = ordinarios.Desencolar();

            if (cliente == null)
                Console.WriteLine("No hay clientes pendientes.");
            else
                Console.WriteLine($"Atendiendo: {cliente}");

            Pausar();
        }

        static void AtenderOrdinario()
        {
            Cliente? cliente = ordinarios.Desencolar();

            if (cliente == null)
                Console.WriteLine("No hay clientes ordinarios en espera.");
            else
                Console.WriteLine($"Atendiendo (cola ordinaria): {cliente}");

            Pausar();
        }

        static void AtenderPreferente()
        {
            Cliente? cliente = preferentes.Desencolar();

            if (cliente == null)
                Console.WriteLine("No hay clientes preferentes en espera.");
            else
                Console.WriteLine($"Atendiendo (cola preferente): {cliente}");

            Pausar();
        }

        static void MostrarPendientes()
        {
            Console.WriteLine("--- CLIENTES PREFERENTES (se atienden primero) ---");
            preferentes.Mostrar();

            Console.WriteLine("--- CLIENTES ORDINARIOS (FIFO) ---");
            ordinarios.Mostrar();

            Console.WriteLine($"Total de pendientes: {preferentes.Contar() + ordinarios.Contar()}");
            Pausar();
        }

        static int LeerEntero()
        {
            while (true)
            {
                string? entrada = Console.ReadLine();

                if (int.TryParse(entrada, out int valor))
                    return valor;

                Console.Write("Debe ingresar un numero valido. Intente de nuevo: ");
            }
        }

        static string LeerTexto(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                string? texto = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(texto))
                    return texto.Trim();

                Console.WriteLine("El nombre no puede estar vacio.");
            }
        }

        static int LeerPrioridad()
        {
            while (true)
            {
                Console.WriteLine("Prioridad: 1 = Alta, 2 = Media, 3 = Baja");
                Console.Write("Prioridad: ");
                string? entrada = Console.ReadLine();

                if (int.TryParse(entrada, out int prioridad) &&
                    prioridad >= 1 && prioridad <= 3)
                {
                    return prioridad;
                }

                Console.WriteLine("Prioridad invalida. Use 1, 2 o 3.");
            }
        }

        static void Limpiar()
        {
            try
            {
                Console.Clear();
            }
            catch
            {
                // Si la salida esta redirigida, Console.Clear no esta disponible.
            }
        }

        static void Pausar()
        {
            try
            {
                Console.ReadKey();
            }
            catch
            {
                // Si la entrada esta redirigida, Console.ReadKey no esta disponible.
            }
        }
    }
}
