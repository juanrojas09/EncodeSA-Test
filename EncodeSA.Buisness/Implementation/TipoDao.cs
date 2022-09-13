using EncodeSA.Buisness.Interface;
using EncodeSA.Models.Entities;

namespace EncodeSA.Buisness.Implementation;

public class TipoDao :ITipoDao
{
    private readonly db_Context _context;
   
    public TipoDao(db_Context context)
    {
        _context = context;
    }
    public List<Tipo> GetTipo()
    {
        return _context.Tipo.ToList();
    }

    public Tipo CrearTipo(Tipo tipo)
    {
        _context.Tipo.Add(tipo);
        _context.SaveChanges();
        return tipo;
    }

    public Tipo ActualizarTipo(Tipo tipo,int id)
    {
       
        _context.Update(tipo);
        _context.SaveChanges();
        return tipo;
    }

    public Tipo EliminarTipo(Tipo tipo)
    {
        _context.Remove(tipo);
        _context.SaveChanges();
        return tipo;
    }
}