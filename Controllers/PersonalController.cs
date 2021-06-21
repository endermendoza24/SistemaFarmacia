using System;
using SistemaDeFarmacia.Data;
using SistemaDeFarmacia.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SistemaDeFarmacia.Controllers
{
    public class PersonalController : Controller
    {
        private readonly DbFarmaciaContext _db;
        public PersonalController(DbFarmaciaContext db)
        {
            _db = db;
        }

        public IActionResult index()
        {
            return View();
        }

        // GET: Personal
        public ActionResult CrearPersonal()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> CrearPersonal(Personal Per)
        {
            if(ModelState.IsValid)
            {
                await _db.Personal.AddAsync(Per);
                await _db.SaveChangesAsync();
                return RedirectToAction((nameof(CrearPersonal)));
            }
            return View(Per);
        }

        [HttpGet]
        public async Task<IActionResult> MostrarTodos()
        {
            var todas = await _db.Personal.ToListAsync();
            return Json(new { data = todas });
        }

        // GET: Personal/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Personal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personal/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Personal/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Personal/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Personal/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Personal/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}