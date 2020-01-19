using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaContatos.Server.Dtos
{
    public class UsuarioLoginDto
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Local é entre 3 e 50 Caracters")]
        public string login { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Local é entre 3 e 30 Caracters")]
        public string senha { get; set; }
    }
}
