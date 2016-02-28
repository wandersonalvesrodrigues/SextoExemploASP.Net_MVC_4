using System.Web.Mvc;

namespace CadeMeuMedicoMVC.Areas.pub
{
    public class pubAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "pub";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "pub_default",
                "pub/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "CadeMeuMedicoMVC.Areas.pub.Controllers" }
            );
        }
    }
}
