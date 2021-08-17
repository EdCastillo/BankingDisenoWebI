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
    public class PrestamoController : Controller
    {
        // GET: Prestamo
        public async Task<ActionResult> Index()
        {
             string token = Session["Token"].ToString();
            PrestamoManager manager = new PrestamoManager();
            IEnumerable<Prestamo> list = await manager.GetAll(token);
            return View(list);
        }

        // GET: Prestamo/Details/5
        public async Task<ActionResult> Details(int id)
        {
             string token = Session["Token"].ToString();
            PrestamoManager manager = new PrestamoManager();
            Prestamo prestamo = await manager.GetByID(id, token);
            return View(prestamo);
        }

        // GET: Prestamo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prestamo/Create
        [HttpPost]
        public async Task<ActionResult> Create(Prestamo prestamo)
        {
            try
            {
                  string token = Session["Token"].ToString();
                PrestamoManager manager = new PrestamoManager();
                await manager.Insertar(prestamo, token);
                return RedirectToAction("Index", new { token = token });
            }
            catch
            {
                return View();
            }
        }

        // GET: Prestamo/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
                string token = Session["Token"].ToString();
            PrestamoManager manager = new PrestamoManager();
            Prestamo prestamo = await manager.GetByID(id, token);
            return View(prestamo);
        }

        // POST: Prestamo/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Prestamo prestamo)
        {
            try
            {
                 string token = Session["Token"].ToString();
                PrestamoManager manager = new PrestamoManager();
                await manager.Actualizar(prestamo, token);
                return RedirectToAction("Index", new { token = token });
            }
            catch
            {
                return View();
            }
        }


        public async Task<ActionResult> Delete(int id)
        {
              string token = Session["Token"].ToString();
            PrestamoManager manager = new PrestamoManager();
            await manager.Eliminar(id, token);
            return RedirectToAction("Index", new { token = token });
        }
    }
}
