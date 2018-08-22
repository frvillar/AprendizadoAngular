using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cproj3.Models.Cproj3Ds
{
  [Table("Tarefas", Schema = "dbo")]
  public partial class Tarefa
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Tarefa")]
    public int Tarefa1
    {
      get;
      set;
    }

    public DateTime? Data
    {
      get;
      set;
    }
    public int Responsavel
    {
      get;
      set;
    }

    [ForeignKey("Responsavel")]
    public Pessoa Pessoa { get; set; }
    public decimal? Horas
    {
      get;
      set;
    }
    public string Descricao
    {
      get;
      set;
    }
    public int Projeto
    {
      get;
      set;
    }

    [ForeignKey("Projeto")]
    public Projeto Projeto1 { get; set; }
    public DateTime? dataDig
    {
      get;
      set;
    }
    public bool Manutencao
    {
      get;
      set;
    }
  }
}
