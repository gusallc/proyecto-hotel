 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Objetos
{
   public class Habitacion
    {
        public string num_habi { get; set; }
        public string desc_habi { get; set; }
        public decimal precio_habi { get; set; }
        public int cat_id { get; set; }
        public int id_piso { get; set; }
        public string img_habi { get; set; }
        public string estado_habi { get; set; }
    }
}
