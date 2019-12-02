 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Objetos
{
   public class Habitacion
    {
        [Display(Name = "Nº")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese Numero de Habitacion")]
        public string num_habi { get; set; }

        [Display(Name = "Descripcion")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese Descripcion")]
        public string desc_habi { get; set; }

        [Display(Name = "Precio")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese el Precio")]
        public decimal precio_habi { get; set; }

        [Display(Name = "Categoria")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese Categoria")]
        public int cat_id { get; set; }

        [Display(Name = "Piso")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese Piso")]
        public int id_piso { get; set; }

        [Display(Name = "Imagen")]
        public string img_habi { get; set; }

        [Display(Name = "Estado")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese Estado")]
        public string estado_habi { get; set; }
    }
}
