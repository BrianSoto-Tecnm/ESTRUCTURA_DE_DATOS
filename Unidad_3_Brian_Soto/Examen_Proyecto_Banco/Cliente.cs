namespace Examen_Banco
{
    // Representa a un cliente que llega al banco.
    // Prioridad: 0 = ordinario, 1 = alta, 2 = media, 3 = baja.
    public class Cliente
    {
        public int Turno { get; set; }
        public string Nombre { get; set; }
        public int Prioridad { get; set; }

        public Cliente(int turno, string nombre, int prioridad)
        {
            Turno = turno;
            Nombre = nombre;
            Prioridad = prioridad;
        }

        public string Tipo => Prioridad == 0 ? "Ordinario" : "Preferente";

        public string PrioridadTexto => Prioridad switch
        {
            1 => "Alta",
            2 => "Media",
            3 => "Baja",
            _ => "Normal"
        };

        public override string ToString()
        {
            if (Prioridad == 0)
                return $"Turno {Turno:000} | {Nombre} | {Tipo}";

            return $"Turno {Turno:000} | {Nombre} | {Tipo} (prioridad {PrioridadTexto})";
        }
    }
}
