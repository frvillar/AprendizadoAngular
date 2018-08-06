using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using Cproj1.Models.Cprojds;

namespace Cproj1.Data
{
  public partial class CprojdsContext : Microsoft.EntityFrameworkCore.DbContext
  {
    public CprojdsContext(DbContextOptions<CprojdsContext> options):base(options)
    {
    }

    public CprojdsContext()
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
