using App.ApplicationCore.Domain;
using App.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure
{
    public class Context : DbContext
    {

        public DbSet<Electeur> Electeurs { get; set; }
        public DbSet<Election> Elections { get; set; }
        public DbSet<PartiePolitique> PartiePolitiques { get; set; }
        public DbSet<Vote> Votes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.
                UseLazyLoadingProxies().
                UseSqlServer(this.GetJsonConnectionString("appsettings.json"));
            base.OnConfiguring(optionsBuilder);
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveMaxLength(250);
            base.ConfigureConventions(configurationBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vote>().HasKey(e => new { e.DateElection,e.PartiePolitiqueId, e.VoteId});
            modelBuilder.ApplyConfiguration(new ElectionConfiguration());
            modelBuilder.Entity<Electeur>().OwnsOne(e => e.MonBureauVote);
            modelBuilder.Entity<Vote>().OwnsOne(e => e.MonBureauVote);
            base.OnModelCreating(modelBuilder);
        }
    }
}
