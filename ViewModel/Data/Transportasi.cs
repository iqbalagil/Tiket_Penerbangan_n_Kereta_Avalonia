using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tiket_Penerbangan_n_Kereta.ViewModel.Data;

[Table("Transportasi")]
public class Transportasi
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdTransportasi { get; set; }

    [Required] public byte[] Imagedata { get; set; }

    [Required] public string Kode { get; set; }

    [Required] public int JumlahKursi { get; set; }

    public string Keterangan { get; set; }

    [ForeignKey("TypeTransportasi")] public int IdTypeTransportasi { get; set; }

    public TypeTransportasi TypeTransportasi { get; set; }

    public string NamaType { get; set; }

    public List<Rute> Rutes { get; set; }
}