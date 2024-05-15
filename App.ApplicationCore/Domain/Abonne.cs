using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public enum Status
    {
        Etudiant,
        Enseignant,
        Autre
    }
    public class Abonne
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Id { get; set; }
        public Status Statut { get; set; }

        public string Adresse { get; set; }
        public string Email { get; set; }
        public DateTime DateCreation { get; set; }
        public virtual IList<PretLivre> PretLivres { get; set; }


    }
}
