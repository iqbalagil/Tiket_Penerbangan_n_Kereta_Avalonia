using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tiket_Penerbangan_n_Kereta.ViewModel.Data;

public class TypeTransportasi
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdTypeTransportasi { get; set; }
    [Required]
    public string NamaType { get; set; }
    [Required]
    public string Keterangan { get; set; }
}