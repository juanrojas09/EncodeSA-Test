using EncodeSA.Models.Entities;

namespace EncodeSA.Buisness.Interface;

public interface ITipoDao
{
    public List<Tipo> GetTipo();
    public Tipo CrearTipo(Tipo tipo);
    public Tipo ActualizarTipo(Tipo tipo,int id);
    public Tipo EliminarTipo(Tipo tipo);
}