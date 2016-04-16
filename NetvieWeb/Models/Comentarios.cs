using System.Collections.Generic;

namespace NetvieWeb.Models
{
    public class Comentarios : List<Comentario>
    {
        /// <summary>
        /// Comentarios hechos por un usuario
        /// </summary>
        /// <param name="Usuario">Identificador del usuario</param>
        /// <returns>Lista de comentarios</returns>
        public Comentarios getComentariosUsuario(int Usuario)
        {
            return this;
        }
        /// <summary>
        /// Obtiene los comentarios hechos a una pelicula
        /// </summary>
        /// <param name="Pelicula">Identificador de la pelicula</param>
        /// <returns>Lista de comentarios</returns>
        public Comentarios getComentariosPelicula(int Pelicula)
        {
            return this;
        }
    }
}
