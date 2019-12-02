using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Negocio.Objetos
{
    public class Cliente
    {
        [Display(Name ="DNI")]
        [Required]
        public string dni_clientes { get; set; }

        [Display(Name = "Nombres y Apellidos")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese Nombres y Apellidos")]
        public string apenom_cli { get; set; }
        [Display(Name = "Edad")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese Edad")]
        public int edad_cli { get; set; }
        [Display(Name = "Usuario")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese Usuario")]
        public string dni_usu { get; set; }
        [Display(Name = "Estado")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese Estado")]
        public string estado_cli { get; set; }
    }
}
