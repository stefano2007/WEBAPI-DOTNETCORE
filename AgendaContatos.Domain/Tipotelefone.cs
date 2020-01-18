using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgendaContatos.Domain
{
    [Table("Tipotelefone")]
    public class Tipotelefone
    {
        [Key]
        public int Id_Tipotelefone { get; set; }
        public string Descricao { get; set; }
    }
}
