using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Objetos
{
   public class Reserva
    {

        public int res_id { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public DateTime fecha_salida { get; set; }
        public int cant_personas { get; set; }
        public string dni_clientes { get; set; }
        public string estado_pago { get; set; } 
    }
}
