using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaContatos.Server.Models
{
    public class Auth
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
