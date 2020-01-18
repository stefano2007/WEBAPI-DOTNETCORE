using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgendaContatos.Domain
{
    [Table("Contatos")]
    public class Contato
    {
        [Key]
        public int Id_Contato { get; set; }
        public int Id_Usuario { get; set; }

        [ForeignKey("Id_Usuario")]
        public Usuario Usuario { get; set; }
        public string Nome { get; set; }
        public bool? Ativo { get; set; }
        public DateTime? DtInclusao { get; set; }
    }
}
