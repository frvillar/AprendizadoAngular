using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cproj3.Models.Cproj3Ds
{
  [Table("Pessoas", Schema = "dbo")]
  public partial class Pessoa
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Pessoa")]
    public int Pessoa1
    {
      get;
      set;
    }


    [InverseProperty("Pessoa")]
    public ICollection<Projeto> Projetos { get; set; }

    [InverseProperty("Pessoa")]
    public ICollection<Tarefa> Tarefas { get; set; }
    public string Nome
    {
      get;
      set;
    }
    public int PapelPrincipal
    {
      get;
      set;
    }

    [ForeignKey("PapelPrincipal")]
    public Papei Papei { get; set; }
    public bool? ativo
    {
      get;
      set;
    }
    public string senha
    {
      get;
      set;
    }
  }
}
