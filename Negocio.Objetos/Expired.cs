using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Objetos
{
    public class Expired
    {
        public int res_id { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public DateTime fecha_salida { get; set; }
        public string dni_clientes { get; set; }
        public string fk_num_habi { get; set; }
    }
}
