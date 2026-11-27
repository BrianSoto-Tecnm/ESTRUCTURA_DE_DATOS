// ==================================================================
// PROYECTO 9. SISTEMA DE CONTROL DE PROCESOS DE UN SISTEMA OPERATIVO
// Menu con las funciones: crear, eliminar, ejecutar, bloquear,
// desbloquear, mostrar, buscar y administrar la cola de procesos.
// ==================================================================
using System;
using Proyecto9_SO;

namespace Proyecto9_Control_SO
{
    internal class Program
    {
        static ColaProcesos cola = new ColaProcesos();

        static void Main()
        {
            int opcion;

            do
            {
                Console.Clear();

                Console.WriteLine("---Sistema Operativo---");
                Console.WriteLine("1. Crear proceso");
                Console.WriteLine("2. Eliminar proceso");
                Console.WriteLine("3. Ejecutar proceso");
                Console.WriteLine("4. Bloquear proceso");
                Console.WriteLine("5. Desbloquear proceso");
                Console.WriteLine("6. Mostrar procesos");
                Console.WriteLine("7. Buscar proceso");
                Console.WriteLine("8. Mostrar cola de procesos");
                Console.WriteLine("0. Salir");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("PID (ej. P01): ");
                        string pid = Console.ReadLine();

                        if (cola.Buscar(pid) != null)
                        {
                            Console.WriteLine("Ya existe un proceso con ese PID.");
                            break;
                        }

                        Console.Write("Nombre: ");
                        string nombre = Console.ReadLine();

                        Console.Write("Prioridad: ");
                        int prioridad = int.Parse(Console.ReadLine());

                        Console.Write("Tiempo de ejecucion (s): ");
                        int tiempo = int.Parse(Console.ReadLine());

                        cola.Crear(new Proceso(pid, nombre, prioridad, tiempo));
                        Console.WriteLine("Proceso creado con estado NUEVO.");
                        break;

                    case 2:
                        Console.Write("PID a eliminar: ");
                        string pidEliminar = Console.ReadLine();

                        if (cola.Eliminar(pidEliminar))
                            Console.WriteLine("Proceso TERMINADO y eliminado de la cola.");
                        else
                            Console.WriteLine("No se encontro el proceso.");
                        break;

                    case 3:
                        Console.Write("PID a ejecutar: ");
                        string pidEjecutar = Console.ReadLine();

                        if (cola.Ejecutar(pidEjecutar))
                            Console.WriteLine("Proceso en estado EJECUTANDO.");
                        else
                            Console.WriteLine("No se encontro el proceso.");
                        break;

                    case 4:
                        Console.Write("PID a bloquear: ");
                        string pidBloquear = Console.ReadLine();

                        if (cola.Bloquear(pidBloquear))
                            Console.WriteLine("Proceso en estado BLOQUEADO.");
                        else
                            Console.WriteLine("No se encontro el proceso.");
                        break;

                    case 5:
                        Console.Write("PID a desbloquear: ");
                        string pidDesbloquear = Console.ReadLine();

                        if (cola.Desbloquear(pidDesbloquear))
                            Console.WriteLine("Proceso en estado LISTO.");
                        else
                            Console.WriteLine("No se encontro el proceso.");
                        break;

                    case 6:
                        cola.Mostrar();
                        break;

                    case 7:
                        Console.Write("PID a buscar: ");
                        string pidBuscar = Console.ReadLine();

                        Proceso encontrado = cola.Buscar(pidBuscar);

                        if (encontrado != null)
                            Console.WriteLine(encontrado);
                        else
                            Console.WriteLine("No se encontro el proceso.");
                        break;

                    case 8:
                        cola.MostrarCola();
                        break;
                }

                if (opcion != 0)
                {
                    Console.WriteLine("\nPresiona una tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 0);
        }
    }
}
