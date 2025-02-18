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
    
    public string? KodePemesanan { get; set; }
    
    public DateTime? TanggalPemesanan { get; set; } = DateTime.UtcNow;
    
    public string TempatPemesanan { get; set; }
    
    [ForeignKey("Penumpang")]
    public int idPenumpang { get; set; }
    public Penumpang Penumpang { get; set; }
    
    public string KodeKursi { get; set; }
    
    public Rute Tujuan { get; set; }
    [ForeignKey("Rute")]
    public int IdRute { get; set; }

    public DateTime TanggalBerangkat { get; set; }
    public DateTime JamTiba { get; set; }
    public DateTime JamBerangkat { get; set; }
    public decimal TotalBayar { get; set; }
    [ForeignKey("Petugas")]
    public int idPetugas { get; set; }
    public Petugas Petugas { get; set; }
}