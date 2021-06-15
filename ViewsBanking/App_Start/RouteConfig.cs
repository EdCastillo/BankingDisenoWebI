using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ViewsBanking
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name:"Login",
                url: "authenticate/",
                defaults:new { controller="Usuario",action= "Authenticate" });

            routes.MapRoute(name:"Test",url:"Test",defaults:new {controller="Usuario",action="Test" });



            routes.MapRoute(name: "ErrorIndex", url: "ErrorInsert", defaults: new { controller = "Error", action = "Index" });
        }
    }
}
