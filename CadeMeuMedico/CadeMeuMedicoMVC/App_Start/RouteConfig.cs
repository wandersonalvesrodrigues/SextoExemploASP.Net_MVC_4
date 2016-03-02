using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CadeMeuMedicoMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //rota dentro da area
            routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Medico", action = "Buscar", id = UrlParameter.Optional },
            namespaces: new[] { "CadeMeuMedicoMVC.Areas.pub.Controllers" }
            ).DataTokens.Add("area", "Pub");
            //Rota foa da area
            /* routes.MapRoute(
                 name: "Default",
                 url: "{controller}/{action}/{id}",
                 defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                 namespaces: new[] { "CadeMeuMedicoMVC.Controllers" }
             );*/
        }
    }
}