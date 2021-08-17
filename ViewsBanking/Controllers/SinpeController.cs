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
    public class SinpeController : Controller
    {
        // GET: Sinpe
        public async Task<ActionResult> Index()
        {
            string token = Session["Token"].ToString();
            SinpeManager manager = new SinpeManager();
            IEnumerable<Sinpe> list = await manager.GetAll(token);
            return View(list);
        }

        // GET: Sinpe/Details/5
        public async Task<ActionResult> Details(int id)
        {
            string token = Session["Token"].ToString();
            SinpeManager manager = new SinpeManager();
            Sinpe sinpe = await manager.GetByID(id, token);
            return View(sinpe);
        }

        // GET: Sinpe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sinpe/Create
        [HttpPost]
        public async Task<ActionResult> Create(Sinpe sinpe)
        {
            string token = Session["Token"].ToString();
            SinpeManager manager = new SinpeManager();
            await manager.Insertar(sinpe, token);
            return RedirectToAction("Index", new { token = token });
        }

        // GET: Sinpe/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            string token = Session["Token"].ToString();
            SinpeManager manager = new SinpeManager();
            Sinpe sinpe = await manager.GetByID(id, token);
            return View(sinpe);
        }

        // POST: Sinpe/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Sinpe sinpe)
        {
            string token = Session["Token"].ToString();
            SinpeManager manager = new SinpeManager();
            await manager.Actualizar(sinpe, token);
            return RedirectToAction("Details", new { id = sinpe.Codigo, token = token });
        }

        // GET: Sinpe/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            string token = Session["Token"].ToString();
            SinpeManager manager = new SinpeManager();
            await manager.Eliminar(id, token);
            return RedirectToAction("Index", new { token = token });
        }



    }
}
