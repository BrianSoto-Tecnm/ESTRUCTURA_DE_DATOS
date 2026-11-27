// ==================================================================
// PROYECTO 8. SIMULADOR DE ATENCION BANCARIA
// Tipos de clientes: cliente normal, cliente preferente, adulto
// mayor y persona con prioridad.
// Funciones: generar turno, atender cliente, cancelar turno,
// mostrar clientes esperando, mostrar clientes atendidos, agregar
// prioridad, mostrar tiempo estimado y mostrar numero de clientes
// en espera.
// ==================================================================
using System;

namespace Proyecto8_Banco
{
    internal class Program
    {
        static ColaNormal colaNormal = new ColaNormal();
        static ColaPrioridad colaPrioridad = new ColaPrioridad();
        static int turno = 0;

        static void Main()
        {
            int opcion;

            do
            {
                Console.Clear();

                Console.WriteLine("---Banco---");
                Console.WriteLine("1. Agregar cliente (cola normal)");
                Console.WriteLine("2. Agregar cliente (cola prioridad)");
                Console.WriteLine("3. Atender cola normal");
                Console.WriteLine("4. Atender cola prioridad");
                Console.WriteLine("5. Mostrar colas");
                Console.WriteLine("0. Salir");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Nombre: ");
                        string nombre1 = Console.ReadLine();

                        turno++;
                        colaNormal.Insertar(new Cliente(turno, nombre1, 0));
                        break;

                    case 2:
                        Console.Write("Nombre: ");
                        string nombre2 = Console.ReadLine();

                        Console.Write("Prioridad (1 = alta, 2 = media, 3 = baja): ");
                        int prioridad = int.Parse(Console.ReadLine());

                        turno++;
                        colaPrioridad.Insertar(new Cliente(turno, nombre2, prioridad));
                        break;

                    case 3:
                        Cliente c1 = colaNormal.Atender();
                        if (c1 != null)
                            Console.WriteLine($"Atendiendo: {c1}");
                        else
                            Console.WriteLine("La cola normal esta vacia");
                        Console.ReadKey();
                        break;

                    case 4:
                        Cliente c2 = colaPrioridad.Atender();
                        if (c2 != null)
                            Console.WriteLine($"Atendiendo: {c2}");
                        else
                            Console.WriteLine("La cola de prioridad esta vacia");
                        Console.ReadKey();
                        break;

                    case 5:
                        Console.WriteLine("Cola normal:");
                        colaNormal.Mostrar();

                        Console.WriteLine("Cola de prioridad:");
                        colaPrioridad.Mostrar();
                        Console.ReadKey();
                        break;
                }

            } while (opcion != 0);
        }
    }
}
