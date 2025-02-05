using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tiket_Penerbangan_n_Kereta.ViewModel.Data;

public class File
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int idFile { get; set; }
    public string Name { get; set; }
    public byte Image { get; set; }
    public DateTime UploadDateTime { get; set; } = DateTime.UtcNow;
}