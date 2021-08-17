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
    public class EstadisticaController : Controller
    {
        // GET: Estadistica
        public async Task<ActionResult> Index()
        {
            string token = Session["Token"].ToString();
            EstadisticaManager manager = new EstadisticaManager();
            IEnumerable<Estadistica> list = await manager.GetAll(token);
            return View(list);
        }
    }
}