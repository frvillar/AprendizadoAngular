using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cproj1.Models.Cprojds
{
  [Table("Projetos", Schema = "dbo")]
  public partial class Projeto
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Projeto")]
    public int Projeto1
    {
      get;
      set;
    }


    [InverseProperty("Projeto1")]
    public ICollection<Tarefa> Tarefas { get; set; }
    public string Descricao
    {
      get;
      set;
    }
    public int Cliente
    {
      get;
      set;
    }

    [ForeignKey("Cliente")]
    public Pessoa Pessoa { get; set; }
    public bool? ativo
    {
      get;
      set;
    }
    public Int64? CentroResultado
    {
      get;
      set;
    }
  }
}
