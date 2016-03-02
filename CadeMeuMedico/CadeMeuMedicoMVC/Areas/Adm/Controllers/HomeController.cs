using CadeMeuMedicoMVC.Controllers;
using System.Web.Mvc;

namespace CadeMeuMedicoMVC.Areas.Adm.Controllers
{
    public class HomeController : BaseController
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
