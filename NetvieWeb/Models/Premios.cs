using System.Collections.Generic;

namespace NetvieWeb.Models
{
    class Premios : List<Premio>
    {
        /// <summary>
        /// Obtiene los premios de una pelicula
        /// </summary>
        /// <param name="Pelicula">Identificador de la pelicula</param>
        /// <returns>Lista de premios</returns>
        public Premios GetPremiosPelicula(int Pelicula)
        {
            return this;
        }
    }
}
