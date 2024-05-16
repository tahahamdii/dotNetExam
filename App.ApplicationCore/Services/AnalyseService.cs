using App.ApplicationCore.Domain;
using App.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Services
{
    public class AnalyseService : Service<Analyse>, IAnalyseService

    {
        public AnalyseService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Analyse getAnalyse(Patient p)
        {
            return GetAll().FirstOrDefault(a => a.BilanFk == p.CodePatient);
        }
    }
}
