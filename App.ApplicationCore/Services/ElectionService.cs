using App.ApplicationCore.Domain;
using App.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Services
{
    public class ElectionService : Service<Election>, IElectionService
    {
        public ElectionService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public int GetElecteursCount(DateTime dateElection)
        {
            return GetById(dateElection).Electeurs.Count;
        }

        public float GetElecteursJeunesPercent(DateTime dateElection)
        {
            var electeursJeunesCount = GetById(dateElection).Electeurs.Where(e =>
            {
                var age = (DateTime.Now - e.DateNaissance).TotalDays / 365;
                return age >= 18 && age <= 35;
            }).Count();
            return (float)electeursJeunesCount / GetElecteursCount(dateElection) * 100;
        }
    }
}
