using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructura.Data.SqlServer;
using Negocio.Objetos;

namespace Dominio.MainModule
{
    public class UsuarioManager
    {

        dbhotelEntities db = new dbhotelEntities();

        public List<Usuario> List()
        {
            try
            {
                var lista = db.usuario.ToList();
                List<Usuario> toReturn = new List<Usuario>();
                foreach (var item in lista)
                {

                    Usuario model = new Usuario();
                    model.dni_usu = item.dni_usu;
                    model.apenom_usu = item.apenom_usu;
                    model.password_usu = item.password_usu;
                    model.direccion_usu = item.direccion_usu;
                    model.estado_usu = item.estado_usu;
                    toReturn.Add(model);
                }
                return toReturn;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public Usuario Insert(Usuario model)
        {
            try
            {
                usuario insert = new usuario();
                insert.dni_usu = model.dni_usu;
                insert.apenom_usu = model.apenom_usu;
                insert.password_usu = model.password_usu;
                insert.direccion_usu = model.direccion_usu;
                insert.estado_usu = model.estado_usu;
                db.usuario.Add(insert);
                db.SaveChanges();
                return model;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Usuario Find(String dni) {

            Usuario objU = new Usuario();
            try
            {
                usuario usu = db.usuario.Find(dni);
                objU.dni_usu = usu.dni_usu;
                objU.apenom_usu = usu.apenom_usu;
                objU.password_usu = usu.password_usu;
                objU.direccion_usu = usu.direccion_usu;
                objU.estado_usu = usu.estado_usu;
            }
            catch (Exception e)
            {

                throw e;
            }
            return objU;

        } 

        public void Update(Usuario model)
        {
            try
            {
                usuario toUpdate = new usuario()
                {
                    dni_usu = model.dni_usu,
                    apenom_usu = model.apenom_usu,
                    password_usu = model.password_usu,
                    direccion_usu = model.direccion_usu,
                    estado_usu = model.estado_usu
                };
                db.Entry(toUpdate).State = EntityState.Modified;
                db.SaveChanges();

            }
            catch (Exception e)
            {

                throw e;
            }       
        }

        public void Delete(String dni) {
            try
            {
                usuario alu = db.usuario.Find(dni);
                db.usuario.Remove(alu);
                db.SaveChanges();

            }
            catch (Exception e)
            {
                throw e;
            }


        }


    }
}