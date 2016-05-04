using MySql.Data.MySqlClient;
using System;

namespace NetvieWeb.Models
{
    public class Pelicula
    {
        public int idPelicula { get; set; }
        public string TituloEsp { get; set; }
        public string TituloOriginal { get; set; }
        public string Sinopsis { get; set; }
        public string Duracion { get; set; }
        public DateTime Fecha { get; set; }
        public string Critica { get; set; }
        public string Estatus { get; set; }
        public string Imagen { get; set; }
        public string Url { get; set; }
        public DateTime FechaInsercion { get; set; }
        public Clasificacion Clasificacion { get; set; }
        public Pais Pais { get; set; }
        public Generos Generos { get; set; }
        public Personas Personas { get; set; }
        /// <summary>
        /// Obtiene los datos de una pelicula
        /// </summary>
        /// <param name="idPelicula">Identificador de la pelicula</param>
        /// <returns>Datos de la pelicula</returns>
        public Pelicula GetPelicula(int idPelicula)
        {
            using (MySqlConnection conn = new MySqlConnection("Server=localhost;Database=netvie;Uid=root;Pwd=;"))
            {
                MySqlCommand cmd = new MySqlCommand("ShowMovie", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pelicula", idPelicula);
                conn.Open();
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        this.idPelicula = dr.GetInt32(0);
                        this.TituloEsp = dr.GetString(1);
                        this.TituloOriginal = dr.GetString(2);
                        this.Sinopsis = dr.GetString(3);
                        this.Duracion = dr.GetString(4);
                        this.Fecha = dr.GetDateTime(5);
                        this.Critica = dr.GetString(6);
                        this.Estatus = dr.GetString(7);
                        this.Imagen = dr.GetString(8);
                        this.Url = dr.GetString(9);
                        this.Clasificacion = new Clasificacion()
                        {
                            idClasificacion = dr.GetInt32(10),
                            Nombre = dr.GetString(12)
                        };
                        this.Pais = new Pais()
                        {
                            idPais = dr.GetInt32(11),
                            Nombre = dr.GetString(13)
                        };
                        this.Generos = (new Generos()).GetGeneros(dr.GetInt32(0));
                        this.Personas = (new Personas()).GetPersonasPeliculas(dr.GetInt32(0));
                    }
                }
                conn.Close();
            }
            return this;
        }

    }
}