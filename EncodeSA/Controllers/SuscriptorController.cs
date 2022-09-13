using System.Web.Http.Cors;
using EncodeSA.Buisness.Interface;
using EncodeSA.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EncodeSA.Controllers;
[ApiController]
[Route("[controller]")]
[EnableCors(origins: "https://localhost:7284/swagger/", headers: "*", methods: "*")]
public class SuscriptorController : ControllerBase
{
    private readonly ISuscriptorBuisness _suscriptorBuisness;
       public SuscriptorController(ISuscriptorBuisness suscriptorBuisness)
    {
        _suscriptorBuisness = suscriptorBuisness;
    }

       [HttpPost]
       
       public Suscriptor RegistrarSuscripcion(Suscriptor suscriptor)
       {
          return  _suscriptorBuisness.RegistrarSuscripcion(suscriptor);
       }

       [HttpGet("suscriptor/verificar/{numeroDocumento}/{tipoDocumento}")]
       public Suscriptor VerificarSuscripcion(string tipoDocumento, int numeroDocumento)
       {
          return _suscriptorBuisness.VerificarSuscripcion(  tipoDocumento,numeroDocumento);

       }
       
       
       
       
       
      // public Suscriptor GetSuscriptor(string tipoDocumento,string numeroDocumento);

      [HttpPut("suscriptor/actualizar/{tipoDocumento}/{numeroDocumento}")]
      public Suscriptor ActualizarSuscriptor(Suscriptor suscriptor, string tipoDocumento, int numeroDocumento)
      {
       return _suscriptorBuisness.ActualizarSuscriptor(suscriptor, tipoDocumento, numeroDocumento);  
      }

      [HttpDelete("suscriptor/eliminar/{id}")]
      public string Borrarsuscriptor(int id)
      {
         _suscriptorBuisness.Borrarsuscriptor(id);
         return "eliminado";
      }
      
      [HttpGet("suscriptor/obtenerTodos")]
       public List<Suscriptor> getall()
       {
          return _suscriptorBuisness.getall();
       }
       

    }