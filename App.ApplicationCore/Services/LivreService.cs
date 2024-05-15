using App.ApplicationCore.Interfaces;
using App.ApplicationCore.Services;
using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Services
{
    public class LivreService : Service<Livre>, ILivreService
    {
        public LivreService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IList<Categorie> getcategories(Status ss)
        {
            return GetAll().Where(h => h.PretLivres
            .Any(h => h.MyAbonne.Statut == ss))
                .Select(h => h.MyCategorie).Distinct().ToList();
        }

        public Livre getlivre()
        {
            return GetAll().OrderByDescending(h => h.PretLivres.Count).First();
        }

        public IList<Livre> getlivreList(DateTime dd, DateTime df)
        {
            return GetAll().Where(h => h.PretLivres.Any(h => h.DateDebut >= dd && h.DateFin <= df)).ToList();
        }
    }
}
