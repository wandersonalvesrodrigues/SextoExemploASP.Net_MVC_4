using System.Web.Mvc;

namespace CadeMeuMedicoMVC.Areas.Adm.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Title = "Seja bem vindo(a)";
            return View();
        }
    }
}
