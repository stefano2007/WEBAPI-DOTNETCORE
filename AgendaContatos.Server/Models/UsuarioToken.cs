using AgendaContatos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaContatos.Server.Models
{
    public class UsuarioToken : Usuario
    {
        public Auth Auth { get; set; }
    }
}
