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
    public class ProveedorController : Controller
    {
        // GET: Proveedor
        public async Task<ActionResult> Index(string token)
        {
            ProveedorManager manager = new ProveedorManager();
            IEnumerable<Proveedor> list = await manager.GetAll(token);
            return View(list);
        }

        // GET: Proveedor/Details/5
        public async Task<ActionResult> Details(int id, string token)
        {
            ProveedorManager manager = new ProveedorManager();
            Proveedor proveedor = await manager.GetByID(id, token);
            return View(proveedor);
        }

        // GET: Proveedor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proveedor/Create
        [HttpPost]
        public async Task<ActionResult> Create(Proveedor proveedor, string token)
        {

            ProveedorManager manager = new ProveedorManager();
            await manager.Insertar(proveedor, token);
            return RedirectToAction("Index", new { token = token });
        }

        // GET: Proveedor/Edit/5
        public async Task<ActionResult> Edit(int id, string token)
        {
            ProveedorManager manager = new ProveedorManager();
            Proveedor proveedor = await manager.GetByID(id, token);
            return View(proveedor);
        }

        // POST: Proveedor/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Proveedor proveedor, string token)
        {
            ProveedorManager manager = new ProveedorManager();
            await manager.Actualizar(proveedor, token);
            return RedirectToAction("Details", new { id = proveedor.Codigo, token = token });
        }

        // GET: Proveedor/Delete/5
        public async Task<ActionResult> Delete(int id, string token)
        {
            ProveedorManager manager = new ProveedorManager();
            await manager.Eliminar(id, token);
            return RedirectToAction("Index", new { token = token });
        }


    }
}
