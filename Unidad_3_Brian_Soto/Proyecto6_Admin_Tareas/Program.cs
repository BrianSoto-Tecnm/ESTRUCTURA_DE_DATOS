// ==================================================================
// PROYECTO 6. ADMINISTRADOR DE TAREAS
// Para este proyecto utilizaremos una lista doblemente enlazada.
// Cada tarea tiene id, descripcion y estado (empieza en "Pendiente").
// Funciones: agregar tarea al final de la lista, verificar si la
// lista esta vacia y buscar una tarea por su id.
// ==================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto6_Tareas;

namespace Proyecto6_Admin_Tareas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListaDoble lista = new ListaDoble();

            lista.Agregar(new Tarea(1, "Hacer la tarea de matematicas"));
            lista.Agregar(new Tarea(2, "Lavar los trastes"));
            lista.Agregar(new Tarea(3, "Comprar despensa"));

            Console.WriteLine("La lista esta vacia: " + lista.Vacia());

            Console.Write("Id de la tarea a buscar: ");
            int id = int.Parse(Console.ReadLine());

            Tarea tarea = lista.Buscar(id);

            if (tarea != null)
                Console.WriteLine(tarea);
            else
                Console.WriteLine("No se encontro la tarea.");

            Console.WriteLine("Fin del programa.");
            Console.ReadLine();
        }
    }
}
