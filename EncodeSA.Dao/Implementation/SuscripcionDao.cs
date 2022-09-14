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

    
    /*
     * TODO: implementar metodo que agregue una fecha de suscripcion a el suscriptor que se busca por parametro,
     * TODO: y que le modifique ese valor, osea , creo un suscriptor, su suscripcion va a ser "string", entonces en la
     * TODO: interfaz, me va a mostrar que no tiene una suscripcion, cuando corra el boton suscribir, le va a agregar la fecha de ese dia
     *TODO: y al buscarlo por dni y tipo, me va a figurar "SUSCRITO" en la interfaz
     */
    public Suscripcion save(Suscripcion suscripcion)
    {
       
        var susc = _context.Suscriptor.First(x => x.s_Id== suscripcion.Id );
        suscripcion.FechaAlta = DateTime.Now.ToString();
        
        _context.Suscripcion.Update(susc.Suscripcion);
        _context.SaveChanges();
        return susc.Suscripcion;
    }

    public Suscripcion update(Suscripcion suscripcion)
    {
        _context.Suscripcion.Update(suscripcion);
        _context.SaveChanges();
        return suscripcion;
    }

    public void delete(int id)
    {
        var suscripcion = _context.Suscripcion.Find(id);
        _context.Suscripcion.Remove(suscripcion);
        _context.SaveChanges();
    }
}