using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Objetos
{
    public class ItemCarrito
    {
        public Habitacion habitacion { get; set; }

        public ItemCarrito(Habitacion habitacion)
        {
            this.habitacion = habitacion;
        }
    }
}
