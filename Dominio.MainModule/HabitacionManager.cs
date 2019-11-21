using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Objetos;
using Infraestructura.Data.SqlServer;
using System.Data.Entity;

namespace Dominio.MainModule
{
   public class HabitacionManager
    {
        dbhotelEntities db = new dbhotelEntities();


        public List<Habitacion> ListAvailable()
        {
            try
            {
                List<Habitacion> MiLista = new List<Habitacion>();
                var lista = db.habitacion.Where(x => x.estado_habi == "1").ToList();
               

                foreach (var item in lista)
                {
                    Habitacion h = new Habitacion();
                    h.num_habi = item.num_habi;
                    h.desc_habi = item.num_habi;
                    h.precio_habi = item.precio_habi;
                    h.cat_id = item.cat_id;
                    h.id_piso = item.id_piso;
                    h.img_habi = item.img_habi;
                    h.estado_habi = item.estado_habi;
                    MiLista.Add(h);
                }
                return MiLista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public List<Habitacion> List() {
            try
            {
                List<Habitacion> MiLista = new List<Habitacion>();
                var lista = db.habitacion.ToList();
                foreach (var item in lista)
                {
                    Habitacion h = new Habitacion();
                    h.num_habi = item.num_habi;
                    h.desc_habi = item.num_habi;
                    h.precio_habi = item.precio_habi;
                    h.cat_id = item.cat_id;
                    h.id_piso = item.id_piso;
                    h.img_habi = item.img_habi;
                    h.estado_habi = item.estado_habi;
                    MiLista.Add(h);
                }
                return MiLista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public Habitacion Insert(Habitacion h) {
            try
            {
                habitacion objH = new habitacion();
                objH.num_habi = h.num_habi;
                objH.desc_habi = h.num_habi;
                objH.precio_habi = h.precio_habi;
                objH.cat_id = h.cat_id;
                objH.id_piso = h.id_piso;
                objH.img_habi = h.img_habi;
                objH.estado_habi = h.estado_habi;

                objH.categoria_habitacion = db.categoria_habitacion.Find(objH.cat_id);
                objH.piso = db.piso.Find(objH.id_piso);
                db.habitacion.Add(objH);
                db.SaveChanges();
                return h;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public Habitacion Find(String id) {
            Habitacion h = new Habitacion();
            try
            {
                habitacion objH = db.habitacion.Find(id);
                h.num_habi = objH.num_habi;
                h.desc_habi = objH.num_habi;
                h.precio_habi = objH.precio_habi;
                h.cat_id = objH.cat_id;
                h.id_piso = objH.id_piso;
                h.img_habi = objH.img_habi;
                h.estado_habi = objH.estado_habi;
            }
           
            catch (Exception e)
            {

                throw e; 
            }
            return h;
        }

        public void Update(Habitacion h) {

            try
            {   
                habitacion objH = new habitacion() { 
                   num_habi = h.num_habi,
                   desc_habi = h.num_habi,
                   precio_habi = h.precio_habi,
                   cat_id = h.cat_id,
                   id_piso = h.id_piso,
                   img_habi = h.img_habi,
                   estado_habi = h.estado_habi,
                };
                db.Entry(objH).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public void Delete(String id) {
            try
            {
                habitacion objH = db.habitacion.Find(id);
                db.habitacion.Remove(objH);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Estado(String id,String estado) {
            try
            {
                habitacion objH = db.habitacion.Find(id);
                objH.estado_habi = estado;
                db.Entry(objH).State = EntityState.Modified;
                db.SaveChanges();

            }
            catch (Exception e)
            {

                throw e;
            }
        }

    }
}
