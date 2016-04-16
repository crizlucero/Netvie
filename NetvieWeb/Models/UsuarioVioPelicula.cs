using MySql.Data.MySqlClient;
using System;

namespace NetvieWeb.Models
{
    public class UsuarioVioPelicula : PersonaPelicula
    {
        DateTime Fecha { get; set; }

        /// <summary>
        /// Agrega una vista del usuario
        /// </summary>
        /// <param name="idPelicula">Identificador de la pelicula</param>
        /// <param name="idUsuario">Identificador del usuario</param>
        public void PeliculaVista(int idPelicula, int idUsuario)
        {
            using (MySqlConnection conn = new MySqlConnection("Server=localhost;Database=netvie;Uid=root;Pwd=;"))
            {
                MySqlCommand cmd = new MySqlCommand("SetPeliculaVista", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Pelicula", idPelicula);
                cmd.Parameters.AddWithValue("Usuario", idUsuario);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
