using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Objetos
{
    public class Usuario
    {
        [Required]
        public string dni_usu { get; set; }
        [Required]
        public string apenom_usu { get; set; }
        [Required]
        public string password_usu { get; set; }
        [Required]
        public string direccion_usu { get; set; }
        [Required]
        public string estado_usu { get; set; }
    }
}
