using EncodeSA.Models.Entities;

namespace EncodeSA.Dao.Interfaces;

public interface ISuscriptorDao
{
    public Suscriptor RegistrarSuscripcion(Suscriptor suscriptor);
    public Suscriptor VerificarSuscripcion( string tipoDocumento,int numeroDocumento);
    public Suscriptor GetSuscriptor(string tipoDocumento,int numeroDocumento);
    public Suscriptor ActualizarSuscriptor(Suscriptor suscriptor, string tipoDocumento, int numeroDocumento);

    public List<Suscriptor> getAll();
    public string BorrarSuscriptor(int id);
}