using AgendaContatos.Domain;
using AgendaContatos.Server.Dtos;
using AgendaContatos.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaContatos.Server
{
    public interface ILoginService
    {
        Task<UsuarioToken> Authenticate(UsuarioLoginDto userLogin);
    }
}
