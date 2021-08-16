using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ViewsBanking.Managers;
using ViewsBanking.Models;

namespace ViewsBanking.Controllers
{
    public class TipoController : Controller
    {
        private static TipoManager manager=new TipoManager();
        // GET: Tipo
        public async Task<ActionResult> Index()
        {
            string token=Session["Token"].ToString();
            TipoManager manager = new TipoManager();
            IEnumerable<Tipo> list=await manager.GetAll(token);
            PrestamoManager managerPrest = new PrestamoManager();
            IEnumerable<Prestamo> listPrestamo = await managerPrest.GetAll(token);

            dynamic model = new ExpandoObject();
            model.Tipo = list;
            model.Prestamo = listPrestamo;
            return View(model);
        }

        // GET: Tipo/Details/5
        public async Task<ActionResult> Details(int id)
        {
            string token = Session["Token"].ToString();
            Tipo tipo=await manager.GetByID(id,token);
            return View(tipo);
        }

        // GET: Tipo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo/Create
        [HttpPost]
        public async Task<ActionResult> Create(Tipo tipo)
        {
            string token = Session["Token"].ToString();
                await manager.Insertar(tipo, token);
                return RedirectToAction("Index",new { token=token});
        }

        public async Task<ActionResult> Edit(int id)
        {
            string token = Session["Token"].ToString();
            Tipo tipo=await manager.GetByID(id, token);
            return View(tipo);
        }

        // POST: Tipo/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Tipo tipo)
        {
            string token = Session["Token"].ToString();
            await manager.Actualizar(tipo, token);
            return RedirectToAction("Index",new { token=token});
        }

        // GET: Tipo/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            string token = Session["Token"].ToString();
            await manager.Eliminar(id, token);
            return RedirectToAction("Index");
        }

    }
}
