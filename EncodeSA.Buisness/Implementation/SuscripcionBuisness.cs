using EncodeSA.Buisness.Exceptions;
using EncodeSA.Buisness.Interface;
using EncodeSA.Dao.Interfaces;
using EncodeSA.Models.Entities;

namespace EncodeSA.Buisness.Implementation;

public class SuscripcionBuisness : ISuscripcionBuisness
{
    private readonly ISuscripcionDao _suscripcionDao;
    private readonly ILogger<SuscripcionBuisness> _logger;
    public SuscripcionBuisness(ISuscripcionDao suscripcionDao, ILogger<SuscripcionBuisness> logger)
    {
        _suscripcionDao = suscripcionDao;
        _logger = logger;
    }
    
    public List<Suscripcion> getall()
    {
        try
        {
            var susc= _suscripcionDao.getAll(); 
            if ( susc == null )
            {
                throw new ServiceExceptions("Error al registrar suscripcion");
            }
            return susc;

        }
        catch (ServiceExceptions ex)
        {
            _logger.LogCritical(ex.Message);
            throw ex;
        }
    }

    public Suscripcion savee(Suscripcion suscripcion)
    {
        try
        {
            var susc= _suscripcionDao.save(suscripcion); 
            if ( susc == null )
            {
                throw new ServiceExceptions("Error al registrar suscripcion");
            }
            return susc;

        }
        catch (ServiceExceptions ex)
        {
            _logger.LogCritical(ex.Message);
            throw ex;
        }
    }

    public Suscripcion updatee(Suscripcion suscripcion)
    {
        try
        {
            var susc= _suscripcionDao.update(suscripcion); 
            if ( susc == null )
            {
                throw new ServiceExceptions("Error al registrar suscripcion");
            }
            return susc;

        }
        catch (ServiceExceptions ex)
        {
            _logger.LogCritical(ex.Message);
            throw ex;
        }
    }

    public void deletee(int id)
    {
        try
        {
            _suscripcionDao.delete(id); 
        }
        catch (ServiceExceptions ex)
        {
            _logger.LogCritical(ex.Message);
            throw ex;
        }
    }
}