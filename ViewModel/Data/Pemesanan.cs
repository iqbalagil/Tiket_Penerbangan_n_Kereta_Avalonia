using System;
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
    [ForeignKey(nameof(Penumpang))]
    public int idPenumpang { get; set; }
    public string KodeKursi { get; set; }
    [ForeignKey(nameof(Rute))]
    public int IdRute { get; set; }
    public string Tujuan { get; set; }
    public DateTime TanggalBerangkat { get; set; }
    public decimal TotalBayar { get; set; }
    [ForeignKey(nameof(Petugas))]
    public int idPetugas { get; set; }
}