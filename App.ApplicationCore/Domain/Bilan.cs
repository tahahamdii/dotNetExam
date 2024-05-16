using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Domain
{
    public class Bilan
    {
        public DateTime DatePrelevement { get; set; }
        public string EmailMedecin { get; set; }
        public bool Paye { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Infirmier Infirmier { get; set; }
        public virtual IList<Analyse> Analyses { get; set; }
        public int CodeInfirmier { get; set; }
        public int CodePatient { get; set; }
    }
}
