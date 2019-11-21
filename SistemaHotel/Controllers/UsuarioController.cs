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
    public class UsuarioController : Controller
    {

        UsuarioManager ObjUM = new UsuarioManager();
        
        public ActionResult Index()
        {
            return View(ObjUM.List());
        }

        // GET: Usuario/Details/5
        public ActionResult Details(String dni)
        {
            if (dni == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usu = ObjUM.Find(dni);
            if (usu == null)
            {
                return HttpNotFound();
            }
            return View(usu);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            if (!ModelState.IsValid) {
                return PartialView(usuario);
            }
            ObjUM.Insert(usuario);
            return RedirectToAction("Index");
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(String dni)
        {
            Usuario usu = ObjUM.Find(dni);
            return PartialView(usu);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(Usuario usu)
        {
            try
            {
                if (ModelState.IsValid) {
                    ObjUM.Update(usu);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return PartialView(usu);
            }
        }

        /* GET: Usuario/Delete/5
        public ActionResult Delete(String dni)
        {
            if (dni == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usu = ObjUM.Find(dni);
            if (usu == null)
            {
                return HttpNotFound();
            }
            return View(usu);
        }*/

        // POST: Usuario/Delete/5
    
        public ActionResult Delete(String dni)
        {
            try
            { 
                ObjUM.Delete(dni);
                return RedirectToAction("Index");
            }
            catch (Exception e )
            {
                throw e;
            }
        }
    }
}
