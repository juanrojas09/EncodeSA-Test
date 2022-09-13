using System.ComponentModel.DataAnnotations;

namespace EncodeSA.Models.Entities;

public class Tipo
{
    [Key]
    [Required]
    public  int Id { get; set; }
    public string TipoDocumento { get; set; }
}