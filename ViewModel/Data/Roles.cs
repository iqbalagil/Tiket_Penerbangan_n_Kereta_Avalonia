using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tiket_Penerbangan_n_Kereta.ViewModel.Data;

[Table("Roles")]
public class Roles
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdRole { get; set; }
    [Required]
    public string RoleName { get; set; }
    public List<Petugas> Petugas { get; set; }
    public List<Penumpang> Penumpangs { get; set; }
}