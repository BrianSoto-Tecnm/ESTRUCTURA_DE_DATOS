namespace Examen_Banco
{
    // Nodo genérico de las colas enlazadas: guarda el cliente y el siguiente nodo.
    public class Nodo
    {
        public Cliente Datos { get; set; }
        public Nodo? Siguiente { get; set; }

        public Nodo(Cliente cliente)
        {
            Datos = cliente;
            Siguiente = null;
        }
    }
}
