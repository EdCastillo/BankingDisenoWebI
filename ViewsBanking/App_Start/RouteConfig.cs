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


            //TIPO
            routes.MapRoute(
                name: "TipoGetAll",
                url: "tipo",
                defaults: new { controller = "Tipo", action = "Index" });

            routes.MapRoute(
                name: "TipoGetByID",
                url: "tipo/ByID",
                defaults: new { controller = "Tipo", action = "Details" });
            routes.MapRoute(
                name: "TipoDelete",
                url: "tipo/delete",
                defaults: new { controller = "Tipo", action = "Delete" });
            routes.MapRoute(
                name: "TipoCrear",
                url: "tipo/crear",
                defaults: new { controller = "Tipo", action = "Create" });
            routes.MapRoute(
                name: "TipoEditar",
                url: "tipo/edit",
                defaults: new { controller = "Tipo", action = "Edit" });

            //ABONO
            routes.MapRoute(
                name: "AbonoGetAll",
                url: "abono",
                defaults: new { controller = "Abono", action = "Index" });

            routes.MapRoute(
                name: "AbonoGetByID",
                url: "abono/ByID",
                defaults: new { controller = "Abono", action = "Details" });
            routes.MapRoute(
                name: "AbonoDelete",
                url: "abono/delete",
                defaults: new { controller = "Abono", action = "Delete" });
            routes.MapRoute(
                name: "AbonoCrear",
                url: "abono/crear",
                defaults: new { controller = "Abono", action = "Create" });
            routes.MapRoute(
                name: "AbonoEditar",
                url: "abono/edit",
                defaults: new { controller = "Abono", action = "Edit" });

            //Seguridad

            routes.MapRoute(
                name: "SeguridadGetAll",
                url: "seguridad",
                defaults: new { controller = "Seguridad", action = "Index" });

            routes.MapRoute(
                name: "SeguridadGetByID",
                url: "seguridad/ByID",
                defaults: new { controller = "Seguridad", action = "Details" });
            routes.MapRoute(
                name: "SeguridadDelete",
                url: "seguridad/delete",
                defaults: new { controller = "Seguridad", action = "Delete" });
            routes.MapRoute(
                name: "SeguridadCrear",
                url: "seguridad/crear",
                defaults: new { controller = "Seguridad", action = "Create" });
            routes.MapRoute(
                name: "seguridadEditar",
                url: "seguridad/edit",
                defaults: new { controller = "Seguridad", action = "Edit" });


            //Prestamo
            routes.MapRoute(
                 name: "PrestamoGetAll",
                 url: "prestamo",
                 defaults: new { controller = "Prestamo", action = "Index" });

            routes.MapRoute(
                name: "PrestamoGetByID",
                url: "prestamo/ByID",
                defaults: new { controller = "Prestamo", action = "Details" });
            routes.MapRoute(
                name: "PrestamoDelete",
                url: "prestamo/delete",
                defaults: new { controller = "Prestamo", action = "Delete" });
            routes.MapRoute(
                name: "PrestamoCrear",
                url: "prestamo/crear",
                defaults: new { controller = "Prestamo", action = "Create" });
            routes.MapRoute(
                name: "prestamoEditar",
                url: "prestamo/edit",
                defaults: new { controller = "Prestamo", action = "Edit" });
            //Punto
            routes.MapRoute(
                 name: "PuntoGetAll",
                 url: "punto",
                 defaults: new { controller = "Punto", action = "Index" });

            routes.MapRoute(
                name: "PuntoGetByID",
                url: "punto/ByID",
                defaults: new { controller = "Punto", action = "Details" });
            routes.MapRoute(
                name: "PuntoDelete",
                url: "punto/delete",
                defaults: new { controller = "Punto", action = "Delete" });
            routes.MapRoute(
                name: "PuntoCrear",
                url: "punto/crear",
                defaults: new { controller = "Punto", action = "Create" });
            routes.MapRoute(
                name: "PuntoEditar",
                url: "punto/edit",
                defaults: new { controller = "Punto", action = "Edit" });

            //Proveedor
            routes.MapRoute(
                 name: "ProveedorGetAll",
                 url: "proveedor",
                 defaults: new { controller = "Proveedor", action = "Index" });

            routes.MapRoute(
                name: "ProveedorGetByID",
                url: "proveedor/ByID",
                defaults: new { controller = "Proveedor", action = "Details" });
            routes.MapRoute(
                name: "ProveedorDelete",
                url: "proveedor/delete",
                defaults: new { controller = "Proveedor", action = "Delete" });
            routes.MapRoute(
                name: "ProveedorCrear",
                url: "proveedor/crear",
                defaults: new { controller = "Proveedor", action = "Create" });
            routes.MapRoute(
                name: "ProveedorEditar",
                url: "proveedor/edit",
                defaults: new { controller = "Proveedor", action = "Edit" });
            //SINPE
            routes.MapRoute(
                 name: "SinpeGetAll",
                 url: "sinpe",
                 defaults: new { controller = "Sinpe", action = "Index" });

            routes.MapRoute(
                name: "SinpeGetByID",
                url: "sinpe/ByID",
                defaults: new { controller = "Sinpe", action = "Details" });
            routes.MapRoute(
                name: "SinpeDelete",
                url: "sinpe/delete",
                defaults: new { controller = "Sinpe", action = "Delete" });
            routes.MapRoute(
                name: "SinpeCrear",
                url: "sinpe/crear",
                defaults: new { controller = "Sinpe", action = "Create" });
            routes.MapRoute(
                name: "SinpeEditar",
                url: "sinpe/edit",
                defaults: new { controller = "Sinpe", action = "Edit" });

            //Sobre
            routes.MapRoute(
                 name: "SobreGetAll",
                 url: "sobre",
                 defaults: new { controller = "Sobre", action = "Index" });

            routes.MapRoute(
                name: "SobreGetByID",
                url: "sobre/ByID",
                defaults: new { controller = "Sobre", action = "Details" });
            routes.MapRoute(
                name: "SobreDelete",
                url: "sobre/delete",
                defaults: new { controller = "Sobre", action = "Delete" });
            routes.MapRoute(
                name: "SobreCrear",
                url: "sobre/crear",
                defaults: new { controller = "Sobre", action = "Create" });
            routes.MapRoute(
                name: "SobreEditar",
                url: "sobre/edit",
                defaults: new { controller = "Sobre", action = "Edit" });
        }
    }
}
