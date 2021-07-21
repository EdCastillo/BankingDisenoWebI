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
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public async Task<ActionResult> Index(string token)
        {
            CategoriaManager manager = new CategoriaManager();
            IEnumerable<Categoria> list = await manager.GetAll(token);
            return View(list);
        }

        // GET: Categoria/Details/5
        public async Task<ActionResult> Details(int id, string token)
        {
            CategoriaManager manager = new CategoriaManager();
            Categoria categoria = await manager.GetByID(id, token);
            return View(categoria);
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        [HttpPost]
        public async Task<ActionResult> Create(Categoria categoria, string token)
        {
           


                CategoriaManager manager = new CategoriaManager();
                await manager.Insertar(categoria, token);
                return RedirectToAction("Index", new { token = token });
            
            
        }

        // GET: Categoria/Edit/5
        public async Task<ActionResult> Edit(int id, string token)
        {
            CategoriaManager manager = new CategoriaManager();
            Categoria categoria = await manager.GetByID(id, token);
            return View(categoria);
        }

        // POST: Categoria/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Categoria categoria, string token)
        {

            CategoriaManager manager = new CategoriaManager();
            await manager.Actualizar(categoria, token);
            return RedirectToAction("Details", new { id = categoria.Codigo, token = token });

        }

        // GET: Categoria/Delete/5
        public async Task<ActionResult>Delete(int id, string token)
        {
            // TODO: Add delete logic here
            CategoriaManager manager = new CategoriaManager();
            await manager.Eliminar(id, token);
            return RedirectToAction("Index", new { token = token });
        }

       
    }
}