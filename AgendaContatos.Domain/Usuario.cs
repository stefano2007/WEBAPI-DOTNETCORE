using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgendaContatos.Domain
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id_Usuario { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public bool? Ativo { get; set; }
        public DateTime? DtInclusao { get; set; }
    }
}
