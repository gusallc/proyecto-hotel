using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructura.Data.SqlServer;
using Negocio.Objetos;

namespace Dominio.MainModule
{
  
    public class DetalleReservaManager
    {
        dbhotelEntities db = new dbhotelEntities();

        public DetalleReserva Insert(int idreserva, string numhabi,string estado) {
            try
            {
                detalle_reserva ObjDR = new detalle_reserva();
                ObjDR.fk_id_reserva = idreserva;
                ObjDR.fk_num_habi = numhabi;
                ObjDR.estado_det = int.Parse(estado);
                db.detalle_reserva.Add(ObjDR);
                db.SaveChanges();
            }
            catch (Exception e)
            {

                throw e;
            }

            return null;
        }


    }
}
