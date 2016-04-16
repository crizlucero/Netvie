namespace NetvieWeb.Models
{
    public class Premio
    {
        int idPremio { get; set; }
        string nombre { get; set; }
        string Anio { get; set; }
        Pelicula Pelicula { get; set; }
    }
}
