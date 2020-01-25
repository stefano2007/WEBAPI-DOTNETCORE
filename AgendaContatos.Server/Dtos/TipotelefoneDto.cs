using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaContatos.Server.Dtos
{
    public class TipotelefoneDto
    {
        public int Id_Tipotelefone { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(100, ErrorMessage = "Descricao até 100 Caracters")]
        public string Descricao { get; set; }
    }
}
