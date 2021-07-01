using Newtonsoft.Json;
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
    public class TransferenciaController : Controller
    {

        public async Task<ActionResult> GetAll(string token)
        {
            TransferenciaManager manager = new TransferenciaManager();
            IEnumerable<Transferencia> list = await manager.GetAll(token);
            return View(list);
        }


        public async Task<ActionResult> GetByID(int id, string token) {
            TransferenciaManager manager = new TransferenciaManager();
            Transferencia transferencia = await manager.GetByID(id, token);
            return View(transferencia);
        }
        public async Task<ActionResult> Delete(int id, string token) {
            TransferenciaManager manager = new TransferenciaManager();
            await manager.Eliminar(id, token);
            return Redirect("/transferencia?token=" + token);
        }

        public async Task<ActionResult> Edit(int id, string token) {
            TransferenciaManager manager = new TransferenciaManager();
            Transferencia transferencia = await manager.GetByID(id, token);
            return View(transferencia);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Transferencia obj, string token)
        {
            TransferenciaManager manager = new TransferenciaManager();
            await manager.Actualizar(obj,token);
            return Redirect("/transferencia?token="+token);
        }






        public ActionResult Create() {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Transferencia transferencia,string token) {
            TransferenciaManager manager = new TransferenciaManager();
            await manager.Insertar(transferencia,token);
            return Redirect("/transferencia?token="+token);
        }
    }
}