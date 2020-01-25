using AgendaContatos.Domain;
using AgendaContatos.Repository;
using AgendaContatos.Server.Dtos;
using AgendaContatos.Server.Helpers;
using AgendaContatos.Server.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AgendaContatos.Server.Services
{
    public class LoginService : ILoginService
    {
        private readonly AppSettings _appSettings;
        private readonly AgendaContatosContext _context;
        private readonly IMapper _mapper;
        public LoginService(IOptions<AppSettings> appSettings, AgendaContatosContext context, IMapper mapper)
        {
            _appSettings = appSettings.Value;
            _context = context;
            _mapper = mapper;
        }
        public async Task<UsuarioToken> Authenticate(UsuarioLoginDto userLogin)
        {
            Usuario user = await _context.Usuarios
                            .SingleOrDefaultAsync(x =>
                                x.Login == userLogin.login &&
                                x.Senha == userLogin.senha &&
                                x.Ativo == true);

            // return null if user not found
            if (user == null)
                return null;

            var auth = GetToken(user);
            // remove password before returning
            user.Senha = null;

            UsuarioToken usuarioToken = _mapper.Map<Usuario, UsuarioToken>(user);
            usuarioToken.Auth = auth;

            return usuarioToken;
        }

        public Auth GetToken(Usuario user)
        {
            try
            {
                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                //14 horas validas
                var expiration = DateTime.UtcNow.AddHours(14);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.Id_Usuario.ToString())
                    }),
                    Expires = expiration,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return new Auth()
                {
                    Token = tokenHandler.WriteToken(token),
                    Expiration = expiration
                };
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
