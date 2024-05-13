using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Domain
{
    public class Electeur
    {
        [Required]
        [RegularExpression("^[0-9]{8}$")]
        /*[MinLength(8)]
        [MaxLength(8)]
        [RegularExpression("^[0-9]+")]*/
        public string CIN { get; set; }
        public DateTime DateNaissance { get; set; }
        public int ElecteurId { get; set; }
        public BureauVote MonBureauVote { get; set; }
        public Genre MonGenre { get; set; }

        public virtual IList<Election> Elections { get; set; }

    }
}
