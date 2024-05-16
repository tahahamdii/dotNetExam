using App.ApplicationCore.Domain;
using App.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Services
{
    public class BilanService:  Service<Bilan>, IBilanService
    {
        public BilanService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Bilan getMontant()
        {
           return GetAll().FirstOrDefault();
        }
    }
    
}
