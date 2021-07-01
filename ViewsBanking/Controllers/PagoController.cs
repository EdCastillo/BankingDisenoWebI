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
    public class PagoController : Controller
    {
        // GET: Pago
        public async Task<ActionResult> GetAll(string token)
        {
            PagoManager manager = new PagoManager();
            IEnumerable<Pago> list= await manager.GetAll(token);
            return View(list);
        }
        
        public ActionResult Borrar(int id) {
            return View();
        }
    }
}