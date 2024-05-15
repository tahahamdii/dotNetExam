﻿using Examen.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Interfaces
{
    public interface ILivreService
    {
        Livre getlivre();
        IList<Livre> getlivreList(DateTime dd, DateTime df);

        IList<Categorie> getcategories(Status ss);
    }
}
