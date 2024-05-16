using App.ApplicationCore.Domain;
using App.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Services
{
    public class InfirmierService : Service<Infirmier>, IInfirmierService
    {
        public InfirmierService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }



        public Infirmier getPourcentage(Specialite s)
        {
            return GetAll().FirstOrDefault(i => i.Specialite == s);
        }

        
    }
}
