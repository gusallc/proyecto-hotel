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
    public class CategoriaController : Controller
    {

        CategoriaManager CC = new CategoriaManager();
        StateManager sm = new StateManager();
        // GET: Categoria
        public ActionResult Index()
        {
             
            return View(CC.List());
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int id)
        {
            if (id.ToString()==null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
                Categoria c =  CC.Find(id);
            if (c == null){

                return HttpNotFound();
            }
            return View(c);
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            ViewBag.estado_cat = new SelectList(sm.ListaState2, "valor", "nombre");
            return PartialView();
        }

        // POST: Categoria/Create
        [HttpPost]
        public ActionResult Create(Categoria c)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.estado_cat = new SelectList(sm.ListaState2, "valor", "nombre");
                return PartialView(c);
            }
            CC.Insert(c);
            return RedirectToAction("Index");
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(int id)
        {
            if (id.ToString() == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
         
            Categoria c = CC.Find(id);
            ViewBag.estado_cat = new SelectList(sm.ListaState2, "valor", "nombre",c.estado_cat);
            if (c == null)
            {

                return HttpNotFound();
            }
            return PartialView(c);
        }

        // POST: Categoria/Edit/5
        [HttpPost]
        public ActionResult Edit(Categoria c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CC.Update(c);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.estado_cat = new SelectList(sm.ListaState, "valor", "nombre", c.estado_cat);
                return PartialView(c);
            }
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                CC.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
