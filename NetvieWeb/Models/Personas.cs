using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace NetvieWeb.Models
{
    public class Personas : List<Persona>
    {
        /// <summary>
        /// Lista de personas incluidas en una pelicula
        /// </summary>
        /// <param name="idPelicula">identificador de la pelicula</param>
        /// <returns>Lista de personas</returns>
        public Personas GetPersonasPeliculas(int idPelicula)
        {
            using (MySqlConnection conn = new MySqlConnection("Server=localhost;Database=netvie;Uid=root;Pwd=;"))
            {
                MySqlCommand cmd = new MySqlCommand("GetPersonasPeliculas", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Pelicula", idPelicula);
                conn.Open();
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        this.Add(new Persona()
                        {
                            idPersona = dr.GetInt32(0),
                            Nombre = dr.GetString(1),
                            Paterno = dr.GetString(2),
                            Materno = dr.GetString(3),
                            Nacimiento = dr.GetDateTime(4),
                            Estatus = dr.GetString(5),
                            Pais = new Pais()
                            {
                                idPais = dr.GetInt32(6),
                                Nombre = dr.GetString(7)
                            }
                        });
                    }
                }
                conn.Close();
            }
            return this;
        }
    }
}
