using EncodeSA.Dao.Interfaces;
using EncodeSA.Models.Entities;

namespace EncodeSA.Dao.Implementation;

public class SuscripcionDao : ISuscripcionDao
{
    private readonly db_Context _context;
   
    public SuscripcionDao(db_Context context)
    {
        _context = context;
    }
    public List<Suscripcion> getAll()
    {
        return _context.Suscripcion.ToList();
        
    }

    public Suscripcion save(Suscripcion suscripcion)
    {
        _context.Suscripcion.Add(suscripcion);
        _context.SaveChanges();
        return suscripcion;
    }

    public Suscripcion update(Suscripcion suscripcion)
    {
        _context.Suscripcion.Update(suscripcion);
        _context.SaveChanges();
        return suscripcion;
    }

    public void delete(Suscripcion suscripcion)
    {
        _context.Suscripcion.Remove(suscripcion);
        _context.SaveChanges();
    }
}