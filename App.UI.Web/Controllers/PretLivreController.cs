using App.ApplicationCore.Interfaces;
using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Examen.WEB.Controllers
{
    public class PretLivreController : Controller
    {
        IUnitOfWork unitOfWork;
        IService<PretLivre> pretlivreService;
        public PretLivreController(IUnitOfWork unitOfWork,IService<PretLivre> pretlivreService)
        {
            this.unitOfWork = unitOfWork;

            this.pretlivreService = pretlivreService;
        }

        // GET: PretLivreController
        public ActionResult Index(string filter1,string filter2)
        {
            if (!string.IsNullOrEmpty(filter1) || !string.IsNullOrEmpty(filter2))
                 return View(pretlivreService.GetAll()
                    .Where(x => x.DateDebut.ToString() == filter1 && x.DateFin.ToString() == filter2)); 
            
            return View(pretlivreService.GetAll());
        }

        // GET: PretLivreController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PretLivreController/Create
        public ActionResult Create()
        {
            var taha = pretlivreService.GetAll();
            ViewBag.abonne = new SelectList(taha, "AbonneFk", "MyAbonne.Nom");
            ViewBag.livre = new SelectList(taha, "LivreFk", "MyLivre.Titre");
            return View();
        }

        // POST: PretLivreController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PretLivre pretLivre)
        {
            try
            { 
            
                pretlivreService.Add(pretLivre);
                unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PretLivreController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PretLivreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PretLivreController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PretLivreController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
