using System.ComponentModel.DataAnnotations;

namespace EncodeSA.Models.Entities;

public class Suscriptor
{
    [Key]
    [Required]
    public int s_Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public int NumeroDocumento { get; set; }
    public Tipo TipoDoc { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public string NombreUsuario { get; set; }
    public string Password { get; set; }
    public Suscripcion Suscripcion { get; set; }
}