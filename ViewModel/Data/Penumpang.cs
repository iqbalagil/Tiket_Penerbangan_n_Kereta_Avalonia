using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tiket_Penerbangan_n_Kereta.ViewModel.Data;

[Table("Penumpang")]
public class Penumpang
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdPenumpang { get; set; }

    [Required] public string Username { get; set; }

    [Required] [EmailAddress] public string Email { get; set; }

    [Required] public string Password { get; set; }

    public string? Nama { get; set; }
    public char? JenisKelamin { get; set; }
    public string? AlamatPenumpang { get; set; }
    public DateTime? TanggalLahir { get; set; }
    public string? NoTelepon { get; set; }

    public Roles Role { get; set; }
    public int IdRole { get; set; }

    public List<Pemesanan> Pemesanans { get; set; }
}