using CadeMeuMedicoMVC.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadeMeuMedicoMVC.Areas.pub.Controllers
{
    public class MedicoController : Controller
    {
        public ActionResult Index()
        {
            var medicos = MedicoBL.BuscaMedicos();
            return View(medicos);
        }

        public ActionResult Buscar() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Buscar(string crm)
        {
            var medicos = MedicoBL.BuscaMedicos();
            return View("Index",medicos.Where(x => x.CRM.Equals(crm)));
        }

    }
}
