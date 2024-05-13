using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Domain
{
    public class Vote
    {
        public DateTime DateElection { get; set; }
        public DateTime DateTime { get; set; }
        public BureauVote MonBureauVote { get; set; }
        public int PartiePolitiqueId { get; set; }
        public int VoteId { get; set; }
        [ForeignKey(nameof(DateElection))]
        public virtual Election Election { get; set; }
        [ForeignKey(nameof(PartiePolitiqueId))]
        public virtual PartiePolitique PartiePolitique { get; set; }


        
    }
}
