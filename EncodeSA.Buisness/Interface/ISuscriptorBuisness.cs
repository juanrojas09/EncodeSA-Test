using EncodeSA.Models.Entities;

namespace EncodeSA.Buisness.Interface;

public interface ISuscriptorBuisness
{
    public Suscriptor RegistrarSuscripcion(Suscriptor suscriptor);
    public Suscriptor VerificarSuscripcion(string tipoDocumento, int numeroDocumento);
    public Suscriptor GetSuscriptor(string tipoDocumento, int numeroDocumento);
    public Suscriptor ActualizarSuscriptor(Suscriptor suscriptor, string tipoDocumento, int numeroDocumento);

public List<Suscriptor> getall();
    public string Borrarsuscriptor(int id);
    public Suscriptor suscribir(Suscripcion suscripcion,string tipoDocumento, int numeroDocumento);
    
}