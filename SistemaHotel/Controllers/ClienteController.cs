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
    public class ClienteController : Controller
    {


        ClienteManager cc = new ClienteManager();
        UsuarioManager uc = new UsuarioManager();
        StateManager sm = new StateManager();
        public ActionResult Index()
        {
            return View(cc.List());
        }

        // GET: Cliente/Details/5
        public ActionResult Details(String id)
        {
            if (id.ToString() == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente c = cc.Find(id);
            if (c == null)
            {

                return HttpNotFound();
            }
            return View(c);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            ViewBag.estado_cli = new SelectList(sm.ListaState, "valor", "nombre");
            ViewBag.dni_usu = new SelectList(uc.List(), "dni_usu", "apenom_usu");
            return PartialView();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Cliente c)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.dni_usu = new SelectList(uc.List(), "dni_usu", "apenom_usu");
                return PartialView(c);
            }
            cc.Insert(c);
            return RedirectToAction("Index");
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(String id)
        {
            Cliente c = cc.Find(id);
            ViewBag.estado_cli = new SelectList(sm.ListaState, "valor", "nombre",c.estado_cli);
            ViewBag.dni_usu = new SelectList(uc.List(), "dni_usu", "apenom_usu",c.dni_usu);
            return PartialView(c);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(Cliente c)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.estado_cli = new SelectList(sm.ListaState, "valor", "nombre", c.estado_cli);
                    ViewBag.dni_usu = new SelectList(uc.List(), "dni_usu", "apenom_usu", c.dni_usu);
                    return PartialView(c);
                }
                cc.Update(c);
                return RedirectToAction("Index");
            }
            catch
            {
                return PartialView();
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(String id)
        {
            try
            {
                cc.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
