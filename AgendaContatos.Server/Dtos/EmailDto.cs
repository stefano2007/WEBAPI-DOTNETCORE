using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaContatos.Server.Dtos
{
    public class EmailDto
    {
        public int Id_Email { get; set; }

        [Required(ErrorMessage = "Campo Id_Contato Obrigatório")]
        public int Id_Contato { get; set; }

        [Required(ErrorMessage = "Campo EmailContato Obrigatório")]
        [StringLength(120, ErrorMessage = "Email até 120 Caracters")]
        public string EmailContato { get; set; }
    }
}
