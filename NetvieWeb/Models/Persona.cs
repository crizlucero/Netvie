using System;

namespace NetvieWeb.Models
{
    public class Persona : DatosGenerales
    {
        public DateTime Nacimiento { get; set; }
        public string Estatus { get; set; }
        public Pais Pais { get; set; }

        public Persona()
        {
        }
    }
}
