using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace NetvieWeb.Models
{
    public class Peliculas : List<Pelicula>
    {
        /// <summary>
        /// Obtiene las peliculas
        /// </summary>
        /// <returns>Lista de peliculas</returns>
        public Peliculas GetPeliculas()
        {
            using (MySqlConnection conn = new MySqlConnection("Server=localhost;Database=netvie;Uid=root;Pwd=;"))
            {
                MySqlCommand cmd = new MySqlCommand("ShowPeliculas", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        this.Add(new Pelicula()
                        {
                            idPelicula = dr.GetInt32(0),
                            TituloEsp = dr.GetString(1),
                            TituloOriginal = dr.GetString(2),
                            Sinopsis = dr.GetString(3),
                            Duracion = dr.GetString(4),
                            Fecha = dr.GetDateTime(5),
                            Critica = dr.GetString(6),
                            Imagen = dr.GetString(7),
                            Url = dr.GetString(8),
                            Clasificacion = new Clasificacion()
                            {
                                idClasificacion = dr.GetInt32(9),
                                Nombre = dr.GetString(11)
                            },
                            Pais = new Pais()
                            {
                                idPais = dr.GetInt32(10),
                                Nombre = dr.GetString(12)
                            },
                            Generos = (new Generos()).GetGeneros(dr.GetInt32(0)),
                            Personas = (new Personas()).GetPersonasPeliculas(dr.GetInt32(0))
                        });
                    }
                }
                conn.Close();
            }
            return this;
        }
    }
}
