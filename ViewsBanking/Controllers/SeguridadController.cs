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
    public class SeguridadController : Controller
    {
        // GET: Seguridad
        public async Task<ActionResult> Index()
        {
        
            string token = Session["Token"].ToString()
            SeguridadManager manager = new SeguridadManager();
            IEnumerable<Seguridad> list = await manager.GetAll(token);
            return View(list);
        }

        // GET: Seguridad/Details/5
        public async Task<ActionResult> Details(int id)
        {
              string token = Session["Token"].ToString()
            SeguridadManager manager = new SeguridadManager();
            Seguridad seguridad = await manager.GetByID(id, token);
            return View(seguridad);

        }

        // GET: Seguridad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Seguridad/Create
        [HttpPost]
        public async Task<ActionResult> Create(Seguridad seguridad)
        {
            try
            {
                   string token = Session["Token"].ToString()
                SeguridadManager manager = new SeguridadManager();
                await manager.Insertar(seguridad, APItoken);
                return RedirectToAction("Index", new { token = APItoken });
            }
            catch
            {
                return View();
            }
        }

        // GET: Seguridad/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
               string token = Session["Token"].ToString()
            SeguridadManager manager = new SeguridadManager();
            Seguridad seguridad = await manager.GetByID(id, token);
            return View(seguridad);
        }



        // POST: Seguridad/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Seguridad seguridad)
        {
            try
            {
                    string token = Session["Token"].ToString()
                SeguridadManager manager = new SeguridadManager();
                await manager.Actualizar(seguridad, APItoken);
                return RedirectToAction("Index", new { token = APItoken });
            }
            catch
            {
                return View();
            }
        }



        // POST: Seguridad/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
               string token = Session["Token"].ToString()
            SeguridadManager manager = new SeguridadManager();
            await manager.Eliminar(id, token);
            return RedirectToAction("Index", new { token = token });
        }
    }
}
