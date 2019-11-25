using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Objetos;
using Infraestructura.Data.SqlServer;
namespace Dominio.MainModule
{
    public class ReservaManager
    {
        dbhotelEntities db = new dbhotelEntities();
        public Reserva Insert(Reserva p)
        {

            try
            {
                reserva objR = new reserva();
                objR.fecha_ingreso = p.fecha_ingreso;
                objR.fecha_salida = p.fecha_salida;
                objR.cant_personas = p.cant_personas;
                objR.dni_clientes = p.dni_clientes;
                objR.estado_pago = p.estado_pago;
                db.reserva.Add(objR);
                db.SaveChanges();
                p.res_id = objR.res_id;
                return p;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
