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
    public class ErrorController : Controller
    {
        // GET: Error
        public async Task<ActionResult> Index(string token)
        {
            ErrorManager manager = new ErrorManager();
            IEnumerable<Error> list=await manager.GetAll(token);
            return View(list);
        }

        // GET: Error/Details/5
        public async Task<ActionResult> Details(int id,string token)
        {
            ErrorManager manager = new ErrorManager();
            Error error = await manager.GetByID(id, token);
            return View(error);
        }

        // GET: Error/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Error/Create
        [HttpPost]
        public async Task<ActionResult> Create(Error error,string token)
        {
            try
            {
                ErrorManager manager = new ErrorManager();
                await manager.Insertar(error,token);
                return RedirectToAction("Index",new { token=token});
            }
            catch
            {
                return View();
            }
        }

        // GET: Error/Edit/5
        public async Task<ActionResult> Edit(int id,string token)
        {
            ErrorManager manager = new ErrorManager();
            Error error = await manager.GetByID(id,token);
            return View(error);
        }

        // POST: Error/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Error error, string token)
        {
            try
            {
                ErrorManager manager = new ErrorManager();
                await manager.Actualizar(error,token);
                return RedirectToAction("Index",new { token=token});
            }
            catch
            {
                return View();
            }
        }


        public async  Task<ActionResult> Delete(int id, string token)
        {
                // TODO: Add delete logic here
                ErrorManager manager = new ErrorManager();
                await manager.Eliminar(id,token);
                return RedirectToAction("Index", new { token = token });
        }
    }
}
