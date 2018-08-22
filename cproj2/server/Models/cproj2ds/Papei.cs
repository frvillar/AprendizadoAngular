using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cproj2.Models.Cproj2Ds
{
  [Table("Papeis", Schema = "dbo")]
  public partial class Papei
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Papel
    {
      get;
      set;
    }


    [InverseProperty("Papei")]
    public ICollection<Pessoa> Pessoas { get; set; }
    public string Nome
    {
      get;
      set;
    }
  }
}
