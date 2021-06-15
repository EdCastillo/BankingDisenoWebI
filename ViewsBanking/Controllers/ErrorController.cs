using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ViewsBanking.Managers;
using ViewsBanking.Models;

namespace ViewsBanking.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public async Task<ActionResult> Index()
        {
            ErrorManager manager = new ErrorManager();
            Error error = await manager.Insertar(new Error { CodigoUsuario = 1, Accion = "1", Descripcion = "asd", FechaHora = System.DateTime.Today, Fuente = "asd", Vista = "as", Usuario = null }, "");
            return View(error);
        }
    }
}