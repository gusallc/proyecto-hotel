using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio.Objetos;
using Dominio.MainModule;
using System.Net;

namespace SistemaHotel.Controllers
{
    [Authorize]
    public class PisoController : Controller
    {
        PisoManager pm = new PisoManager();
        StateManager sm = new StateManager();

        // GET: Piso
        public ActionResult Index()
        {
            return View(pm.List());
        }

        // GET: Piso/Details/5
        public ActionResult Details(int id)
        {
            if (id.ToString() == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Piso p = pm.Find(id);
            if (p==null) {
                return HttpNotFound();
            }
            return View(p);
        }

        // GET: Piso/Create
        public ActionResult Create()
        {
            ViewBag.estado_piso = new SelectList(sm.ListaState2, "valor", "nombre");
            return PartialView();
        }

        // POST: Piso/Create
        [HttpPost]
        public ActionResult Create(Piso p)
        {
          
                if (!ModelState.IsValid) {
                ViewBag.estado_piso = new SelectList(sm.ListaState2, "valor", "nombre");
                return PartialView(p);
                }
                pm.Insert(p);
                return RedirectToAction("Index");
        }

        // GET: Piso/Edit/5
        public ActionResult Edit(int id)
        {
            Piso p = pm.Find(id);
            ViewBag.estado_piso = new SelectList(sm.ListaState2, "valor", "nombre",p.estado_piso);
            return PartialView(p);
        }

        // POST: Piso/Edit/5
        [HttpPost]
        public ActionResult Edit(Piso p)
        {
            try
            {
                if (ModelState.IsValid) {
                    pm.Update(p);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.estado_piso = new SelectList(sm.ListaState2, "valor", "nombre", p.estado_piso);
                return PartialView(p);
            }
        }

        /* GET: Piso/Delete/5
        public ActionResult Delete(int id)
        {
            if (id.ToString() == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Piso objP = pm.Find(id);
            if (objP == null)
            {
                return HttpNotFound();
            }
            return View(objP);
        }*/


        public ActionResult Delete(int id)
        {
            try
            {
                pm.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
