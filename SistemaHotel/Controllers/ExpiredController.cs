using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio.Objetos;
using Dominio.MainModule;
using PagedList.Mvc;
using PagedList;
namespace SistemaHotel.Controllers
{
    [Authorize]
    public class ExpiredController : Controller
    {

        ExpiredManager em = new ExpiredManager();
        public ActionResult Index(int ? i,string search="")
        {
                return View(em.List().Where(x=>x.dni_clientes.StartsWith(search.ToString())|| search==null).ToList().ToPagedList(i ?? 1,15));
        }
            
    
        public JsonResult Lista(string id)
        {
            return Json(em.ListJson(), JsonRequestBehavior.AllowGet);
        }



    }
}
