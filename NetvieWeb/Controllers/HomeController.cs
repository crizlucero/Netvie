using NetvieWeb.Models;
using System;
using System.Web.Mvc;

namespace NetvieWeb.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {

            Peliculas model = (new Peliculas()).GetPeliculas();


            return View(model);
        }

        public ActionResult Pelicula()
        {
            Pelicula model = (new Pelicula()).GetPelicula(Convert.ToInt32(Request["idpelicula"]));
            if (Session["idusuario"] != null)
                (new UsuarioVioPelicula()).PeliculaVista(Convert.ToInt32(Request["idpelicula"]), Convert.ToInt32(Session["idusuario"]));
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}