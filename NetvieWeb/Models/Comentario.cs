using System;

namespace NetvieWeb.Models
{
    public class Comentario
    {
        int idComentario { get; set; }
        int Puntuacion { get; set; }
        string Comentarios { get; set; } 
        DateTime Fecha { get; set; }
        Pelicula Pelicula { get; set; }
        Usuario Usuario { get; set; }
        /// <summary>
        /// Obtiene un sólo comentario del usuario respecto a una pelicula
        /// </summary>
        /// <param name="Usuario">Identificador del usuario</param>
        /// <param name="Pelicula">Identificador de la pelicula</param>
        /// <returns>Un comentario</returns>
        public Comentario GetComentario(int Usuario, int Pelicula)
        {
            return this;
        }
    }
}
