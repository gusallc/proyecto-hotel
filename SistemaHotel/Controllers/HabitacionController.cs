using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dominio.MainModule;
using Negocio.Objetos;
namespace SistemaHotel.Controllers
{
    [Authorize]
    public class HabitacionController : Controller
    {
        HabitacionManager hm = new HabitacionManager();
        PisoManager pm = new PisoManager();
        CategoriaManager cm = new CategoriaManager();

        public ActionResult Available() {
            return View(hm.List());
        }

        // GET: Habitacion
        public ActionResult Index()
        {

            return View(hm.List());
        }

        // GET: Habitacion/Details/5
        public ActionResult Details(String id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Habitacion h = hm.Find(id);
            if (h == null)
            {
                return HttpNotFound();
            }
            return View(h);
        }

        // GET: Habitacion/Create
        public ActionResult Create()
        {
            ViewBag.cat_id = new SelectList(cm.List(), "cat_id", "desc_cat");
            ViewBag.id_piso = new SelectList(pm.List(), "id_piso", "desc_piso");
            return PartialView();
        }

        // POST: Habitacion/Create
        [HttpPost]
        public ActionResult Create(Habitacion h)
        {
            if (!ModelState.IsValid) {
                ViewBag.cat_id = new SelectList(cm.List(), "cat_id", "desc_cat");
                ViewBag.id_piso = new SelectList(pm.List(), "id_piso", "desc_piso");
                return PartialView(h);
            }
            hm.Insert(h);
            return RedirectToAction("Index");

        }

        // GET: Habitacion/Edit/5
        public ActionResult Edit(String id)
        {
            Habitacion h = hm.Find(id);
            ViewBag.cat_id = new SelectList(cm.List(), "cat_id", "desc_cat", h.cat_id);
            ViewBag.id_piso = new SelectList(pm.List(), "id_piso", "desc_piso", h.id_piso);
            return PartialView(h);
        }

        // POST: Habitacion/Edit/5
        [HttpPost]
        public ActionResult Edit(Habitacion h)
        {
            try
            {
                if (!ModelState.IsValid) {
                    ViewBag.cat_id = new SelectList(cm.List(), "cat_id", "desc_cat", h.cat_id);
                    ViewBag.id_piso = new SelectList(pm.List(), "id_piso", "desc_piso", h.id_piso);
                    return PartialView(h);
                }
                hm.Update(h);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        /* GET: Habitacion/Delete/5
        public ActionResult Delete(String id)
        {
            if (id.ToString() == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Habitacion h = hm.Find(id);
            if (h == null)
            {
                return HttpNotFound();
            }
            return View(h);
        }*/
        public ActionResult Delete(String id)
        {
            try
            {
                hm.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
