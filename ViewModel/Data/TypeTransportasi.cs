using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tiket_Penerbangan_n_Kereta.ViewModel.Data;

[Table("TypeTransportasi")]
public class TypeTransportasi
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdTypeTransportasi { get; set; }

    [Required] public string NamaType { get; set; }

    public string Keterangan { get; set; }

    [Required] public List<Transportasi> Transports { get; set; }
}