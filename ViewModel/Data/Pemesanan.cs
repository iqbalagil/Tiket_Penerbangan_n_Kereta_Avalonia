using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tiket_Penerbangan_n_Kereta.ViewModel.Data;

public class Pemesanan
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdPemesanan { get; set; }
    [Required]
    public string KodePemesanan { get; set; }

    [Required] public DateTime TanggalPemesanan { get; set; } = DateTime.UtcNow;
    public string TempatPemesanan { get; set; }
    
    public int idPenumpang { get; set; }
    public Penumpang Penumpang { get; set; }
    
    public string KodeKursi { get; set; }
    
    public Rute Tujuan { get; set; }
    public int IdRute { get; set; }

    public DateTime TanggalBerangkat { get; set; }
    public DateTime JamTiba { get; set; }
    public DateTime JamBerangkat { get; set; }
    public decimal TotalBayar { get; set; }
    public int idPetugas { get; set; }
    public Petugas Petugas { get; set; }
}