using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace Proyecto7_Musica
{
    public class Cancion
    {
        public String Nombre { get; set; }
        public string Artista { get; set; }

        public Cancion (string nombre, string artista)
        {
            Nombre = nombre;
            Artista = artista;
        }
    }
    

}
