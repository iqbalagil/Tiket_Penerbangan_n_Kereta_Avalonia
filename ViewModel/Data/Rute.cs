using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Storage;

namespace Tiket_Penerbangan_n_Kereta.ViewModel.Data;

public class Rute
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdRute { get; set; }
    [Required]
    public string Tujuan { get; set; }
    [Required]
    public string RuteAwal { get; set; }
    [Required]
    public string RuteAkhri { get; set; }
    
    public int IdTransportasi { get; set; }
    public Transportasi Transportasi { get; set; }
    
    public List<Pemesanan> Pemesanans { get; set; }
}