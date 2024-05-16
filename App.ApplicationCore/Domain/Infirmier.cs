using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Domain
{
    public enum Specialite
    {
        Hermatologie,
        Biochimie,
        Aute
    }
    public class Infirmier
    {
        [Key]
        public int InfrimierId { get; set; }
        public string NomComplet { get; set; }

        public Specialite Specialite { get; set; }
        public virtual Laboratoire Laboratoire { get; set; }
        public virtual IList<Bilan> Bilans { get; set; }


    }
}
