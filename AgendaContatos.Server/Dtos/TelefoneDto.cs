using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaContatos.Server.Dtos
{
    public class TelefoneDto
    {
        public int Id_Telefone { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Id_Contato { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Id_Tipotelefone { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string DDD { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Fone { get; set; }
    }
}
