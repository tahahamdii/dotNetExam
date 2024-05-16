using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.ApplicationCore.Domain;

namespace App.Infrastructure.Configurations
{
    public class BilanConfig : IEntityTypeConfiguration<Bilan>
    {
        public void Configure(EntityTypeBuilder<Bilan> builder)
        {
            builder
                .HasOne(r => r.Patient)
                .WithMany(p => p.Bilans)
                .HasForeignKey(r => r.CodePatient);
            builder
                .HasOne(r => r.Infirmier)
                .WithMany(p => p.Bilans)
                .HasForeignKey(r => r.CodeInfirmier);

            builder.HasKey(r => new
            {
                r.CodeInfirmier,
                r.CodePatient,
                r.DatePrelevement
            });
        }
    }
}
