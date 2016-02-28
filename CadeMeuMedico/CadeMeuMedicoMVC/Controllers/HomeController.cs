using CadeMeuMedicoMVC.Util;
using System.Web.Mvc;

namespace CadeMeuMedicoMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Login", "Home", new { area = "adm" });
        }
    }
}
