using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgendaContatos.Domain
{
    [Table("Telefones")]
    public class Telefone
    {
        [Key]
        public int Id_Telefone { get; set; }
        public int Id_Contato { get; set; }

        [ForeignKey("Id_Contato")]
        public Contato Contato { get; set; }
        public int Id_Tipotelefone { get; set; }

        [ForeignKey("Id_Tipotelefone")]
        public Tipotelefone Tipotelefone { get; set; }
        public string DDD { get; set; }
        public string Fone { get; set; }
        public bool? Valido { get; set; }
        public DateTime? DtInclusao { get; set; }
    }
}
