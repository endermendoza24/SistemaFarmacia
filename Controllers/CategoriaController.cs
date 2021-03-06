using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeFarmacia.Data;
using SistemaDeFarmacia.Models;

namespace SistemaDeFarmacia.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly DbFarmaciaContext _db;
        // GET: Categoria
        public CategoriaController(DbFarmaciaContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult CrearCategoria()
        {
            return View();
        }
        [HttpPost] 
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearCategoria(CategoriaMedicamento Cat)
        {
            if(ModelState.IsValid) // valida si el modelo es correcto
            {
                await _db.CategoriaMedicamento.AddAsync(Cat); //  con esto se envía a la base de datos
                await _db.SaveChangesAsync(); //  Guarda de forma asincrónica todos los cambios realizados en este contexto en la base de datos subyacente.
                return RedirectToAction((nameof(CrearCategoria))); //  esto redirecciona a la vista correspondiente
            }
            return View(Cat); //  si los datos están malos retorna la vista con los datos
        }

        [HttpGet]
        public async Task<IActionResult> MostrarTodos()
        {
            var todas = await _db.CategoriaMedicamento.ToListAsync();
            return Json(new { data = todas });
        }





        // GET: Categoria/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
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

        // GET: Categoria/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Categoria/Edit/5
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

        // GET: Categoria/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Categoria/Delete/5
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