// ==================================================================
// PROYECTO 8. SIMULADOR DE ATENCION BANCARIA
// Tipos de clientes: cliente normal, cliente preferente, adulto
// mayor y persona con prioridad.
// Funciones: generar turno, atender cliente, cancelar turno,
// mostrar clientes esperando, mostrar clientes atendidos, agregar
// prioridad, mostrar tiempo estimado y mostrar numero de clientes
// en espera.
//
// Todos los clientes se atienden en una sola cola de prioridad:
// PRIORIDAD (1) -> ADULTO MAYOR (2) -> PREFERENTE (3) -> NORMAL (4)
// ==================================================================
using System;
using System.Collections.Generic;

namespace Proyecto8_Banco
{
    internal class Program
    {
        static ColaPrioridad espera = new ColaPrioridad();
        static List<Cliente> atendidos = new List<Cliente>();
        static int contadorTurno = 0;

        // Tiempo promedio de atencion por cliente (minutos)
        const int TiempoPorCliente = 3;

        static void Main()
        {
            int opcion;

            do
            {
                Console.Clear();

                Console.WriteLine("---Banco---");
                Console.WriteLine("1. Generar turno");
                Console.WriteLine("2. Atender cliente");
                Console.WriteLine("3. Cancelar turno");
                Console.WriteLine("4. Mostrar clientes esperando");
                Console.WriteLine("5. Mostrar clientes atendidos");
                Console.WriteLine("6. Agregar prioridad");
                Console.WriteLine("7. Mostrar tiempo estimado");
                Console.WriteLine("8. Mostrar numero de clientes en espera");
                Console.WriteLine("0. Salir");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        GenerarTurno();
                        break;

                    case 2:
                        Cliente porAtender = espera.Atender();

                        if (porAtender != null)
                        {
                            atendidos.Add(porAtender);
                            Console.WriteLine("Atendiendo: " + porAtender);
                        }
                        else
                            Console.WriteLine("No hay clientes esperando.");
                        break;

                    case 3:
                        Console.Write("Turno a cancelar: ");
                        int turnoCancelar = int.Parse(Console.ReadLine());

                        Cliente cancelado = espera.Cancelar(turnoCancelar);

                        if (cancelado != null)
                            Console.WriteLine("Turno cancelado: " + cancelado);
                        else
                            Console.WriteLine("No se encontro ese turno en espera.");
                        break;

                    case 4:
                        espera.Mostrar();
                        break;

                    case 5:
                        if (atendidos.Count == 0)
                            Console.WriteLine("Todavia no se ha atendido a nadie.");
                        else
                        {
                            foreach (Cliente cliente in atendidos)
                                Console.WriteLine(cliente);
                        }
                        break;

                    case 6:
                        Console.Write("Turno a dar prioridad: ");
                        int turnoPrioridad = int.Parse(Console.ReadLine());

                        Cliente clientePrioridad = espera.Buscar(turnoPrioridad);

                        if (clientePrioridad != null)
                        {
                            clientePrioridad.Prioridad = 1;
                            clientePrioridad.Tipo = "PRIORIDAD";
                            Console.WriteLine("Prioridad asignada: " + clientePrioridad);
                        }
                        else
                            Console.WriteLine("No se encontro ese turno en espera.");
                        break;

                    case 7:
                        int enEspera = espera.Contar();
                        Console.WriteLine($"Clientes en espera: {enEspera}");
                        Console.WriteLine($"Tiempo estimado de espera: {enEspera * TiempoPorCliente} minutos ({TiempoPorCliente} min por cliente)");
                        break;

                    case 8:
                        Console.WriteLine($"Numero de clientes en espera: {espera.Contar()}");
                        break;
                }

                if (opcion != 0)
                {
                    Console.WriteLine("\nPresiona una tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 0);
        }

        static void GenerarTurno()
        {
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.WriteLine("Tipo de cliente:");
            Console.WriteLine("1. Normal");
            Console.WriteLine("2. Preferente");
            Console.WriteLine("3. Adulto mayor");
            Console.WriteLine("4. Persona con prioridad");
            Console.Write("Opcion: ");
            int tipo = int.Parse(Console.ReadLine());

            string tipoCliente;
            int prioridad;

            switch (tipo)
            {
                case 2:
                    tipoCliente = "PREFERENTE";
                    prioridad = 3;
                    break;

                case 3:
                    tipoCliente = "ADULTO MAYOR";
                    prioridad = 2;
                    break;

                case 4:
                    tipoCliente = "PRIORIDAD";
                    prioridad = 1;
                    break;

                default:
                    tipoCliente = "NORMAL";
                    prioridad = 4;
                    break;
            }

            contadorTurno++;

            Cliente cliente = new Cliente(contadorTurno, nombre, tipoCliente, prioridad);
            espera.Insertar(cliente);

            Console.WriteLine("Turno generado: " + cliente);
        }
    }
}
