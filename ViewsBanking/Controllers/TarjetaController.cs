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
    public class TarjetaController : Controller
    {
        // GET: Tarjeta
        public async Task<ActionResult> Index(string token)
        {
            TarjetaManager manager = new TarjetaManager();
            IEnumerable<Tarjeta> list = await manager.GetAll(token);
            return View(list);
        }

        // GET: Tarjeta/Details/5
        public async Task<ActionResult> Details(int id, string token)
        {
            TarjetaManager manager = new TarjetaManager();
            Tarjeta tarjeta = await manager.GetByID(id, token);
            return View(tarjeta);
        }

        // GET: Tarjeta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tarjeta/Create
        [HttpPost]
        public async Task<ActionResult> Create(Tarjeta tarjeta, string token)
        {
            TarjetaManager manager = new TarjetaManager();
            await manager.Insertar(tarjeta, token);
            return RedirectToAction("Index", new { token = token });
        }

        // GET: Tarjeta/Edit/5
        public async Task<ActionResult> Edit(int id, string token)
        {
            TarjetaManager manager = new TarjetaManager();
            Tarjeta tarjeta = await manager.GetByID(id, token);
            return View(tarjeta);

        }

        // POST: Tarjeta/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Tarjeta tarjeta, string token)
        {
            TarjetaManager manager = new TarjetaManager();
            await manager.Actualizar(tarjeta, token);
            return RedirectToAction("Details", new { id = tarjeta.Codigo, token = token });
        }

        // GET: Tarjeta/Delete/5
        public async Task<ActionResult> Delete(int id, string token)
        {
            // TODO: Add delete logic here
            TarjetaManager manager = new TarjetaManager();
            await manager.Eliminar(id, token);
            return RedirectToAction("Index", new { token = token });
        }



    }
}
