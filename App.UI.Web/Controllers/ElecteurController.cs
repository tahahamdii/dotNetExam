﻿using App.ApplicationCore.Domain;
using App.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.UI.Web.Controllers
{
    public class ElecteurController : Controller
    {
        IUnitOfWork unitOfWork;
        IService<Electeur> electeurService;

        public ElecteurController(IUnitOfWork unitOfWork, IService<Electeur> electeurService)
        {
            this.unitOfWork = unitOfWork;
            this.electeurService = electeurService;
        }



        // GET: ElecteurController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ElecteurController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ElecteurController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ElecteurController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Electeur electeur)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View();

                }
                electeurService.Add(electeur);
                unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ElecteurController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ElecteurController/Edit/5
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

        // GET: ElecteurController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ElecteurController/Delete/5
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