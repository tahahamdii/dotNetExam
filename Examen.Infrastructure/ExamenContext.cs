
using Examen.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Infrastructure
{
    public class ExamenContext:DbContext
    {
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();

            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                       Initial Catalog= ExamenDB;
                       Integrated Security=true;MultipleActiveResultSets=true",
                       options => options.MigrationsAssembly("Examen.WEB")
                       );

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new CategorieConfig());
            modelBuilder.ApplyConfiguration(new PretLivreConfig());
          
 

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            
        }
    }
}
