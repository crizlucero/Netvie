using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace NetvieWeb.Models
{
    public class Generos : List<Genero>
    {
        /// <summary>
        /// Obtiene la lista de generos de una pelicula
        /// </summary>
        /// <param name="idPelicula">Identificador de una pelicula</param>
        /// <returns>Lista de generos</returns>
        public Generos GetGeneros(int idPelicula)
        {
            using (MySqlConnection conn = new MySqlConnection("Server=localhost;Database=netvie;Uid=root;Pwd=;"))
            {
                MySqlCommand cmd = new MySqlCommand("GetGeneros", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idPeliculas", idPelicula);
                conn.Open();
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        this.Add(new Genero()
                        {
                            idGenero = dr.GetInt32(0),
                            Nombre = dr.GetString(1)
                        });
                    }
                }
                conn.Close();
            }
            return this;
        }
    }
}
