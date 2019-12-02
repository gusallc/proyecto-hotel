using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Objetos
{
  public  class Categoria
    {
        [Display(Name = "ID")]
        public int cat_id { get; set; }

        [Display(Name = "Descripcion")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese Descripcion")]
        public string desc_cat { get; set; }

        [Display(Name = "Estado")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese Estado")]
        public string estado_cat { get; set; }
    }
}
