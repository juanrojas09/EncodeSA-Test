using EncodeSA.Buisness.Interface;
using EncodeSA.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EncodeSA.Controllers;
[ApiController]
[Route("[controller]")]
public class SuscripcionController : ControllerBase
{
    private readonly ISuscripcionBuisness _suscripcionBuisness;
    public SuscripcionController(ISuscripcionBuisness suscripcionBuisness)
    {
        _suscripcionBuisness = suscripcionBuisness;
    }

    [HttpGet("Suscripcion/getAll")]
    public List<Suscripcion> getall()
    {
        return _suscripcionBuisness.getall();
    }

    [HttpPost]
    public Suscripcion savee(Suscripcion suscripcion)
    {
        return _suscripcionBuisness.savee(suscripcion);
        
    }
    //lo comento pq es innecesario y  porque tengo q cambiar el parametro de id
   /* [HttpPut("update/{id}")]
    public Suscripcion update(Suscripcion suscripcion)
    {
        return _suscripcionBuisness.updatee(suscripcion);
    }*/
    
    [HttpDelete("delete/{id}")]
    public void delete(int id)
    {
        _suscripcionBuisness.deletee(id);
    }
   
}