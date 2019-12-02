using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Objetos
{
    public class Piso
    {
        [Display(Name = "ID Piso")]
        public int id_piso { get; set; }
        [Display(Name = "Descripcion")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese Descripcion")]
        public string desc_piso { get; set; }

        [Display(Name = "Estado")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese Estado")]
        public string estado_piso { get; set; }
    }
}
