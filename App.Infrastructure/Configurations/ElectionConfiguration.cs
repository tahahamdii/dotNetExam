using App.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Configurations
{
    //Créer une classe de configuration pour configurer la relation many-to-many entre les classes « Election » et « Electeur » en spécifiant « ParticipationElection » comme nom de la table d’association. 


    internal class ElectionConfiguration: IEntityTypeConfiguration<Election>
    {
        public void Configure(EntityTypeBuilder<Election> builder)
        {
            builder.HasMany(e => e.Electeurs).WithMany(e => e.Elections).
                UsingEntity(c => c.ToTable("ParticipationElection"));
        }

    }
}
