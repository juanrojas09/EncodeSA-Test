using System.ComponentModel.DataAnnotations;
using System.Globalization;


using Microsoft.VisualBasic;
using Newtonsoft.Json;


namespace EncodeSA.Models.Entities;

public class Suscripcion 
{
   [Key]
   [Required]
   public int Id { get; set; }
  // [JsonConverter(typeof(DateOnlyJsonConverter))]
   public string FechaAlta { get; set; }
  // [JsonConverter(typeof(DateOnlyJsonConverter))]
   public string FechaFin { get; set; }
   public string MotivoFin { get; set; }
   
}

