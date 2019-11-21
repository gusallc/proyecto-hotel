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
     public class ClienteManager
    {

         dbhotelEntities db = new dbhotelEntities();

        public List<Cliente> List() {

            try
            {
                List<Cliente> MiLista = new List<Cliente>();
                var lista = db.clientes.ToList();
                foreach (var item in lista)
                {
                    Cliente c = new Cliente();
                    c.dni_clientes = item.dni_clientes;
                    c.apenom_cli = item.apenom_cli;
                    c.edad_cli = (int)item.edad_cli;
                    c.dni_usu = item.dni_usu;
                    c.estado_cli = item.estado_cli;
                    MiLista.Add(c);
                }
                return MiLista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Cliente Insert(Cliente c) {
            try
            {
                clientes objC = new clientes();
                objC.dni_clientes = c.dni_clientes;
                objC.apenom_cli = c.apenom_cli;
                objC.edad_cli = c.edad_cli;
                objC.dni_usu = c.dni_usu;
                objC.estado_cli = c.estado_cli;
                //---
                objC.usuario = db.usuario.Find(objC.dni_usu);
                db.clientes.Add(objC);
                db.SaveChanges();
                return c;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Cliente Find(String dni) {
            Cliente c = new Cliente();
            try
            {
                clientes objC = db.clientes.Find(dni);
                c.dni_clientes = objC.dni_clientes;
                c.apenom_cli = objC.apenom_cli;
                c.edad_cli = (int)objC.edad_cli;
                c.dni_usu = objC.dni_usu;
                c.estado_cli = objC.estado_cli;
            }
            catch (Exception e)
            {
                throw e;
            }
            return c;
        }

        public void Update(Cliente c) {
            try
            {
                clientes objC = new clientes()
                {
                   dni_clientes = c.dni_clientes,
                   apenom_cli = c.apenom_cli,
                   edad_cli = c.edad_cli,
                   dni_usu = c.dni_usu,
                   estado_cli= c.estado_cli
                };
                db.Entry(objC).State = EntityState.Modified;
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
                clientes objC = db.clientes.Find(dni);
                db.clientes.Remove(objC);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
