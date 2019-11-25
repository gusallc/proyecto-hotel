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
        [Display(Name = "Apellido")]
        [Required]
        public string apenom_cli { get; set; }
        [Display(Name = "Edad")]
        [Required]
        public int edad_cli { get; set; }
        [Display(Name = "Usuario")]
        [Required]
        public string dni_usu { get; set; }
        [Display(Name = "Estado")]
        [Required]
        public string estado_cli { get; set; }
    }
}
