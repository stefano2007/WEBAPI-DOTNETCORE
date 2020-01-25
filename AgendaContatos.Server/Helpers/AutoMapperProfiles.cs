using AgendaContatos.Domain;
using AgendaContatos.Server.Dtos;
using AgendaContatos.Server.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaContatos.Server.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Contato, ContatoDto>().ReverseMap();
            CreateMap<Email, EmailDto>().ReverseMap();
            CreateMap<Telefone, TelefoneDto>().ReverseMap();
            CreateMap<Tipotelefone, TipotelefoneDto>().ReverseMap();
            CreateMap<Usuario, UsuarioLoginDto>().ReverseMap();
            CreateMap<Usuario, UsuarioToken>().ReverseMap();
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
        }
    }
}
