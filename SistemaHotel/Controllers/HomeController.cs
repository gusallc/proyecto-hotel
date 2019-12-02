using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio.MainModule;
using Negocio.Objetos;
using System.Web.Security;
namespace SistemaHotel.Controllers
{
    public class HomeController : Controller
    {


        [HttpPost]
        public ActionResult Login(string dni, string password)
        {
            UsuarioManager db = new UsuarioManager();
            if (!string.IsNullOrEmpty(dni) && !string.IsNullOrEmpty(password))
            {
                //se almacena en la variable usuario, el usuario encontrado con dni y password
                var usuario = db.List().Where(x => x.estado_usu == "1" && x.dni_usu == dni && x.password_usu == password).FirstOrDefault();
                if (usuario != null)
                {
                    //si encontramos  un usuario con los datos
                    //cookie percistente
                    FormsAuthentication.SetAuthCookie(usuario.dni_usu, true);
                    return RedirectToAction("Available", "Habitacion");
                }
                else
                {
                    return RedirectToAction("Index", new { mensaje = "El nombre de usuario y la contraseña que ingresaste no coinciden con nuestros registros. " });
                }
            }
            else
            {
                return RedirectToAction("Index", new { mensaje = "Ingrese un usuario y contraseña" });

            }

        }
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
        public ActionResult Index(string mensaje = "")
        {
            ViewBag.mensaje = mensaje;
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Available", "Habitacion");
            }
            return View();
        }


        [Authorize]
        [HttpPost]
        public JsonResult AgregarCarrito(string id)
        {
            HabitacionManager hm = new HabitacionManager();
            if (Session["carrito"] == null)
            {
                List<ItemCarrito> reservas = new List<ItemCarrito>();
                reservas.Add(new ItemCarrito(hm.Find(id)));
                Session["carrito"] = reservas;
            }
            else
            {
                List<ItemCarrito> reservas = (List<ItemCarrito>)Session["carrito"];
                int idexistente = getId(id);

                if (idexistente == -1)
                {
                    reservas.Add(new ItemCarrito(hm.Find(id)));
                }
                else
                {

                    Session["carrito"] = reservas;

                }
            }
            return Json(new { Response = true }, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult AgregarCarrito()
        {
            ClienteManager cm = new ClienteManager();
            ViewBag.dni_clientes = new SelectList(cm.List(), "dni_clientes", "apenom_cli");
            return View();
        }

        [Authorize]
        public ActionResult Delete(string id)
        {
            List<ItemCarrito> reservas = (List<ItemCarrito>)Session["carrito"];
            reservas.RemoveAt(getId(id));
            Session["carrito"] = reservas;
            return RedirectToAction("AgregarCarrito");
        }

        [Authorize]
        public int getId(string id)
        {
            List<ItemCarrito> reservas = (List<ItemCarrito>)Session["carrito"];
            for (int i = 0; i < reservas.Count; i++)
            {
                if (reservas[i].habitacion.num_habi == id)
                {
                    return i;
                }
            }
            return -1;
        }
        [Authorize]
        [HttpPost]
        public ActionResult ConfirmReserva(Reserva r) {
          
        
            ReservaManager rm = new ReservaManager();
            DetalleReservaManager drm = new DetalleReservaManager();
            HabitacionManager hm = new HabitacionManager();
            if (Session["carrito"] != null) {
                List<ItemCarrito> reservas = (List<ItemCarrito>)Session["carrito"];
                rm.Insert(r);
                var range=0;
                foreach (var item in reservas)
                {
                    var c = r.res_id;
                    var a = item.habitacion.num_habi;
                    var b = r.estado_pago;
                    drm.Insert(c, a, b);
                    hm.Estado(a,"2");
                    range++;
                }
                reservas.RemoveRange(0,range);



            }
            return View(r);
        }
        [Authorize]
        public ActionResult ConfirmReserva()
        {
            return View();
        }




    }
}