using App.ApplicationCore.Domain;
using App.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Services
{
    public class VoteService: Service<Vote>, IVoteService
    {
        public VoteService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public PartiePolitique GetPartiePoitiqueElu(DateTime dateElection)
        {
            var partiePolitiqueEluId = GetMany(e => e.DateElection == dateElection).
                GroupBy(e => e.PartiePolitiqueId).OrderByDescending(e => e.Count()).First().Key;

            return UnitOfWork.Repository<PartiePolitique>().GetById(partiePolitiqueEluId);
        }
    }
}
