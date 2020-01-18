using AgendaContatos.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaContatos.Repository
{
    public class AgendaContatosContext : DbContext
    {
        public AgendaContatosContext(DbContextOptions<AgendaContatosContext> options) :
            base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Tipotelefone> Tipotelefones { get; set; }
        public DbSet<Telefone> Telefones { get; set; }

    }
}
