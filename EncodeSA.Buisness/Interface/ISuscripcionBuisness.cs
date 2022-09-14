using EncodeSA.Models.Entities;

namespace EncodeSA.Buisness.Interface;

public interface ISuscripcionBuisness
{
    public List<Suscripcion> getall();
    
    public Suscripcion savee(Suscripcion suscripcion);
    public Suscripcion updatee(Suscripcion suscripcion);
    public void deletee(int id);
}