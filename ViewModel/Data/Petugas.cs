using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tiket_Penerbangan_n_Kereta.ViewModel.Data;

public class Petugas
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int idPetugas { get; set; }
    [Required]
    public string  Username{ get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Nama { get; set; }
    [ForeignKey(nameof(idRole))]
    public int idRole { get; set; }
    public Roles Roles { get; set; }

    public List<Pemesanan> Pemesanans { get; set; }
    
}