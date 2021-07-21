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
    public class SobreController : Controller
    {
        // GET: Sobre
        public async Task<ActionResult> Index(string token)
        {
            SobreManager manager = new SobreManager();
            IEnumerable<Sobre> list = await manager.GetAll(token);
            return View(list);
        }

        // GET: Sobre/Details/5
        public async Task<ActionResult> Details(int id, string token)
        {
            SobreManager manager = new SobreManager();
            Sobre sobre = await manager.GetByID(id, token);
            return View(sobre);
        }

        // GET: Sobre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sobre/Create
        [HttpPost]
        public async Task<ActionResult> Create(Sobre sobre, string token)
        {
            SobreManager manager = new SobreManager();
            await manager.Insertar(sobre, token);
            return RedirectToAction("Index", new { token = token });
        }

        // GET: Sobre/Edit/5
        public async Task<ActionResult> Edit(int id, string token)
        {
            SobreManager manager = new SobreManager();
            Sobre sobre = await manager.GetByID(id, token);
            return View(sobre);
        }

        // POST: Sobre/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Sobre sobre, string token)
        {
            SobreManager manager = new SobreManager();
            await manager.Actualizar(sobre, token);
            return RedirectToAction("Details", new { id = sobre.Codigo, token = token });
        }

        // GET: Sobre/Delete/5
        public async Task<ActionResult> Delete(int id, string token)
        {
            SobreManager manager = new SobreManager();
            await manager.Eliminar(id, token);
            return RedirectToAction("Index", new { token = token });
        }



    }
}
