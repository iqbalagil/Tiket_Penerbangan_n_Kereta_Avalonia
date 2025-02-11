using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tiket_Penerbangan_n_Kereta.ViewModel.Data;

public class Transportasi
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdTransportasi { get; set; }
    [Required]
    public byte[] Imagedata { get; set; }
    [Required]
    public string Kode { get; set; }
    [Required]
    public int JumlahKursi { get; set; }
    public string Keterangan { get; set; }
    [ForeignKey(nameof(TypeTransportasi))]
    public string NamaType { get; set; }
}