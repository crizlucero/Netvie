using MySql.Data.MySqlClient;
using System;

namespace NetvieWeb.Models
{
    class Usuario : DatosGenerales
    {
        string Correo { get; set; }
        string Password { get; set; }
        DateTime Ingreso { get; set; }
        string Tipo { get; set; }
        int Estatus { get; set; }
        /// <summary>
        /// Busca los datos para el inicio de sesión
        /// </summary>
        /// <param name="Correo">Correo del usuario</param>
        /// <param name="Password">Contraseña</param>
        /// <returns>Datos del usuario</returns>
        public Usuario IniciarSesion(string Correo, string Password)
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

                        this.idPersona = dr.GetInt32(0);
                        this.Nombre = dr.GetString(1);
                        this.Paterno = dr.GetString(2);
                        this.Materno = dr.GetString(3);
                        this.Correo = dr.GetString(4);
                        this.Password = dr.GetString(5);
                        this.Ingreso = dr.GetDateTime(6);
                        this.Tipo = dr.GetString(7);
                        this.Estatus = dr.GetInt32(8);
                    }
                }
                conn.Close();
            }
            return this;
        }
        /// <summary>
        /// Agrega los datos del usuario
        /// </summary>
        /// <param name="nueva">Datos del nuevo usuario</param>
        public void AgregarUsuario(Usuario nueva)
        {
            using (MySqlConnection conn = new MySqlConnection("Server=localhost;Database=netvie;Uid=root;Pwd=;"))
            {
                MySqlCommand cmd = new MySqlCommand("AgregarUsuario", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Nombre", nueva.Nombre);
                cmd.Parameters.AddWithValue("Paterno", nueva.Paterno);
                cmd.Parameters.AddWithValue("Materno", nueva.Materno);
                cmd.Parameters.AddWithValue("Correo", nueva.Correo);
                cmd.Parameters.AddWithValue("Password", nueva.Password);
                cmd.Parameters.AddWithValue("Tipo", nueva.Tipo);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
