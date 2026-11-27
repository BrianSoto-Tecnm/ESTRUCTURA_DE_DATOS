// ==================================================================
// PROYECTO 7. SISTEMA DE REPRODUCCION DE MUSICA
// Lista doblemente enlazada y lista circular. Crear un repositorio
// musical simulado, con las funciones: agregar cancion, eliminar
// cancion, buscar cancion, reproducir, siguiente, anterior, pausar,
// mostrar playlist, crear playlist y reproduccion circular.
// Lista doble: Cancion A <-> Cancion B <-> Cancion C <-> Cancion D
//
// - El repositorio se guarda en la lista doblemente enlazada.
// - La playlist se guarda en la lista circular, por lo que al
//   llegar a la ultima cancion regresa a la primera (reproduccion
//   circular).
// ==================================================================
using System;

namespace Proyecto7_Musica
{
    internal class Program
    {
        static ListaDoble repositorio = new ListaDoble();
        static ListaCircular playlist = new ListaCircular();
        static string nombrePlaylist = null;

        static void Main()
        {
            int opcion;

            do
            {
                Console.Clear();

                Console.WriteLine("---Reproductor---");
                Console.WriteLine("1. Crear playlist");
                Console.WriteLine("2. Agregar cancion");
                Console.WriteLine("3. Eliminar cancion");
                Console.WriteLine("4. Buscar cancion");
                Console.WriteLine("5. Reproducir");
                Console.WriteLine("6. Siguiente");
                Console.WriteLine("7. Anterior");
                Console.WriteLine("8. Pausar");
                Console.WriteLine("9. Mostrar playlist");
                Console.WriteLine("10. Mostrar repositorio (lista doble)");
                Console.WriteLine("0. Salir");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Nombre de la playlist: ");
                        string nombre = Console.ReadLine();

                        if (repositorio.Vacia())
                        {
                            Console.WriteLine("El repositorio esta vacio, agrega canciones primero.");
                            break;
                        }

                        playlist.Limpiar();

                        foreach (Cancion cancion in repositorio.ObtenerCanciones())
                            playlist.Agregar(cancion);

                        nombrePlaylist = nombre;
                        Console.WriteLine($"Playlist '{nombrePlaylist}' creada con {playlist.Contar()} canciones.");
                        break;

                    case 2:
                        Console.Write("Cancion: ");
                        string nombreCancion = Console.ReadLine();

                        Console.Write("Artista: ");
                        string artista = Console.ReadLine();

                        if (repositorio.Buscar(nombreCancion) != null)
                        {
                            Console.WriteLine("La cancion ya existe en el repositorio.");
                            break;
                        }

                        Cancion cancionNueva = new Cancion(nombreCancion, artista);
                        repositorio.Agregar(cancionNueva);

                        if (nombrePlaylist != null)
                        {
                            playlist.Agregar(cancionNueva);
                            Console.WriteLine("Cancion agregada al repositorio y a la playlist.");
                        }
                        else
                            Console.WriteLine("Cancion agregada al repositorio.");
                        break;

                    case 3:
                        Console.Write("Cancion a eliminar: ");
                        string nombreEliminar = Console.ReadLine();

                        bool eliminada = repositorio.Eliminar(nombreEliminar);

                        if (nombrePlaylist != null)
                            playlist.Eliminar(nombreEliminar);

                        if (eliminada)
                            Console.WriteLine("Cancion eliminada del repositorio y de la playlist.");
                        else
                            Console.WriteLine("No se encontro la cancion.");
                        break;

                    case 4:
                        Console.Write("Cancion a buscar: ");
                        string nombreBuscar = Console.ReadLine();

                        Cancion encontrada = repositorio.Buscar(nombreBuscar);

                        if (encontrada != null)
                            Console.WriteLine(encontrada);
                        else
                            Console.WriteLine("No se encontro la cancion.");
                        break;

                    case 5:
                        playlist.Reproducir();
                        break;

                    case 6:
                        playlist.Siguiente();
                        break;

                    case 7:
                        playlist.Anterior();
                        break;

                    case 8:
                        playlist.Pausar();
                        break;

                    case 9:
                        if (nombrePlaylist == null)
                            Console.WriteLine("Aun no se ha creado la playlist.");
                        else
                        {
                            Console.WriteLine($"Playlist: {nombrePlaylist}");
                            playlist.Mostrar();
                        }
                        break;

                    case 10:
                        repositorio.Mostrar();
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
