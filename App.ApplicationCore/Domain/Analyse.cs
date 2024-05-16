using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Domain
{
    public class Analyse
    {
        public int AnalyseId { get; set; }
        public int DateResultat { get; set; }  
        public double PrixAnalyse { get; set; }
        public string TypeAnalyse { get; set; }
        public float ValeurAnalyse { get; set; }
        public float ValeurMax { get; set; }
        public float ValeurMin { get; set; }
        public virtual Bilan Bilan { get; set; }

        public int BilanFk { get; set; }
    }
}
