using App.ApplicationCore.Domain;
using App.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.UI.Web.Controllers
{
    public class InfirmierController : Controller
    {
        IUnitOfWork unitOfWork;
        IService<Infirmier> infirmierService;
        public InfirmierController(IUnitOfWork unitOfWork, IService<Infirmier> infirmierService)
        {
            this.unitOfWork = unitOfWork;
            this.infirmierService = infirmierService;
        }
        // GET: InfirmierController
        public ActionResult Index()
        {
            return View(infirmierService.GetAll());
        }

        // GET: InfirmierController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InfirmierController/Create
        public ActionResult Create()
        {
            var taha = infirmierService.GetAll();
            ViewBag.specialite = new SelectList(taha, "Specialite", "Specialite");
            return View();
        }

        // POST: InfirmierController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Infirmier infirmier)
        {
            try
            {
                infirmierService.Add(infirmier);
                unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InfirmierController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InfirmierController/Edit/5
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

        // GET: InfirmierController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InfirmierController/Delete/5
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
