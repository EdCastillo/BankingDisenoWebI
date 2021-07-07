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
    public class AbonoController : Controller
    {
        // GET: Abono
        public async Task<ActionResult> Index(string token)
        {
            AbonoManager manager = new AbonoManager();
            IEnumerable<Abono> list = await manager.GetAll(token);
            return View(list);
        }

        // GET: Abono/Details/5
        public async Task<ActionResult> Details(int id,string token)
        {
            AbonoManager manager = new AbonoManager();
            Abono abono = await manager.GetByID(id,token);
            return View(abono);
        }

        // GET: Abono/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Abono/Create
        [HttpPost]
        public async Task<ActionResult> Create(Abono abono,string token)
        {
                AbonoManager manager = new AbonoManager();
                await manager.Insertar(abono, token);
                return RedirectToAction("Index",new { token=token});
        }

        // GET: Abono/Edit/5
        public async Task<ActionResult> Edit(int id,string token)
        {
            AbonoManager manager = new AbonoManager();
            Abono abono = await manager.GetByID(id, token);
            return View(abono);
        }

        // POST: Abono/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Abono abono,string token)
        {
            AbonoManager manager = new AbonoManager();
            await manager.Actualizar(abono,token);
            return RedirectToAction("Details",new {id=abono.Codigo,token=token });
        }

        // GET: Abono/Delete/5
        public async Task<ActionResult> Delete(int id,string token)
        {
            AbonoManager manager = new AbonoManager();
            await manager.Eliminar(id,token);
            return RedirectToAction("Index",new{token=token});
        }

        
        
    }
}
