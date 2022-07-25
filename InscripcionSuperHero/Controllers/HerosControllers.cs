using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InscripcionSuperHero.Data;
using InscripcionSuperHero.Models;
using Microsoft.AspNetCore.Mvc;

namespace InscripcionSuperHero.Controllers
{
    public class HerosControllers : Controller
    {
        private readonly ApplicationDbContext _context;
        public HerosControllers(ApplicationDbContext contex)
        {
            _context = contex;
        }
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Hero> listHeros = _context.Hero;
            return View(listHeros);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Hero hero)
        {
            if (ModelState.IsValid)
            {
                _context.Hero.Add(hero);
                _context.SaveChanges();
                TempData["Mensaje"] = "El personaje se ha creado correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id) 
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }
            var hero = _context.Hero.Find(id);
            if (hero == null)
            {
                return NotFound();
            }
            return View(hero);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(Hero hero)
        {
            if (ModelState.IsValid)
            {
                _context.Hero.Update(hero);
                _context.SaveChanges();
                TempData["Mensaje"] = "El personaje se ha Actualizado correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }
            var hero = _context.Hero.Find(id);
            if (hero == null)
            {
                return NotFound();
            }
            return View(hero);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeleteHero(int? id)
        {
            //Obtener Personaje por ID
            var hero = _context.Hero.Find(id);
            if (hero == null)
            {
                return NotFound();
            }
            _context.Hero.Remove(hero);
            _context.SaveChanges();
            TempData["Mensaje"] = "Libro Eliminado Correctamente";
            return RedirectToAction("Index");
        }

    }
}
