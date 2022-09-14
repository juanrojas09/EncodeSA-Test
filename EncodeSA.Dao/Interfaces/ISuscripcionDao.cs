using EncodeSA.Models.Entities;

namespace EncodeSA.Dao.Interfaces;

public interface ISuscripcionDao
{
    public List<Suscripcion> getAll();
    
    public Suscripcion save(Suscripcion suscripcion);
    public Suscripcion update(Suscripcion suscripcion);
    public void delete(int id);
    
}