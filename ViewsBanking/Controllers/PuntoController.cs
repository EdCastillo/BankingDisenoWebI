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
    public class PuntoController : Controller
    {
        // GET: Punto
        public async Task<ActionResult> Index()
        {
            string token = Session["Token"].ToString();
            PuntoManager manager = new PuntoManager();
            IEnumerable<Punto> list = await manager.GetAll(token);
            return View(list);
        }

        // GET: Punto/Details/5
        public async Task<ActionResult> Details(int id)
        {
            string token = Session["Token"].ToString();
            PuntoManager manager = new PuntoManager();
            Punto punto = await manager.GetByID(id, token);
            return View(punto);
        }

        // GET: Punto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Punto/Create
        [HttpPost]
        public async Task<ActionResult> Create(Punto punto)
        {
            string token = Session["Token"].ToString();
            PuntoManager manager = new PuntoManager();
            await manager.Insertar(punto, token);
            return RedirectToAction("Index", new { token = token });
        }

        // GET: Punto/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            string token = Session["Token"].ToString();
            PuntoManager manager = new PuntoManager();
            Punto punto = await manager.GetByID(id, token);
            return View(punto);
        }

        // POST: Punto/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Punto punto)
        {
            string token = Session["Token"].ToString();
            PuntoManager manager = new PuntoManager();
            await manager.Actualizar(punto, token);
            return RedirectToAction("Details", new { id = punto.Codigo, token = token });
        }

        // GET: Punto/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            string token = Session["Token"].ToString();
            PuntoManager manager = new PuntoManager();
            await manager.Eliminar(id, token);
            return RedirectToAction("Index", new { token = token });
        }

        }
    }

