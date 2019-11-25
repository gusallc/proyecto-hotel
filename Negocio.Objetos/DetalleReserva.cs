using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Objetos
{
    public class DetalleReserva
    {
        public int idDetReserva { get; set; }
        public string fk_num_habi { get; set; }
        public int fk_id_reserva { get; set; }
        public int estado_det { get; set; }
    }
}
