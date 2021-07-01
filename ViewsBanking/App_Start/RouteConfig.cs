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

            //USUARIO
            routes.MapRoute(
                name:"AuthenticateAction",
                url: "authenticate",
                defaults:new { controller="Usuario",action= "Authenticate" });
            routes.MapRoute(name: "NewUserForm",
                url: "Usuario/new",
                defaults: new { controller = "Usuario", action = "UserForm" });
            routes.MapRoute(name: "Login",
                url: "Login/",
                defaults: new { controller = "Usuario", action = "Login" });
            routes.MapRoute(name: "RegistroAction",
               url: "registro/",
               defaults: new { controller = "Usuario", action = "Registro" });

            //SESION
            routes.MapRoute(name: "Sesion",
               url: "sesion/",
               defaults: new { controller = "Sesion", action = "GetAll" });



            //HOME
            routes.MapRoute(
                name: "Home",
                url: "home",
                defaults: new { controller = "Home", action = "Index" });


            //Moneda
            routes.MapRoute(
                name: "GetAllMonedas",
                url: "Moneda/",
                defaults: new { controller = "Moneda", action = "GetAll" });

            routes.MapRoute(
                name: "GetMonedaById",
                url: "Moneda/ById",
                defaults: new { controller = "Moneda", action = "GetById" });



            //PAGO
            routes.MapRoute(
                name: "GetAllPagos",
                url: "Pago/",
                defaults: new { controller = "Pago", action = "GetAll" });



            //TEST
            routes.MapRoute(name:"Test",url:"Test",defaults:new {controller="Usuario",action="Test" });
            routes.MapRoute(name: "ErrorIndex", url: "ErrorInsert", defaults: new { controller = "Error", action = "Index" });


            //TRANSFERENCIA
            routes.MapRoute(
                name: "TransferenciaGetAll",
                url: "transferencia",
                defaults: new { controller ="Transferencia",action="GetAll"});

            routes.MapRoute(
                name: "TransferenciaGetByID",
                url: "transferencia/ByID",
                defaults: new { controller = "Transferencia", action = "GetByID" });
            routes.MapRoute(
                name: "TrasnferenciaDelete", 
                url: "transferencia/delete", 
                defaults: new { controller = "Transferencia", action = "Delete" });
            routes.MapRoute(
                name: "TransferenciaCrear",
                url: "transferencia/crear",
                defaults: new { controller = "Transferencia", action = "Create" });
            routes.MapRoute(name: "TransferenciaEditar", url: "transferencia/edit", defaults: new { controller = "Transferencia", action = "Edit" });




            //ERROR TOMAR REFERENCIA DE RUTAS DE AQUI
            routes.MapRoute(
                name: "ErrorGetAll",
                url: "error",
                defaults: new { controller = "Error", action = "Index" });

            routes.MapRoute(
                name: "ErrorGetByID",
                url: "error/ByID",
                defaults: new { controller = "Error", action = "Details" });
            routes.MapRoute(
                name: "ErrorDelete", 
                url: "error/delete", 
                defaults: new { controller = "Error", action = "Delete" });
            routes.MapRoute(
                name: "ErrorCrear",
                url: "error/crear",
                defaults: new { controller = "Error", action = "Create" });
            routes.MapRoute(
                name: "errorEditar", 
                url: "error/edit", 
                defaults: new { controller = "Error", action = "Edit" });
        }
    }
}
