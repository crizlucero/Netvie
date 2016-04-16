using NetvieWeb.Models;
using System.Web.Mvc;

namespace NetvieWeb.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {

            Peliculas model = (new Peliculas()).GetPeliculas() ;
            

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