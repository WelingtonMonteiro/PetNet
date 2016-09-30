using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FATEA.PetNet.DataAccess.Entity.Context;
using FATEA.PetNet.Domain;
using FATEA.PetNet.Web.ViewModels;
using AutoMapper;
using FATEA.PetNet.Repository;
using FATEA.Repository.Common;

namespace FATEA.PetNet.Web.Controllers
{
    [Authorize]
    public class AnimalsController : Controller
    {
        private readonly ICrudRepository<Animal, long> _repository = new AnimalRepository(new PetNetDbContext());

        // GET: Animals
        public ActionResult Index()
        {
            List<AnimalIndexViewModel> viewModels = new List<AnimalIndexViewModel>();
            List<Animal> animals = _repository.Select();
            //auto mapper por reflection usando o automapper de uma classe para outra
            viewModels = Mapper.Map<List<Animal>, List<AnimalIndexViewModel>>(animals);

            return View(viewModels);
        }

        // GET: Animals/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = _repository.ById(id.Value);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // GET: Animals/Create
        [Authorize(Roles ="ADMINISTRATOR")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Animals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ADMINISTRATOR")]

        public ActionResult Create(AnimalEditViewModel viewModel)
        {
            if (ModelState.IsValid)//faz validacao de todos os campos por reflection lendo as annotation
            {
                Animal animal = Mapper.Map<AnimalEditViewModel, Animal>(viewModel);

                _repository.Insert(animal);

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Animals/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = _repository.ById(id.Value);
            if (animal == null)
            {
                return HttpNotFound();
            }

            AnimalEditViewModel viewModel = Mapper.Map<Animal, AnimalEditViewModel>(animal);
            return View(viewModel);
        }

        // POST: Animals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AnimalEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Animal animal = Mapper.Map<AnimalEditViewModel, Animal>(viewModel);

                _repository.Update(animal);

                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Animals/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = _repository.ById(id.Value);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
       
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            _repository.DeleteById(id);

            return RedirectToAction("Index");
        }

    }
}
