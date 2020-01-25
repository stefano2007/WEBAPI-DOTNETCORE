using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaContatos.Server.Dtos
{
    public class UsuarioDto
    {
        public int Id_Usuario { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Login é entre 3 e 50 Caracters")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Senha é entre 3 e 30 Caracters")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "Nome é entre 3 e 80 Caracters")]
        public string Nome { get; set; }
    }
}
