using App.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Interfaces
{
    public interface IElectionService : IService<Election>
    {
        int GetElecteursCount(DateTime dateElection);
        int GetElecteursJeunesPercent(DateTime dateElection);
    }
}
