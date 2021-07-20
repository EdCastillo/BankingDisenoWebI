using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ViewsBanking.Controllers
{
    public class SinpeController : Controller
    {
        // GET: Sinpe
        public ActionResult Index()
        {
            return View();
        }

        // GET: Sinpe/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sinpe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sinpe/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sinpe/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Sinpe/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sinpe/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        
    }
}
