using Microsoft.EntityFrameworkCore;

namespace ProjetoFinal.Models
{
    public class ErrosDbContext : DbContext
    {
       public ErrosDbContext(DbContextOptions<ErrosDbContext> options) : base(options)
       {
           
       }

       public DbSet<Erros> Erros {get; set;} 
    }
}