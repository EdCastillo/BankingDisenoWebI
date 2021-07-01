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
    public class MonedaController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> GetAll(string token)
        {
            MonedaManager manager = new MonedaManager();
            IEnumerable<Moneda> model=await manager.GetAll(token);
            return View(model);
        }


        public async Task<ActionResult> GetById(int id,string token) {
            MonedaManager manager = new MonedaManager();
            Moneda moneda=await manager.GetByID(id,token);
            return View(moneda);
        }
    }
}