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
    public class PisoManager
    {
        dbhotelEntities db = new dbhotelEntities();
        public List<Piso> List() {
            try
            {
                var lista = db.piso.ToList();
                List<Piso> MiLista = new List<Piso>();
                foreach (var item in lista)
                {
                    Piso objP = new Piso();
                    objP.id_piso = item.id_piso;
                    objP.desc_piso = item.desc_piso;
                    objP.estado_piso = item.estado_piso;
                    MiLista.Add(objP);
                }
                return MiLista;
            }
            catch (Exception e)
            {

                throw e;
            }
       
        }

        public Piso Insert(Piso p) {

            try
            {
                piso objP = new piso();
                objP.id_piso = p.id_piso;
                objP.desc_piso = p.desc_piso;
                objP.estado_piso = p.estado_piso;
                db.piso.Add(objP);
                db.SaveChanges();
                return p;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Piso Find(int id) {

            Piso objP = new Piso();
            try
            {
                piso p = db.piso.Find(id);
                objP.id_piso = p.id_piso;
                objP.desc_piso = p.desc_piso;
                objP.estado_piso = p.estado_piso;
            }
            catch (Exception e)
            {

                throw e;
            }
            return objP;
        }

        public void Update(Piso p) {
            try
            {
                piso toUpdare = new piso()
                {
                    id_piso = p.id_piso,
                    desc_piso = p.desc_piso,
                    estado_piso = p.estado_piso

                };
                db.Entry(toUpdare).State = EntityState.Modified;
                db.SaveChanges();

            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public void Delete(int id) {
            try
            {
                piso objp = db.piso.Find(id);
                db.piso.Remove(objp);
                db.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }



    }
}
