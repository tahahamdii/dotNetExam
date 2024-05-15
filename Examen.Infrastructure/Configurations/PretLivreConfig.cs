using Examen.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Infrastructure.Configurations
{
    public class PretLivreConfig : IEntityTypeConfiguration<PretLivre>
    {
        public void Configure(EntityTypeBuilder<PretLivre> builder)
        {
            builder
                .HasOne(r => r.MyLivre)
                .WithMany(p => p.PretLivres)
                .HasForeignKey(r => r.LivreFk);
            builder
                .HasOne(r => r.MyAbonne)
                .WithMany(p => p.PretLivres)
                .HasForeignKey(r => r.AbonneFk);

            builder.HasKey(r => new
            {
                r.DateDebut,
                r.AbonneFk,
                r.LivreFk
            });
        }
    }
}
