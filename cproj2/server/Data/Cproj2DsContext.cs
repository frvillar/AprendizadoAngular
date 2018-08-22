using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using Cproj2.Models.Cproj2Ds;

namespace Cproj2.Data
{
  public partial class Cproj2DsContext : Microsoft.EntityFrameworkCore.DbContext
  {
    public Cproj2DsContext(DbContextOptions<Cproj2DsContext> options):base(options)
    {
    }

    public Cproj2DsContext()
    {
    }

    partial void OnModelBuilding(ModelBuilder builder);

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);


        builder.Entity<Pessoa>()
              .HasOne(i => i.Papei)
              .WithMany(i => i.Pessoas)
              .HasForeignKey(i => i.PapelPrincipal)
              .HasPrincipalKey(i => i.Papel);

        builder.Entity<Projeto>()
              .HasOne(i => i.Pessoa)
              .WithMany(i => i.Projetos)
              .HasForeignKey(i => i.Cliente)
              .HasPrincipalKey(i => i.Pessoa1);

        builder.Entity<Tarefa>()
              .HasOne(i => i.Pessoa)
              .WithMany(i => i.Tarefas)
              .HasForeignKey(i => i.Responsavel)
              .HasPrincipalKey(i => i.Pessoa1);

        builder.Entity<Tarefa>()
              .HasOne(i => i.Projeto1)
              .WithMany(i => i.Tarefas)
              .HasForeignKey(i => i.Projeto)
              .HasPrincipalKey(i => i.Projeto1);

        builder.Entity<Tarefa>()
              .Property(p => p.Data)
              .HasDefaultValueSql("(getdate())");

        builder.Entity<Tarefa>()
              .Property(p => p.Horas)
              .HasDefaultValueSql("((0))");

        builder.Entity<Tarefa>()
              .Property(p => p.dataDig)
              .HasDefaultValueSql("(getdate())");

        this.OnModelBuilding(builder);
    }


    public DbSet<Papei> Papeis
    {
      get;
      set;
    }

    public DbSet<Pessoa> Pessoas
    {
      get;
      set;
    }

    public DbSet<Projeto> Projetos
    {
      get;
      set;
    }

    public DbSet<Tarefa> Tarefas
    {
      get;
      set;
    }
  }
}
