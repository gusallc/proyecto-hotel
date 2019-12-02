using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructura.Data.SqlServer;
using Negocio.Objetos;


namespace Dominio.MainModule
{
   public  class ExpiredManager
    {
        dbhotelEntities db = new dbhotelEntities();
        public List<Expired> List()
        {
            try
            {
                List<Expired> MiLista = new List<Expired>();
                var lista = db.reserva.Join(db.detalle_reserva, r => r.res_id, dr => dr.fk_id_reserva, (r, dr) => new { r, dr }).OrderByDescending(x=> x.r.fecha_salida).ToList();
                foreach (var item in lista)
                {
                    Expired objE = new Expired();
                    objE.res_id = item.r.res_id;
                    objE.fecha_ingreso = item.r.fecha_ingreso;
                    objE.fecha_salida = item.r.fecha_salida;
                    objE.dni_clientes = item.r.dni_clientes;
                    objE.fk_num_habi = item.dr.fk_num_habi;
                    MiLista.Add(objE);
                }
                return MiLista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public List<Expired> ListJson()
        {
            try
            {
                DateTime horaactual = DateTime.Now.Date;
                List<Expired> MiLista = new List<Expired>();
                var lista = db.reserva.Join(db.detalle_reserva, r => r.res_id, dr => dr.fk_id_reserva, (r, dr) => new { r, dr }).OrderByDescending(x => x.r.fecha_salida).Where(z=>z.r.fecha_salida == horaactual).ToList();
                foreach (var item in lista)
                {
                    Expired objE = new Expired();
                    objE.res_id = item.r.res_id;
                    objE.fecha_ingreso = item.r.fecha_ingreso;
                    objE.fecha_salida = item.r.fecha_salida;
                    objE.dni_clientes = item.r.dni_clientes;
                    objE.fk_num_habi = item.dr.fk_num_habi;
                    MiLista.Add(objE);
                }
                return MiLista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
