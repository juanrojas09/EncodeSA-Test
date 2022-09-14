using System.ComponentModel;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using EncodeSA.Dao.Interfaces;
using EncodeSA.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;


namespace EncodeSA.Dao.Implementation;
//


public class SuscriptorDao : ISuscriptorDao
{
    private readonly db_Context _context;
   
    public SuscriptorDao(db_Context context)
    {
        _context = context;
    }

    public Suscriptor RegistrarSuscripcion(Suscriptor suscriptor)
    {
        var num2=_context.Suscriptor.FirstOrDefault(p=>p.NumeroDocumento==suscriptor.NumeroDocumento);
        var name2=_context.Suscriptor.FirstOrDefault(p=>p.NombreUsuario==suscriptor.NombreUsuario);
        /*var num = _context.Suscriptor.FromSqlRaw("select * from Suscriptor where NumeroDocumento = {0}",
            suscriptor.NumeroDocumento);
        var name = _context.Suscriptor.FromSqlRaw("select * from Suscriptor where NombreUsuario = {0}",
            suscriptor.NombreUsuario);*/
        
        if (num2 !=null || name2!=null)
        {
            return null;
        }
        else
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(suscriptor.Password));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            suscriptor.Password = sb.ToString();
            _context.Suscriptor.Add(suscriptor);
            _context.SaveChanges();
            return suscriptor;
        }
        
    }


    public Suscriptor VerificarSuscripcion( string tipoDocumento,int numeroDocumento)
    {
        //var susccriptor=_context.Suscriptor.FromSqlRaw("Select * from Suscriptor INNER JOIN Tipo on Tipo.id=Suscriptor.s_id where  Suscriptor.NumeroDocumento={0}",numeroDocumento).Include(x=>x.TipoDoc).Include(l=>l.Suscripcion).FirstOrDefault();
        var susc = _context.Suscriptor.Include(x=>x.TipoDoc).Include(l=>l.Suscripcion).FirstOrDefault(x=>x.NumeroDocumento== numeroDocumento );
       // var numdoc = _context.Tipo.Include(x => x.TipoDocumento).First(x => x.TipoDocumento.Equals(tipoDocumento));
        if (susc != null)
        {
            return susc;
        }
        else
        {
            return null;
        }
       
        
            
        
        
    }

/// <summary>
/// funcion que me trae suscriptor por num de doc y tipo de doc, pero igual la de arriba de verificar es lo mmismo porque busca
/// y verifica que exista
/// </summary>
/// <param name="tipoDocumento"></param>
/// <param name="numeroDocumento"></param>
/// <returns></returns>
    public Suscriptor GetSuscriptor(string tipoDocumento,int numeroDocumento)
    {
       var susc= _context.Suscriptor.Find(tipoDocumento,numeroDocumento);
       return susc;


    }

//ver como implementar la logica de, en el cliente busco por num doc y tipo, si quiero actualizarlo, como rescato el id
/*
 *En el caso de que el suscriptor exista y se quiera modificar los datos,
 * el campo nombre de usuario permanecerá en solo lectura,
 * se podrán modificar todos los demás datos. Ver C.U. Modificar Suscriptor
 *
 *
 * 
 */
    public Suscriptor ActualizarSuscriptor(Suscriptor suscriptor, string tipoDocumento, int numeroDocumento)
    {
        //var susc=_context.Suscriptor.FromSqlRaw("Select * from Suscriptor INNER JOIN Tipo on Tipo.id=Suscriptor.s_id where  Suscriptor.NumeroDocumento={0}",numeroDocumento).Include(x=>x.TipoDoc).Include(l=>l.Suscripcion).FirstOrDefault();
        var susc = _context.Suscriptor.Include(x=>x.TipoDoc).Include(l=>l.Suscripcion).FirstOrDefault(x=>x.NumeroDocumento== numeroDocumento );
        if (suscriptor.NumeroDocumento == susc.NumeroDocumento)
        {
            susc.Nombre = suscriptor.Nombre;
            susc.Apellido = suscriptor.Apellido;
            susc.Direccion = suscriptor.Direccion;
            susc.Telefono = suscriptor.Telefono;
            susc.Email = suscriptor.Email;
            susc.Password = suscriptor.Password;
            _context.Update(susc);
            _context.SaveChanges();
            return suscriptor;
        }
        else
        {
            return null;
        }
    }

    public List<Suscriptor> getAll()
    {
        return _context.Suscriptor.Include(x=>x.TipoDoc).Include(p=>p.Suscripcion).ToList();
    }

    public string BorrarSuscriptor(int item)
    {
        var suscriptor = _context.Suscriptor.Find(item);
        _context.Suscriptor.Remove(suscriptor);
        _context.SaveChanges();
        return "Suscriptor eliminado";
    }

    public Suscriptor Suscribir(Suscripcion suscripcion,string tipoDocumento, int numeroDocumento)
    {
        //var susc = _context.Suscriptor.Include(x => x.TipoDoc).Include(l => l.Suscripcion).FirstOrDefault(x => x.s_Id == suscripcion.Id);
        var susc = _context.Suscriptor.Include(x=>x.TipoDoc).Include(l=>l.Suscripcion).FirstOrDefault(x=>x.NumeroDocumento== numeroDocumento );
        if (susc != null)
        {
            
           // susc.Suscripcion.Id = susc2.Id;
            susc.Suscripcion.FechaAlta = DateTime.Now.ToString();
            _context.Update(susc);
            _context.SaveChanges();
            return susc;
        }
        else
        {
            return null;
        }
    }
}