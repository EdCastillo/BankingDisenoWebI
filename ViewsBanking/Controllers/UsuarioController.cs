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
    public  class UsuarioController : Controller
    {
        
        public ActionResult Login()
        {
            return View();
        }

        public async Task<ActionResult> Authenticate() {
            UsuarioManager manager = new UsuarioManager();
            Usuario usuario=await manager.Validar("string","string");
            if (usuario.Codigo == 0) {

                Redirect("");
            }
            return View(usuario);
        }
    }
}