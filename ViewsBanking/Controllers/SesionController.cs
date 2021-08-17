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
    public class SesionController : Controller
    {
        public async Task<ActionResult> Index()
        {
            string token = Session["Token"].ToString();
            SesionManager manager = new SesionManager();
            IEnumerable<Sesion> list=await manager.GetAll(token);
            return View(list);
        }
    }
}