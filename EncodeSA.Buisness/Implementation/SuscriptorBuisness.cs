using EncodeSA.Buisness.Exceptions;
using EncodeSA.Buisness.Interface;
using EncodeSA.Dao.Interfaces;
using EncodeSA.Models.Entities;

namespace EncodeSA.Buisness.Implementation;

public class SuscriptorBuisness : ISuscriptorBuisness
{
    private readonly ISuscriptorDao _suscriptorRepository;
    private readonly ILogger<SuscriptorBuisness> _logger;

    public SuscriptorBuisness(ISuscriptorDao suscriptorDao, ILogger<SuscriptorBuisness> logger)
    {
        _suscriptorRepository = suscriptorDao;
        _logger = logger;
    }
   
    
    public Suscriptor RegistrarSuscripcion(Suscriptor suscriptor)
    {
        try
        {
         var Susc= _suscriptorRepository.RegistrarSuscripcion(suscriptor);  
            if ( Susc == null )
            {
                throw new ServiceExceptions("Error al registrar suscripcion, ya hay un usuario registrado");
            }
            return Susc;

        }
        catch (ServiceExceptions ex)
        {
            _logger.LogCritical(ex.Message);
            throw ex;
        }
    }

    public Suscriptor VerificarSuscripcion( string tipoDocumento,int numeroDocumento)
    {
        try
        {
            var verificar= _suscriptorRepository.VerificarSuscripcion( tipoDocumento, numeroDocumento);
            if ( verificar == null )
            {
                throw new ServiceExceptions("La persona no esta suscrita");
            }
            return verificar;

        }
        catch (ServiceExceptions ex)
        {
            _logger.LogCritical(ex.Message);
            throw ex;
        }
    }

    public Suscriptor GetSuscriptor(string tipoDocumento, int numeroDocumento)
    {
        try
        {
            var Susc= _suscriptorRepository.GetSuscriptor(tipoDocumento, numeroDocumento);
            if ( Susc == null )
            {
                throw new ServiceExceptions("No existe un suscriptor con los datos ingresados");
            }
            return Susc;

        }
        catch (ServiceExceptions ex)
        {
            _logger.LogCritical(ex.Message);
            throw ex;
        }
    }

    public Suscriptor ActualizarSuscriptor(Suscriptor suscriptor, string tipoDocumento, int numeroDocumento)
    {
        try
        {
            var Susc= _suscriptorRepository.ActualizarSuscriptor(suscriptor, tipoDocumento, numeroDocumento);
            if ( Susc == null )
            {
                throw new ServiceExceptions("No Fue posible actualizar el suscriptor");
            }
            return Susc;

        }
        catch (ServiceExceptions ex)
        {
            _logger.LogCritical(ex.Message);
            throw ex;
        }
    }

    public List<Suscriptor> getall()
    {
        try
        {
            var Susc= _suscriptorRepository.getAll();
            if ( Susc == null )
            {
                throw new ServiceExceptions("No Fue posible obtener los suscriptores");
            }
            return Susc;

        }
        catch (ServiceExceptions ex)
        {
            _logger.LogCritical(ex.Message);
            throw ex;
        }
    }

    public string Borrarsuscriptor(int id)
    {
        try
        {
            var Susc= _suscriptorRepository.BorrarSuscriptor(id);
            if ( Susc == null )
            {
                throw new ServiceExceptions("No Fue posible borrar el suscriptor");
            }
            return Susc;

        }
        catch (ServiceExceptions ex)
        {
            _logger.LogCritical(ex.Message);
            throw ex;
        }
    }
}