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
    public class CategoriaManager
    {
        dbhotelEntities db = new dbhotelEntities();

        public List<Categoria> List() {

            try
            {
                List<Categoria> MiLista = new List<Categoria>();
                var lista = db.categoria_habitacion.ToList();
                foreach (var item in lista)
                {
                    Categoria objc = new Categoria();
                    objc.cat_id = item.cat_id;
                    objc.desc_cat = item.desc_cat;
                    objc.estado_cat = item.estado_cat;
                    MiLista.Add(objc);
                }
                return MiLista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Categoria Insert(Categoria c) {
            try
            {
                categoria_habitacion objc = new categoria_habitacion();
                objc.cat_id = c.cat_id;
                objc.desc_cat = c.desc_cat;
                objc.estado_cat = c.estado_cat;
                db.categoria_habitacion.Add(objc);
                db.SaveChanges();
                return c;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public Categoria Find(int id) {

            Categoria objC = new Categoria();
            try
            {
                categoria_habitacion ch = db.categoria_habitacion.Find(id);
                objC.cat_id = ch.cat_id;
                objC.desc_cat = ch.desc_cat;
                objC.estado_cat = ch.estado_cat;

            }
            catch (Exception e)
            {

                throw e;
            }

            return objC;
        }

        public void Update(Categoria c) {
            try
            {
                categoria_habitacion ch = new categoria_habitacion() {
                    cat_id = c.cat_id,
                    desc_cat = c.desc_cat,
                    estado_cat = c.estado_cat
                };
                db.Entry(ch).State = EntityState.Modified;
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
                categoria_habitacion ch = db.categoria_habitacion.Find(id);
                db.categoria_habitacion.Remove(ch);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }

        }


    }
}
