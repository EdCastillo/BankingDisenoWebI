using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
        public ActionResult UserForm()
        {
            return View();
        }
        public async Task<ActionResult> Registro(string identificacion,string nombre,string username,string password, string email, string fechaNacimiento)
        {
            UsuarioManager manager = new UsuarioManager();
            Usuario usuario = await manager.Insertar(new Usuario { Identificacion = identificacion, Email = email, Estado = "A", FechaNacimiento = DateTime.Parse(fechaNacimiento), Nombre = nombre, Password = password, Username = username });
            return View(usuario);
        }

        public async Task<ActionResult> Authenticate(string username,string password) {
            UsuarioManager manager = new UsuarioManager();
            Usuario usuario = await manager.Login(new LoginRequest { Username = username,Password=password }) ;
            if (usuario==null)
            {

                Redirect("");
            }
            return View(usuario);
        }
        public ActionResult Test() {
            return View();
        }

    }
}