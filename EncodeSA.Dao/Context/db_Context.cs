

using EncodeSA.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

public class db_Context : DbContext
{
    public db_Context(DbContextOptions<db_Context> options) : base(options)
    {
    
    
            
    }

    
    public DbSet<Suscripcion> Suscripcion { get; set; }
    public DbSet<Suscriptor> Suscriptor { get; set; }
    public DbSet<Tipo> Tipo { get; set; }
    //to parse DateOnly to date in sql server
    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        builder.Properties<DateOnly>()
            .HaveConversion<DateOnlyConverter>()
            .HaveColumnType("date");
    }
    
                  
    /// <summary>
    /// Converts <see cref="DateOnly" /> to <see cref="DateTime"/> and vice versa.
    /// </summary>
    ///


    public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    {
        /// <summary>
        /// Creates a new instance of this converter.
        /// </summary>
        public DateOnlyConverter() : base(
            d => d.ToDateTime(TimeOnly.MinValue),
            d => DateOnly.FromDateTime(d))
        { }
    }
    
}
