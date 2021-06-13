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
        public async Task<ActionResult> Authenticate(string username,string password) {
            UsuarioManager manager = new UsuarioManager();
            //Usuario user=await manager.Insertar(new Usuario {Identificacion="asd",Nombre="asd",Username="assd",Password="asd",Email="asd",FechaNacimiento=DateTime.Now,Estado="a" });
            Usuario usuario=await manager.Login(new LoginRequest { Username = username, Password = password });
            if (usuario.Codigo == 0) {

                Redirect("");
            }
            return View(usuario);
        }
    }
}