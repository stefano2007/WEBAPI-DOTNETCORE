using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace AgendaContatos.Domain
{
    [Table("Emails")]
    public class Email
    {
        [Key]
        public int Id_Email { get; set; }
        public int Id_Contato { get; set; }

        [JsonIgnore]
        [ForeignKey("Id_Contato")]
        public Contato Contato { get; set; }
        public string EmailContato { get; set; }
        public bool? Valido { get; set; }
        public DateTime? DtInclusao { get; set; }
    }
}
